using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MusicLocalUI
{
    public partial class MainApp : Form
    {
        private string path_to_music_folder = "";
        private readonly string[] audioExtensions = { ".mp3", ".wav", ".flac", ".aac", ".ogg", ".wma", ".m4a" };
        private string[] allFiles;
        private int totalDurationSeconds = 0;
        private List<string> audioFilesList = new List<string>();
        private List<string> filteredAudioFilesList = new List<string>();
        private List<string> favoriteTracks = new List<string>();
        private List<string> playHistory = new List<string>();
        private int currentHistoryIndex = -1;
        private WindowsMediaPlayer player = new WindowsMediaPlayer();
        private Timer playbackTimer;
        private bool isUserSeeking = false;

        private bool orderSong = true;
        private bool repeatSong = false;
        private bool randomSong = false;
        private bool repeatAll = false;
        private bool isSearchActive = false;
        private string currentPlaylist = "";

        public class AudioMetadata
        {
            public string Title { get; set; }
            public string Artist { get; set; }
            public string Duration { get; set; }
            public string Bitrate { get; set; }
            public string FileExtension { get; set; }
            public string FileSize { get; set; }
            public string CreatedDate { get; set; }
            public string Album { get; set; }
            public string Genre { get; set; }
            public string Year { get; set; }
        }

        public MainApp()
        {
            InitializeComponent();
            playbackProgressBar.ForeColor = Color.DodgerBlue;
            volumeTrackBar.Value = 50;
            player.settings.volume = volumeTrackBar.Value;

            // Инициализация таймера для обновления прогресса
            playbackTimer = new Timer { Interval = 500 };
            playbackTimer.Tick += PlaybackTimer_Tick;
            playbackProgressBar.MouseDown += (s, e) => isUserSeeking = true;
            playbackProgressBar.MouseUp += PlaybackProgressBar_MouseUp;
            player.PlayStateChange += (int newState) =>
            {
                if (newState == (int)WMPPlayState.wmppsMediaEnded)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        NextPlay_Click(null, null);
                    });
                }
                this.Invoke((MethodInvoker)UpdateTimeDisplay);
            };

            // Настройка поиска
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            searchTextBox.Enter += (s, e) => { if (searchTextBox.Text == "Search...") { searchTextBox.Text = ""; searchTextBox.ForeColor = Color.Black; } };
            searchTextBox.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(searchTextBox.Text)) { searchTextBox.Text = "Search..."; searchTextBox.ForeColor = Color.Gray; } };

            // Настройка горячих клавиш
            this.KeyPreview = true;
            this.KeyDown += MainApp_KeyDown;

            // Загрузка настроек
            LoadSettings();
        }

        private void MainApp_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    StartPausePlay_Click(null, null);
                    e.Handled = true;
                    break;
                case Keys.Right:
                    if (e.Control) NextPlay_Click(null, null);
                    else if (e.Shift) SeekForward();
                    e.Handled = true;
                    break;
                case Keys.Left:
                    if (e.Control) PreviousPlay_Click(null, null);
                    else if (e.Shift) SeekBackward();
                    e.Handled = true;
                    break;
                case Keys.F5:
                    scan_folder_Click(null, null);
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    if (!string.IsNullOrEmpty(searchTextBox.Text) && searchTextBox.Text != "Search...")
                    {
                        searchTextBox.Text = "Search...";
                        searchTextBox.ForeColor = Color.Gray;
                    }
                    e.Handled = true;
                    break;
                case Keys.F:
                    if (e.Control) searchTextBox.Focus();
                    e.Handled = true;
                    break;
                case Keys.M:
                    if (e.Control) ToggleMute(null, null);
                    e.Handled = true;
                    break;
                case Keys.L:
                    if (e.Control) LoadPlaylist(null, null);
                    e.Handled = true;
                    break;
                case Keys.S:
                    if (e.Control) SavePlaylist(null, null);
                    e.Handled = true;
                    break;
            }
        }

        private void SeekForward()
        {
            if (player.currentMedia != null)
            {
                double currentPos = player.controls.currentPosition;
                player.controls.currentPosition = Math.Min(currentPos + 10, player.currentMedia.duration);
            }
        }

        private void SeekBackward()
        {
            if (player.currentMedia != null)
            {
                double currentPos = player.controls.currentPosition;
                player.controls.currentPosition = Math.Max(currentPos - 10, 0);
            }
        }

        private void ToggleMute(object sender, EventArgs e)
        {
            player.settings.mute = !player.settings.mute;
            muteButton.Text = player.settings.mute ? "🔇" : "🔊";
        }

        // ПОИСК
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Search..." || string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                isSearchActive = false;
                filteredAudioFilesList.Clear();
                filteredAudioFilesList.AddRange(audioFilesList);
                UpdateMusicListBox();
                searchClearBtn.Visible = false;
            }
            else
            {
                isSearchActive = true;
                searchClearBtn.Visible = true;
                FilterMusicList(searchTextBox.Text.ToLower());
            }
        }

        private void FilterMusicList(string searchText)
        {
            filteredAudioFilesList.Clear();
            for (int i = 0; i < audioFilesList.Count; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(audioFilesList[i]);
                if (fileName.ToLower().Contains(searchText))
                {
                    filteredAudioFilesList.Add(audioFilesList[i]);
                }
            }
            UpdateMusicListBox();
        }

        private void UpdateMusicListBox()
        {
            musicListBox.BeginUpdate();
            musicListBox.Items.Clear();

            var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;

            for (int i = 0; i < displayList.Count; i++)
            {
                string file = displayList[i];
                var (duration, durationString) = GetAudioFileInfo(file);
                string favoriteIndicator = favoriteTracks.Contains(file) ? "❤ " : "";
                musicListBox.Items.Add($"{favoriteIndicator}{Path.GetFileNameWithoutExtension(file)}|||Duration: {durationString}");
            }

            musicListBox.EndUpdate();
            UpdateStatusLabel();
        }

        private void searchClearBtn_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = "Search...";
            searchTextBox.ForeColor = Color.Gray;
            searchClearBtn.Visible = false;
        }

        // СКАНИРОВАНИЕ ПАПКИ
        private async void scan_folder_Click(object sender, EventArgs e)
        {
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
                SetupUIForScanning();

                audioFilesList = Directory.GetFiles(path_to_music_folder, "*.*", SearchOption.AllDirectories)
                    .Where(file => audioExtensions.Contains(Path.GetExtension(file).ToLower()))
                    .ToList();

                filteredAudioFilesList.Clear();
                filteredAudioFilesList.AddRange(audioFilesList);

                scanProgressBar.Maximum = audioFilesList.Count;
                SetupListBox();

                await ProcessAudioFilesAsync();

                UpdateStatusLabel();

                OrderBut.Enabled = true;
                RandomBut.Enabled = true;
                RepeatBut.Enabled = true;
                RepeatAllBut.Enabled = true;

                check_play_method();

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

                var (duration, durationString) = GetAudioFileInfo(file);
                totalDurationSeconds += duration;

                if (!isSearchActive || filteredAudioFilesList.Contains(file))
                {
                    string favoriteIndicator = favoriteTracks.Contains(file) ? "❤ " : "";
                    musicListBox.Items.Add($"{favoriteIndicator}{Path.GetFileNameWithoutExtension(file)}|||Duration: {durationString}");
                }

                if (i % 5 == 0) await Task.Delay(1);
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
                        ? $"{(int)(seconds / 3600):00}:{(int)(seconds / 60) % 60:00}:{(int)seconds % 60:00}"
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

            var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;
            TotalFiles.Text = $"Found: {audioFilesList.Count} tracks (Showing: {displayList.Count})";
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

        // ОТРИСОВКА СПИСКА МУЗЫКИ
        private void DrawMusicListItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var itemText = musicListBox.Items[e.Index]?.ToString() ?? "";
            var parts = itemText.Split(new[] { "|||" }, StringSplitOptions.None);
            var title = parts.Length > 0 ? parts[0] : "";
            var duration = parts.Length > 1 ? parts[1] : "";

            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            var bgColor = isSelected ? Color.FromArgb(51, 153, 255) :
                (e.Index % 2 == 0 ? Color.White : Color.FromArgb(245, 245, 245));
            var textColor = isSelected ? Color.White : Color.Black;

            using (var bgBrush = new SolidBrush(bgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.Bounds);
            }

            e.Graphics.DrawLine(Pens.LightGray, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

            // Название трека (с сердечком для избранных)
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

        // ВОСПРОИЗВЕДЕНИЕ
        private void musicListBox_DoubleClick(object sender, EventArgs e)
        {
            if (musicListBox.SelectedIndex < 0) return;

            var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;

            if (musicListBox.SelectedIndex >= displayList.Count)
                return;

            try
            {
                string filePath = displayList[musicListBox.SelectedIndex];

                if (File.Exists(filePath))
                {
                    PreviousPlay.Enabled = true;
                    NextPlay.Enabled = true;
                    StartPausePlay.Enabled = true;
                    StartPausePlay.Text = "⏸";
                    AddToHistory(filePath);
                    PlayAudioFile(filePath);
                }
                else
                {
                    MessageBox.Show("Audio file not found!", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    audioFilesList.Remove(filePath);
                    filteredAudioFilesList.Remove(filePath);
                    UpdateMusicListBox();
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

                playbackProgressBar.Value = 0;
                playbackTimer.Start();

                var metadata = GetAudioMetadata(filePath);

                TrackDuration.Text = "Duration: " + metadata.Duration;
                TrackBitRate.Text = "Bit rate: " + metadata.Bitrate;
                TrackExtension.Text = "Extension: " + metadata.FileExtension;
                TrackSize.Text = "Size: " + metadata.FileSize;
                TrackCreated.Text = "Created: " + metadata.CreatedDate;
                TrackAlbum.Text = "Album: " + metadata.Album;
                TrackGenre.Text = "Genre: " + metadata.Genre;
                TrackArtist.Text = "Artist: " + metadata.Artist;
                TrackYear.Text = "Year: " + metadata.Year;

                string MusicName = $"Now playing: {Path.GetFileNameWithoutExtension(filePath)}";
                NowPlaying.Text = MusicName.Length > 65
                    ? MusicName.Insert(63, Environment.NewLine + "                     ")
                    : MusicName;

                // Обновляем кнопку избранного
                UpdateFavoriteButton(filePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing file: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddToHistory(string filePath)
        {
            // Удаляем все элементы после текущего индекса
            if (currentHistoryIndex < playHistory.Count - 1)
            {
                playHistory.RemoveRange(currentHistoryIndex + 1, playHistory.Count - currentHistoryIndex - 1);
            }

            playHistory.Add(filePath);
            currentHistoryIndex = playHistory.Count - 1;

            UpdateHistoryButtons();
        }

        private void UpdateHistoryButtons()
        {
            historyBackBtn.Enabled = currentHistoryIndex > 0;
            historyForwardBtn.Enabled = currentHistoryIndex < playHistory.Count - 1;
        }

        // УПРАВЛЕНИЕ ВОСПРОИЗВЕДЕНИЕМ
        private void PreviousPlay_Click(object sender, EventArgs e)
        {
            try
            {
                var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;
                if (displayList.Count == 0) return;

                int currentIndex = musicListBox.SelectedIndex;
                int newIndex = currentIndex <= 0 ? displayList.Count - 1 : currentIndex - 1;

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
                    StartPausePlay.Text = "▶";
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
                    StartPausePlay.Text = "⏸";
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
                var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;
                if (displayList.Count == 0) return;

                int newIndex;
                if (musicListBox.SelectedIndex < 0)
                {
                    newIndex = 0;
                }
                else
                {
                    if (repeatSong)
                    {
                        newIndex = musicListBox.SelectedIndex;
                    }
                    else if (repeatAll && musicListBox.SelectedIndex == displayList.Count - 1)
                    {
                        newIndex = 0;
                    }
                    else
                    {
                        newIndex = (musicListBox.SelectedIndex + 1) % displayList.Count;
                    }
                }

                musicListBox.SelectedIndex = newIndex;
                PlayCurrentSelectedFile();

                musicListBox.TopIndex = Math.Max(0, newIndex - 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing next track: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RandomPlay()
        {
            try
            {
                var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;
                if (displayList.Count == 0) return;

                int newIndex;
                Random rnd = new Random();
                newIndex = rnd.Next(displayList.Count);

                musicListBox.SelectedIndex = newIndex;
                PlayCurrentSelectedFile();

                musicListBox.TopIndex = Math.Max(0, newIndex - 5);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing random track: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlayCurrentSelectedFile()
        {
            var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;

            if (musicListBox.SelectedIndex < 0 || musicListBox.SelectedIndex >= displayList.Count)
                return;

            string filePath = displayList[musicListBox.SelectedIndex];
            if (File.Exists(filePath))
            {
                AddToHistory(filePath);
                PlayAudioFile(filePath);
                StartPausePlay.Text = "⏸";
            }
            else
            {
                MessageBox.Show("File not found: " + Path.GetFileName(filePath), "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ПРОГРЕСС ВОСПРОИЗВЕДЕНИЯ
        private void PlaybackTimer_Tick(object sender, EventArgs e)
        {
            UpdateTimeDisplay();
        }

        private string FormatTime(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);

            return time.TotalHours >= 1
                ? $"{(int)time.TotalHours:00}:{time.Minutes:00}:{time.Seconds:00}"
                : $"{time.Minutes:00}:{time.Seconds:00}";
        }

        private void PlaybackProgressBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (player.currentMedia != null)
            {
                double newPosition = (double)e.X / playbackProgressBar.Width * player.currentMedia.duration;
                player.controls.currentPosition = newPosition;

                playbackProgressBar.Value = (int)newPosition;
                isUserSeeking = false;
            }
        }

        private void UpdateTimeDisplay()
        {
            try
            {
                if (player.currentMedia != null)
                {
                    double currentPos = player.controls.currentPosition;
                    double totalDuration = player.currentMedia.duration;

                    playbackProgressBar.Maximum = (int)totalDuration;
                    playbackProgressBar.Value = (int)currentPos;

                    timeLabel.Text = $"{FormatTime(currentPos)} / {FormatTime(totalDuration)}";

                    if (totalDuration - currentPos < 0.5 && player.playState == WMPPlayState.wmppsPlaying)
                    {
                        if (orderSong)
                        {
                            NextPlay_Click(null, null);
                        }
                        else if (randomSong)
                        {
                            RandomPlay();
                        }
                        else if (repeatSong)
                        {
                            PlayCurrentSelectedFile();
                        }
                        else if (repeatAll)
                        {
                            NextPlay_Click(null, null);
                        }
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки обновления UI
            }
        }

        // МЕТАДАННЫЕ
        public AudioMetadata GetAudioMetadata(string filePath)
        {
            var metadata = new AudioMetadata();
            var fileInfo = new FileInfo(filePath);

            try
            {
                using (var file = TagLib.File.Create(filePath))
                {
                    metadata.Title = file.Tag.Title ?? Path.GetFileNameWithoutExtension(filePath);
                    metadata.Artist = file.Tag.FirstPerformer ?? "Unknown";
                    metadata.Album = file.Tag.Album ?? "Unknown";
                    metadata.Genre = file.Tag.FirstGenre ?? "Unknown";
                    metadata.Year = file.Tag.Year > 0 ? file.Tag.Year.ToString() : "Unknown";

                    TimeSpan duration = file.Properties.Duration;
                    metadata.Duration = duration.TotalHours >= 1
                        ? duration.ToString(@"hh\:mm\:ss")
                        : duration.ToString(@"mm\:ss");

                    metadata.Bitrate = $"{file.Properties.AudioBitrate} kbps";
                }

                metadata.FileExtension = fileInfo.Extension.ToUpper().TrimStart('.');
                metadata.FileSize = FormatFileSize(fileInfo.Length);
                metadata.CreatedDate = fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading metadata: {ex.Message}");
            }

            return metadata;
        }

        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            double len = bytes;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }

        // РЕЖИМЫ ВОСПРОИЗВЕДЕНИЯ
        private void OrderBut_Click(object sender, EventArgs e)
        {
            orderSong = true;
            randomSong = false;
            repeatSong = false;
            repeatAll = false;
            check_play_method();
        }

        private void RandomBut_Click(object sender, EventArgs e)
        {
            randomSong = true;
            orderSong = false;
            repeatSong = false;
            repeatAll = false;
            check_play_method();
        }

        private void RepeatBut_Click(object sender, EventArgs e)
        {
            repeatSong = true;
            orderSong = false;
            randomSong = false;
            repeatAll = false;
            check_play_method();
        }

        private void RepeatAllBut_Click(object sender, EventArgs e)
        {
            repeatAll = true;
            orderSong = false;
            randomSong = false;
            repeatSong = false;
            check_play_method();
        }

        private void check_play_method()
        {
            OrderBut.BackColor = orderSong ? Color.Green : Color.LightGray;
            OrderBut.ForeColor = orderSong ? Color.White : Color.Black;

            RandomBut.BackColor = randomSong ? Color.Green : Color.LightGray;
            RandomBut.ForeColor = randomSong ? Color.White : Color.Black;

            RepeatBut.BackColor = repeatSong ? Color.Green : Color.LightGray;
            RepeatBut.ForeColor = repeatSong ? Color.White : Color.Black;

            RepeatAllBut.BackColor = repeatAll ? Color.Green : Color.LightGray;
            RepeatAllBut.ForeColor = repeatAll ? Color.White : Color.Black;
        }

        // ГРОМКОСТЬ
        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volumeTrackBar.Value;
            volumeLabel.Text = $"Volume: {volumeTrackBar.Value}%";
        }

        // ИСТОРИЯ ВОСПРОИЗВЕДЕНИЯ
        private void historyBackBtn_Click(object sender, EventArgs e)
        {
            if (currentHistoryIndex > 0)
            {
                currentHistoryIndex--;
                string filePath = playHistory[currentHistoryIndex];
                PlayAudioFile(filePath);
                UpdateHistoryButtons();
            }
        }

        private void historyForwardBtn_Click(object sender, EventArgs e)
        {
            if (currentHistoryIndex < playHistory.Count - 1)
            {
                currentHistoryIndex++;
                string filePath = playHistory[currentHistoryIndex];
                PlayAudioFile(filePath);
                UpdateHistoryButtons();
            }
        }

        // ИЗБРАННОЕ
        private void favoriteButton_Click(object sender, EventArgs e)
        {
            if (musicListBox.SelectedIndex >= 0)
            {
                var displayList = isSearchActive ? filteredAudioFilesList : audioFilesList;
                string filePath = displayList[musicListBox.SelectedIndex];

                if (favoriteTracks.Contains(filePath))
                {
                    favoriteTracks.Remove(filePath);
                }
                else
                {
                    favoriteTracks.Add(filePath);
                }

                UpdateMusicListBox();
                UpdateFavoriteButton(filePath);
                SaveFavorites();
            }
        }

        private void UpdateFavoriteButton(string filePath)
        {
            favoriteButton.Text = favoriteTracks.Contains(filePath) ? "❤ Remove Favorite" : "♡ Add Favorite";
        }

        private void showFavoritesButton_Click(object sender, EventArgs e)
        {
            if (showFavoritesButton.Text == "Show Favorites")
            {
                filteredAudioFilesList.Clear();
                filteredAudioFilesList.AddRange(favoriteTracks);
                isSearchActive = true;
                UpdateMusicListBox();
                showFavoritesButton.Text = "Show All";
            }
            else
            {
                filteredAudioFilesList.Clear();
                filteredAudioFilesList.AddRange(audioFilesList);
                isSearchActive = false;
                UpdateMusicListBox();
                showFavoritesButton.Text = "Show Favorites";
            }
        }

        // ПЛЕЙЛИСТЫ
        private void SavePlaylist(object sender, EventArgs e)
        {
            if (audioFilesList.Count == 0) return;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Playlist files (*.m3u)|*.m3u|All files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllLines(saveDialog.FileName, audioFilesList);
                    currentPlaylist = saveDialog.FileName;
                    MessageBox.Show("Playlist saved successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving playlist: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadPlaylist(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Playlist files (*.m3u)|*.m3u|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    audioFilesList = File.ReadAllLines(openDialog.FileName).ToList();
                    filteredAudioFilesList.Clear();
                    filteredAudioFilesList.AddRange(audioFilesList);
                    currentPlaylist = openDialog.FileName;
                    UpdateMusicListBox();
                    MessageBox.Show("Playlist loaded successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading playlist: {ex.Message}", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        // НАСТРОЙКИ
        private void SaveSettings()
        {
            try
            {
                var settings = new Dictionary<string, string>
                {
                    ["Volume"] = volumeTrackBar.Value.ToString(),
                    ["LastFolder"] = path_to_music_folder,
                    ["Favorites"] = string.Join("|", favoriteTracks)
                };

                File.WriteAllLines("settings.ini", settings.Select(x => $"{x.Key}={x.Value}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving settings: {ex.Message}");
            }
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists("settings.ini"))
                {
                    var settings = File.ReadAllLines("settings.ini")
                        .Select(line => line.Split('='))
                        .Where(parts => parts.Length == 2)
                        .ToDictionary(parts => parts[0], parts => parts[1]);

                    if (settings.ContainsKey("Volume"))
                        volumeTrackBar.Value = int.Parse(settings["Volume"]);

                    if (settings.ContainsKey("LastFolder"))
                        path_to_folder.Text = settings["LastFolder"];

                    if (settings.ContainsKey("Favorites"))
                        favoriteTracks = settings["Favorites"].Split('|').Where(f => !string.IsNullOrEmpty(f)).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading settings: {ex.Message}");
            }
        }

        // СИСТЕМНЫЕ ФУНКЦИИ
        private void MainApp_Load(object sender, EventArgs e)
        {
            volumeLabel.Text = $"Volume: {volumeTrackBar.Value}%";
            this.AllowDrop = true;
            this.DragEnter += MainApp_DragEnter;
            this.DragDrop += MainApp_DragDrop;
        }

        private void MainApp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void MainApp_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                if (Directory.Exists(files[0]))
                {
                    path_to_music_folder = files[0];
                    path_to_folder.Text = path_to_music_folder;
                    scan_folder_Click(null, null);
                }
                else if (File.Exists(files[0]) && audioExtensions.Contains(Path.GetExtension(files[0]).ToLower()))
                {
                    // Добавляем отдельный файл в плейлист
                    audioFilesList.Add(files[0]);
                    filteredAudioFilesList.Add(files[0]);
                    UpdateMusicListBox();
                }
            }
        }

        private void SaveFavorites()
        {
            SaveSettings();
        }

        private void select_folder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog
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
            // Можно добавить дополнительные действия при изменении выбора
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveSettings();
            base.OnFormClosing(e);
        }

    }
}