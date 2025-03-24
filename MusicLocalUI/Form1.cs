using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace MusicLocalUI
{
    public partial class MainApp : Form
    {
        private string path_to_music_folder = "";
        private readonly string[] audioExtensions = { ".mp3", ".wav", ".flac", ".aac", ".ogg", ".wma", ".m4a" };
        private string[] allFiles;
        private int totalDurationSeconds = 0;
        private List<string> audioFilesList = new List<string>();
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private Timer playbackTimer;
        private bool isUserSeeking = false;

        public MainApp()
        {
            InitializeComponent();
            playbackProgressBar.ForeColor = Color.DodgerBlue;

            // Инициализация таймера для обновления прогресса
            playbackTimer = new Timer { Interval = 500 };
            playbackTimer.Tick += PlaybackTimer_Tick;
            playbackProgressBar.MouseDown += (s, e) => isUserSeeking = true;
            playbackProgressBar.MouseUp += PlaybackProgressBar_MouseUp;
        }

        private void select_folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialo = new FolderBrowserDialog
            {
                Description = "Select Folder with Music"
            })
            {
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    path_to_music_folder = folderDialog.SelectedPath;
                    path_to_folder.Text = path_to_music_folder;
                }
            }
        }

        private async void scan_folder_Click(object sender, EventArgs e)
        {
            // Проверка выбранной папки
            if (string.IsNullOrEmpty(path_to_music_folder) || !Directory.Exists(path_to_music_folder))
            {
                MessageBox.Show(!Directory.Exists(path_to_music_folder)
                    ? "Selected folder does not exist!"
                    : "Please select a folder first!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Настройка UI перед сканированием
                SetupUIForScanning();

                // Получаем и фильтруем аудиофайлы
                audioFilesList = Directory.GetFiles(path_to_music_folder, "*.*", SearchOption.AllDirectories)
                    .Where(file => audioExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .ToList();

                // Настройка элементов управления
                scanProgressBar.Maximum = audioFilesList.Count;
                SetupListBox();

                // Обработка файлов
                await ProcessAudioFilesAsync();

                // Обновление статуса
                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error scanning folder: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RestoreUIAfterScanning();
            }
        }

        private void SetupUIForScanning()
        {
            scan_folder.Enabled = false;
            select_folder.Enabled = false;
            scanProgressBar.Visible = true;
            currentFileLabel.Visible = true;
            scanningLabel.Visible = true;
            musicListBox.Visible = false;
            totalDurationSeconds = 0;
        }

        private void SetupListBox()
        {
            musicListBox.BeginUpdate();
            musicListBox.Items.Clear();
            musicListBox.DrawMode = DrawMode.OwnerDrawVariable;
            musicListBox.ScrollAlwaysVisible = true;
            musicListBox.HorizontalScrollbar = true;
            musicListBox.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            musicListBox.MeasureItem += (s, me) => me.ItemHeight = 60;
            musicListBox.DrawItem += DrawMusicListItem;
        }

        private async Task ProcessAudioFilesAsync()
        {
            for (int i = 0; i < audioFilesList.Count; i++)
            {
                string file = audioFilesList[i];

                UpdateProgressUI(file, i);

                // Получаем информацию о файле
                var (duration, durationString) = GetAudioFileInfo(file);
                totalDurationSeconds += duration;

                musicListBox.Items.Add($"{Path.GetFileNameWithoutExtension(file)}|||Duration: {durationString}");

                if (i % 5 == 0) await Task.Delay(1); // Периодическое освобождение потока
            }
        }

        private void UpdateProgressUI(string file, int index)
        {
            string fileName = Path.GetFileName(file);
            currentFileLabel.Text = fileName.Length > 60
                ? fileName.Insert(60, Environment.NewLine)
                : fileName;
            scanProgressBar.Value = index + 1;
        }

        private (int duration, string durationString) GetAudioFileInfo(string filePath)
        {
            try
            {
                using (var file = TagLib.File.Create(filePath))
                {
                    int seconds = (int)file.Properties.Duration.TotalSeconds;
                    string formatted = seconds > 0
                        ? $"{seconds / 60}:{seconds % 60:00}"
                        : "N/A";
                    return (seconds, formatted);
                }
            }
            catch
            {
                return (0, "N/A");
            }
        }

        private void UpdateStatusLabel()
        {
            string totalTime = totalDurationSeconds > 0
                ? $"{totalDurationSeconds / 3600}h {(totalDurationSeconds % 3600) / 60}m {totalDurationSeconds % 60}s"
                : "N/A";
            TotalFiles.Text = $"Found: {audioFilesList.Count} tracks";
            TotalTime.Text = $"Total duration: {totalTime}";
        }

        private void RestoreUIAfterScanning()
        {
            musicListBox.EndUpdate();
            scan_folder.Enabled = true;
            select_folder.Enabled = true;
            scanProgressBar.Visible = false;
            currentFileLabel.Visible = false;
            scanningLabel.Visible = false;
            musicListBox.Visible = true;
        }

        private void DrawMusicListItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            // Подготовка данных
            var itemText = musicListBox.Items[e.Index]?.ToString() ?? "";
            var parts = itemText.Split(new[] { "|||" }, StringSplitOptions.None);
            var title = parts.Length > 0 ? parts[0] : "";
            var duration = parts.Length > 1 ? parts[1] : "";

            // Определение стилей
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bgColor = isSelected ? Color.FromArgb(51, 153, 255) :
                (e.Index % 2 == 0 ? Color.White : Color.FromArgb(245, 245, 245));
            var textColor = isSelected ? Color.White : Color.Black;

            // Отрисовка
            using (var bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            // Разделительная линия
            e.Graphics.DrawLine(Pens.LightGray, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

            // Название трека
            var titleRect = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + 5, e.Bounds.Width - 30, e.Bounds.Height / 2);
            TextRenderer.DrawText(e.Graphics, title, new Font(e.Font, FontStyle.Bold),
                                 titleRect, textColor, TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

            // Длительность
            var durationRect = new Rectangle(e.Bounds.X + 15, e.Bounds.Y + e.Bounds.Height / 2,
                                           e.Bounds.Width - 30, e.Bounds.Height / 2);
            TextRenderer.DrawText(e.Graphics, duration, e.Font, durationRect,
                                 textColor, TextFormatFlags.Left);

            if (isSelected) e.DrawFocusRectangle();
        }


        private void path_to_folder_TextChanged(object sender, EventArgs e)
        {
            path_to_music_folder = path_to_folder.Text;
            if (Directory.Exists(path_to_music_folder))
            {
                folderStatusLabel.Text = "Folder found";
                folderStatusLabel.ForeColor = Color.Green;
                scan_folder.Enabled = true;
            }
            else
            {
                folderStatusLabel.Text = "Folder not found";
                folderStatusLabel.ForeColor = Color.Red;
                scan_folder.Enabled = false;
            }
        }

        private void musicListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Можно добавить предпросмотр при изменении выбора
            // или другие действия при изменении выделенного элемента
        }

        private void musicListBox_DoubleClick(object sender, EventArgs e)
        {
            if (musicListBox.SelectedIndex < 0 || musicListBox.SelectedIndex >= audioFilesList.Count)
                return;

            try
            {
                // Получаем полный путь к файлу напрямую по индексу
                string filePath = audioFilesList[musicListBox.SelectedIndex];

                if (File.Exists(filePath))
                {
                    PreviousPlay.Enabled = true;
                    NextPlay.Enabled = true;
                    StartPausePlay.Enabled = true;
                    StartPausePlay.Text = "⏸"; // Устанавливаем иконку pause
                    PlayAudioFile(filePath);
                }
                else
                {
                    MessageBox.Show("Audio file not found!", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Можно автоматически удалить отсутствующий файл из списка
                    audioFilesList.RemoveAt(musicListBox.SelectedIndex);
                    musicListBox.Items.RemoveAt(musicListBox.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Playback Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlayAudioFile(string filePath)
        {
            try
            {
                player.controls.stop();
                player.URL = filePath;
                player.controls.play();

                // Сбрасываем прогресс-бар
                playbackProgressBar.Value = 0;
                playbackTimer.Start();

                NowPlaying.Text = $"Now playing: {Path.GetFileNameWithoutExtension(filePath)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing file: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreviousPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (audioFilesList.Count == 0) return;

                int currentIndex = musicListBox.SelectedIndex;
                int newIndex = currentIndex <= 0 ? audioFilesList.Count - 1 : currentIndex - 1;

                musicListBox.SelectedIndex = newIndex;
                PlayCurrentSelectedFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing previous track: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartPausePlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (player.playState == WMPPlayState.wmppsPlaying)
                {
                    player.controls.pause();
                    StartPausePlay.Text = "▶"; // Или установите иконку play
                    playbackTimer.Stop();
                }
                else
                {
                    if (player.playState == WMPPlayState.wmppsPaused)
                    {
                        player.controls.play();
                    }
                    else if (musicListBox.SelectedIndex >= 0)
                    {
                        PlayCurrentSelectedFile();
                    }
                    else if (audioFilesList.Count > 0)
                    {
                        musicListBox.SelectedIndex = 0;
                        PlayCurrentSelectedFile();
                    }
                    playbackTimer.Start();
                    StartPausePlay.Text = "⏸"; // Или установите иконку pause
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error controlling playback: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NextPlay_Click(object sender, EventArgs e)
        {
            try
            {
                if (audioFilesList.Count == 0) return;

                int currentIndex = musicListBox.SelectedIndex;
                int newIndex = currentIndex >= audioFilesList.Count - 1 ? 0 : currentIndex + 1;

                musicListBox.SelectedIndex = newIndex;
                PlayCurrentSelectedFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing next track: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlayCurrentSelectedFile()
        {
            if (musicListBox.SelectedIndex < 0 || musicListBox.SelectedIndex >= audioFilesList.Count)
                return;

            string filePath = audioFilesList[musicListBox.SelectedIndex];
            if (File.Exists(filePath))
            {
                PlayAudioFile(filePath);
                StartPausePlay.Text = "⏸"; // Устанавливаем иконку pause
            }
            else
            {
                MessageBox.Show("File not found: " + Path.GetFileName(filePath), "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying && !isUserSeeking)
            {
                // Обновляем прогресс-бар
                playbackProgressBar.Maximum = (int)player.currentMedia.duration;
                playbackProgressBar.Value = (int)player.controls.currentPosition;

                // Обновляем метки времени
                timeLabel.Text = $"{FormatTime(player.controls.currentPosition)} / {FormatTime(player.currentMedia.duration)}";
            }
        }

        private string FormatTime(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return $"{time.Minutes:00}:{time.Seconds:00}";
        }
        private void PlaybackProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (player.currentMedia != null)
            {
                // Устанавливаем новую позицию воспроизведения
                double newPosition = (double)e.X / playbackProgressBar.Width * player.currentMedia.duration;
                player.controls.currentPosition = newPosition;

                playbackProgressBar.Value = (int)newPosition;
                isUserSeeking = false;
            }
        }

    }
}
