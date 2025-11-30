namespace MusicLocalUI
{
    partial class MainApp
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
            this.musicListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.playbackControlPanel = new System.Windows.Forms.Panel();
            this.favoriteButton = new System.Windows.Forms.Button();
            this.historyForwardBtn = new System.Windows.Forms.Button();
            this.historyBackBtn = new System.Windows.Forms.Button();
            this.savePlaylistBtn = new System.Windows.Forms.Button();
            this.loadPlaylistBtn = new System.Windows.Forms.Button();
            this.showFavoritesButton = new System.Windows.Forms.Button();
            this.RepeatAllBut = new System.Windows.Forms.Button();
            this.OrderBut = new System.Windows.Forms.Button();
            this.RandomBut = new System.Windows.Forms.Button();
            this.RepeatBut = new System.Windows.Forms.Button();
            this.folderStatusLabel = new System.Windows.Forms.Label();
            this.scanningLabel = new System.Windows.Forms.Label();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.scan_folder = new System.Windows.Forms.Button();
            this.scanProgressBar = new System.Windows.Forms.ProgressBar();
            this.select_folder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.path_to_folder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moreInfoButton = new System.Windows.Forms.Button();
            this.TrackSize = new System.Windows.Forms.Label();
            this.TrackBitRate = new System.Windows.Forms.Label();
            this.TrackDuration = new System.Windows.Forms.Label();
            this.TotalTime = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TotalFiles = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NowPlaying = new System.Windows.Forms.Label();
            this.StartPausePlay = new System.Windows.Forms.Button();
            this.NextPlay = new System.Windows.Forms.Button();
            this.PreviousPlay = new System.Windows.Forms.Button();
            this.playbackProgressBar = new System.Windows.Forms.ProgressBar();
            this.timeLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.searchClearBtn = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.volumePanel = new System.Windows.Forms.Panel();
            this.muteButton = new System.Windows.Forms.Button();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.playbackControlPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.volumePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // musicListBox
            // 
            this.musicListBox.FormattingEnabled = true;
            this.musicListBox.HorizontalScrollbar = true;
            this.musicListBox.Location = new System.Drawing.Point(509, 85);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(463, 550);
            this.musicListBox.TabIndex = 0;
            this.musicListBox.SelectedIndexChanged += new System.EventHandler(this.musicListBox_SelectedIndexChanged);
            this.musicListBox.DoubleClick += new System.EventHandler(this.musicListBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Music";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Music Local UI";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.playbackControlPanel);
            this.groupBox1.Controls.Add(this.savePlaylistBtn);
            this.groupBox1.Controls.Add(this.loadPlaylistBtn);
            this.groupBox1.Controls.Add(this.showFavoritesButton);
            this.groupBox1.Controls.Add(this.RepeatAllBut);
            this.groupBox1.Controls.Add(this.OrderBut);
            this.groupBox1.Controls.Add(this.RandomBut);
            this.groupBox1.Controls.Add(this.RepeatBut);
            this.groupBox1.Controls.Add(this.folderStatusLabel);
            this.groupBox1.Controls.Add(this.scanningLabel);
            this.groupBox1.Controls.Add(this.currentFileLabel);
            this.groupBox1.Controls.Add(this.scan_folder);
            this.groupBox1.Controls.Add(this.scanProgressBar);
            this.groupBox1.Controls.Add(this.select_folder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.path_to_folder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 426);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // playbackControlPanel
            // 
            this.playbackControlPanel.Controls.Add(this.favoriteButton);
            this.playbackControlPanel.Controls.Add(this.historyForwardBtn);
            this.playbackControlPanel.Controls.Add(this.historyBackBtn);
            this.playbackControlPanel.Location = new System.Drawing.Point(11, 386);
            this.playbackControlPanel.Name = "playbackControlPanel";
            this.playbackControlPanel.Size = new System.Drawing.Size(473, 37);
            this.playbackControlPanel.TabIndex = 24;
            // 
            // favoriteButton
            // 
            this.favoriteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.favoriteButton.Location = new System.Drawing.Point(161, 6);
            this.favoriteButton.Name = "favoriteButton";
            this.favoriteButton.Size = new System.Drawing.Size(73, 25);
            this.favoriteButton.TabIndex = 2;
            this.favoriteButton.Text = "♡ Favorite";
            this.favoriteButton.UseVisualStyleBackColor = true;
            this.favoriteButton.Click += new System.EventHandler(this.favoriteButton_Click);
            // 
            // historyForwardBtn
            // 
            this.historyForwardBtn.Enabled = false;
            this.historyForwardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyForwardBtn.Location = new System.Drawing.Point(82, 6);
            this.historyForwardBtn.Name = "historyForwardBtn";
            this.historyForwardBtn.Size = new System.Drawing.Size(73, 25);
            this.historyForwardBtn.TabIndex = 1;
            this.historyForwardBtn.Text = "Forward";
            this.historyForwardBtn.UseVisualStyleBackColor = true;
            this.historyForwardBtn.Click += new System.EventHandler(this.historyForwardBtn_Click);
            // 
            // historyBackBtn
            // 
            this.historyBackBtn.Enabled = false;
            this.historyBackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyBackBtn.Location = new System.Drawing.Point(3, 6);
            this.historyBackBtn.Name = "historyBackBtn";
            this.historyBackBtn.Size = new System.Drawing.Size(73, 25);
            this.historyBackBtn.TabIndex = 0;
            this.historyBackBtn.Text = "Back";
            this.historyBackBtn.UseVisualStyleBackColor = true;
            this.historyBackBtn.Click += new System.EventHandler(this.historyBackBtn_Click);
            // 
            // savePlaylistBtn
            // 
            this.savePlaylistBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePlaylistBtn.Location = new System.Drawing.Point(248, 335);
            this.savePlaylistBtn.Name = "savePlaylistBtn";
            this.savePlaylistBtn.Size = new System.Drawing.Size(110, 25);
            this.savePlaylistBtn.TabIndex = 29;
            this.savePlaylistBtn.Text = "Save Playlist";
            this.savePlaylistBtn.UseVisualStyleBackColor = true;
            this.savePlaylistBtn.Click += new System.EventHandler(this.SavePlaylist);
            // 
            // loadPlaylistBtn
            // 
            this.loadPlaylistBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadPlaylistBtn.Location = new System.Drawing.Point(132, 335);
            this.loadPlaylistBtn.Name = "loadPlaylistBtn";
            this.loadPlaylistBtn.Size = new System.Drawing.Size(110, 25);
            this.loadPlaylistBtn.TabIndex = 28;
            this.loadPlaylistBtn.Text = "Load Playlist";
            this.loadPlaylistBtn.UseVisualStyleBackColor = true;
            this.loadPlaylistBtn.Click += new System.EventHandler(this.LoadPlaylist);
            // 
            // showFavoritesButton
            // 
            this.showFavoritesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showFavoritesButton.Location = new System.Drawing.Point(9, 335);
            this.showFavoritesButton.Name = "showFavoritesButton";
            this.showFavoritesButton.Size = new System.Drawing.Size(117, 25);
            this.showFavoritesButton.TabIndex = 27;
            this.showFavoritesButton.Text = "Show Favorites";
            this.showFavoritesButton.UseVisualStyleBackColor = true;
            this.showFavoritesButton.Click += new System.EventHandler(this.showFavoritesButton_Click);
            // 
            // RepeatAllBut
            // 
            this.RepeatAllBut.Enabled = false;
            this.RepeatAllBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatAllBut.Location = new System.Drawing.Point(248, 275);
            this.RepeatAllBut.Name = "RepeatAllBut";
            this.RepeatAllBut.Size = new System.Drawing.Size(91, 25);
            this.RepeatAllBut.TabIndex = 26;
            this.RepeatAllBut.Text = "Repeat All";
            this.RepeatAllBut.UseVisualStyleBackColor = true;
            this.RepeatAllBut.Click += new System.EventHandler(this.RepeatAllBut_Click);
            // 
            // OrderBut
            // 
            this.OrderBut.Enabled = false;
            this.OrderBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBut.Location = new System.Drawing.Point(9, 275);
            this.OrderBut.Name = "OrderBut";
            this.OrderBut.Size = new System.Drawing.Size(75, 25);
            this.OrderBut.TabIndex = 24;
            this.OrderBut.Text = "Order";
            this.OrderBut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.OrderBut.UseVisualStyleBackColor = true;
            this.OrderBut.Click += new System.EventHandler(this.OrderBut_Click);
            // 
            // RandomBut
            // 
            this.RandomBut.Enabled = false;
            this.RandomBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RandomBut.Location = new System.Drawing.Point(90, 275);
            this.RandomBut.Name = "RandomBut";
            this.RandomBut.Size = new System.Drawing.Size(73, 25);
            this.RandomBut.TabIndex = 23;
            this.RandomBut.Text = "Random";
            this.RandomBut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RandomBut.UseVisualStyleBackColor = true;
            this.RandomBut.Click += new System.EventHandler(this.RandomBut_Click);
            // 
            // RepeatBut
            // 
            this.RepeatBut.Enabled = false;
            this.RepeatBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RepeatBut.Location = new System.Drawing.Point(169, 275);
            this.RepeatBut.Name = "RepeatBut";
            this.RepeatBut.Size = new System.Drawing.Size(73, 25);
            this.RepeatBut.TabIndex = 22;
            this.RepeatBut.Text = "Repeat";
            this.RepeatBut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.RepeatBut.UseVisualStyleBackColor = true;
            this.RepeatBut.Click += new System.EventHandler(this.RepeatBut_Click);
            // 
            // folderStatusLabel
            // 
            this.folderStatusLabel.AutoSize = true;
            this.folderStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderStatusLabel.Location = new System.Drawing.Point(8, 121);
            this.folderStatusLabel.Name = "folderStatusLabel";
            this.folderStatusLabel.Size = new System.Drawing.Size(90, 17);
            this.folderStatusLabel.TabIndex = 16;
            this.folderStatusLabel.Text = "Folder status";
            // 
            // scanningLabel
            // 
            this.scanningLabel.AutoSize = true;
            this.scanningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanningLabel.Location = new System.Drawing.Point(8, 196);
            this.scanningLabel.Name = "scanningLabel";
            this.scanningLabel.Size = new System.Drawing.Size(71, 17);
            this.scanningLabel.TabIndex = 15;
            this.scanningLabel.Text = "Scanning:";
            this.scanningLabel.Visible = false;
            // 
            // currentFileLabel
            // 
            this.currentFileLabel.AutoSize = true;
            this.currentFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentFileLabel.Location = new System.Drawing.Point(6, 213);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(0, 17);
            this.currentFileLabel.TabIndex = 14;
            // 
            // scan_folder
            // 
            this.scan_folder.Enabled = false;
            this.scan_folder.Location = new System.Drawing.Point(11, 141);
            this.scan_folder.Name = "scan_folder";
            this.scan_folder.Size = new System.Drawing.Size(75, 23);
            this.scan_folder.TabIndex = 12;
            this.scan_folder.Text = "Scan";
            this.scan_folder.UseVisualStyleBackColor = true;
            this.scan_folder.Click += new System.EventHandler(this.scan_folder_Click);
            // 
            // scanProgressBar
            // 
            this.scanProgressBar.Location = new System.Drawing.Point(11, 170);
            this.scanProgressBar.Name = "scanProgressBar";
            this.scanProgressBar.Size = new System.Drawing.Size(446, 23);
            this.scanProgressBar.Step = 1;
            this.scanProgressBar.TabIndex = 11;
            this.scanProgressBar.Visible = false;
            // 
            // select_folder
            // 
            this.select_folder.Location = new System.Drawing.Point(375, 74);
            this.select_folder.Name = "select_folder";
            this.select_folder.Size = new System.Drawing.Size(75, 23);
            this.select_folder.TabIndex = 7;
            this.select_folder.Text = "Open";
            this.select_folder.UseVisualStyleBackColor = true;
            this.select_folder.Click += new System.EventHandler(this.select_folder_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Path to folder";
            // 
            // path_to_folder
            // 
            this.path_to_folder.Location = new System.Drawing.Point(11, 98);
            this.path_to_folder.Name = "path_to_folder";
            this.path_to_folder.Size = new System.Drawing.Size(439, 20);
            this.path_to_folder.TabIndex = 5;
            this.path_to_folder.TextChanged += new System.EventHandler(this.path_to_folder_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total info";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moreInfoButton);
            this.groupBox2.Controls.Add(this.TrackSize);
            this.groupBox2.Controls.Add(this.TrackBitRate);
            this.groupBox2.Controls.Add(this.TrackDuration);
            this.groupBox2.Controls.Add(this.TotalTime);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TotalFiles);
            this.groupBox2.Location = new System.Drawing.Point(18, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 258);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // moreInfoButton
            // 
            this.moreInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moreInfoButton.Location = new System.Drawing.Point(257, 140);
            this.moreInfoButton.Name = "moreInfoButton";
            this.moreInfoButton.Size = new System.Drawing.Size(75, 23);
            this.moreInfoButton.TabIndex = 25;
            this.moreInfoButton.Text = "More Info";
            this.moreInfoButton.UseVisualStyleBackColor = true;
            this.moreInfoButton.Click += new System.EventHandler(this.moreInfoButton_Click);
            // 
            // TrackSize
            // 
            this.TrackSize.AutoSize = true;
            this.TrackSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackSize.Location = new System.Drawing.Point(257, 85);
            this.TrackSize.Name = "TrackSize";
            this.TrackSize.Size = new System.Drawing.Size(39, 17);
            this.TrackSize.TabIndex = 18;
            this.TrackSize.Text = "Size:";
            // 
            // TrackBitRate
            // 
            this.TrackBitRate.AutoSize = true;
            this.TrackBitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBitRate.Location = new System.Drawing.Point(257, 111);
            this.TrackBitRate.Name = "TrackBitRate";
            this.TrackBitRate.Size = new System.Drawing.Size(57, 17);
            this.TrackBitRate.TabIndex = 16;
            this.TrackBitRate.Text = "Bit rate:";
            // 
            // TrackDuration
            // 
            this.TrackDuration.AutoSize = true;
            this.TrackDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackDuration.Location = new System.Drawing.Point(257, 58);
            this.TrackDuration.Name = "TrackDuration";
            this.TrackDuration.Size = new System.Drawing.Size(66, 17);
            this.TrackDuration.TabIndex = 15;
            this.TrackDuration.Text = "Duration:";
            // 
            // TotalTime
            // 
            this.TotalTime.AutoSize = true;
            this.TotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTime.Location = new System.Drawing.Point(7, 85);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(100, 17);
            this.TotalTime.TabIndex = 14;
            this.TotalTime.Text = "Total duration:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(253, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "Track info";
            // 
            // TotalFiles
            // 
            this.TotalFiles.AutoSize = true;
            this.TotalFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalFiles.Location = new System.Drawing.Point(7, 58);
            this.TotalFiles.Name = "TotalFiles";
            this.TotalFiles.Size = new System.Drawing.Size(52, 17);
            this.TotalFiles.TabIndex = 13;
            this.TotalFiles.Text = "Found:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(806, 739);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "v0.4.0 Made by VL_PLAY Games";
            // 
            // NowPlaying
            // 
            this.NowPlaying.AutoSize = true;
            this.NowPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowPlaying.Location = new System.Drawing.Point(508, 639);
            this.NowPlaying.Name = "NowPlaying";
            this.NowPlaying.Size = new System.Drawing.Size(0, 17);
            this.NowPlaying.TabIndex = 17;
            // 
            // StartPausePlay
            // 
            this.StartPausePlay.Enabled = false;
            this.StartPausePlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPausePlay.Location = new System.Drawing.Point(728, 701);
            this.StartPausePlay.Name = "StartPausePlay";
            this.StartPausePlay.Size = new System.Drawing.Size(63, 25);
            this.StartPausePlay.TabIndex = 18;
            this.StartPausePlay.Text = "⏸";
            this.StartPausePlay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.StartPausePlay.UseVisualStyleBackColor = true;
            this.StartPausePlay.Click += new System.EventHandler(this.StartPausePlay_Click);
            // 
            // NextPlay
            // 
            this.NextPlay.Enabled = false;
            this.NextPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextPlay.Location = new System.Drawing.Point(809, 701);
            this.NextPlay.Name = "NextPlay";
            this.NextPlay.Size = new System.Drawing.Size(76, 25);
            this.NextPlay.TabIndex = 19;
            this.NextPlay.Text = "Next";
            this.NextPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NextPlay.UseVisualStyleBackColor = true;
            this.NextPlay.Click += new System.EventHandler(this.NextPlay_Click);
            // 
            // PreviousPlay
            // 
            this.PreviousPlay.Enabled = false;
            this.PreviousPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PreviousPlay.Location = new System.Drawing.Point(630, 701);
            this.PreviousPlay.Name = "PreviousPlay";
            this.PreviousPlay.Size = new System.Drawing.Size(73, 25);
            this.PreviousPlay.TabIndex = 20;
            this.PreviousPlay.Text = "Previous";
            this.PreviousPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PreviousPlay.UseVisualStyleBackColor = true;
            this.PreviousPlay.Click += new System.EventHandler(this.PreviousPlay_Click);
            // 
            // playbackProgressBar
            // 
            this.playbackProgressBar.Location = new System.Drawing.Point(616, 682);
            this.playbackProgressBar.Name = "playbackProgressBar";
            this.playbackProgressBar.Size = new System.Drawing.Size(356, 10);
            this.playbackProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.playbackProgressBar.TabIndex = 21;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(508, 682);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(102, 13);
            this.timeLabel.TabIndex = 17;
            this.timeLabel.Text = "00:00:00 / 00:00:00";
            // 
            // searchPanel
            // 
            this.searchPanel.Controls.Add(this.searchClearBtn);
            this.searchPanel.Controls.Add(this.searchTextBox);
            this.searchPanel.Location = new System.Drawing.Point(509, 47);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(463, 32);
            this.searchPanel.TabIndex = 22;
            // 
            // searchClearBtn
            // 
            this.searchClearBtn.Location = new System.Drawing.Point(388, 5);
            this.searchClearBtn.Name = "searchClearBtn";
            this.searchClearBtn.Size = new System.Drawing.Size(75, 23);
            this.searchClearBtn.TabIndex = 1;
            this.searchClearBtn.Text = "Clear";
            this.searchClearBtn.UseVisualStyleBackColor = true;
            this.searchClearBtn.Visible = false;
            this.searchClearBtn.Click += new System.EventHandler(this.searchClearBtn_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.ForeColor = System.Drawing.Color.Gray;
            this.searchTextBox.Location = new System.Drawing.Point(5, 5);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(377, 23);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.Text = "Search...";
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // volumePanel
            // 
            this.volumePanel.Controls.Add(this.muteButton);
            this.volumePanel.Controls.Add(this.volumeLabel);
            this.volumePanel.Controls.Add(this.volumeTrackBar);
            this.volumePanel.Location = new System.Drawing.Point(509, 701);
            this.volumePanel.Name = "volumePanel";
            this.volumePanel.Size = new System.Drawing.Size(115, 60);
            this.volumePanel.TabIndex = 23;
            // 
            // muteButton
            // 
            this.muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButton.Location = new System.Drawing.Point(84, 3);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(25, 20);
            this.muteButton.TabIndex = 2;
            this.muteButton.Text = "🔊";
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.ToggleMute);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeLabel.Location = new System.Drawing.Point(3, 5);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(45, 13);
            this.volumeLabel.TabIndex = 1;
            this.volumeLabel.Text = "Volume:";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(6, 21);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(104, 45);
            this.volumeTrackBar.TabIndex = 0;
            this.volumeTrackBar.TickFrequency = 10;
            this.volumeTrackBar.Value = 50;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.volumePanel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.playbackProgressBar);
            this.Controls.Add(this.PreviousPlay);
            this.Controls.Add(this.NextPlay);
            this.Controls.Add(this.StartPausePlay);
            this.Controls.Add(this.NowPlaying);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.musicListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "MainApp";
            this.Text = "Music Local UI";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainApp_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainApp_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.playbackControlPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.volumePanel.ResumeLayout(false);
            this.volumePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox musicListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox path_to_folder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button select_folder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar scanProgressBar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button scan_folder;
        private System.Windows.Forms.Label TotalFiles;
        private System.Windows.Forms.Label currentFileLabel;
        private System.Windows.Forms.Label scanningLabel;
        private System.Windows.Forms.Label folderStatusLabel;
        private System.Windows.Forms.Label TotalTime;
        private System.Windows.Forms.Label NowPlaying;
        private System.Windows.Forms.Button StartPausePlay;
        private System.Windows.Forms.Button NextPlay;
        private System.Windows.Forms.Button PreviousPlay;
        private System.Windows.Forms.ProgressBar playbackProgressBar;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label TrackBitRate;
        private System.Windows.Forms.Label TrackDuration;
        private System.Windows.Forms.Label TrackSize;
        private System.Windows.Forms.Button RepeatBut;
        private System.Windows.Forms.Button RandomBut;
        private System.Windows.Forms.Button OrderBut;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.Button searchClearBtn;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel volumePanel;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.Button RepeatAllBut;
        private System.Windows.Forms.Button showFavoritesButton;
        private System.Windows.Forms.Button loadPlaylistBtn;
        private System.Windows.Forms.Button savePlaylistBtn;
        private System.Windows.Forms.Panel playbackControlPanel;
        private System.Windows.Forms.Button historyBackBtn;
        private System.Windows.Forms.Button historyForwardBtn;
        private System.Windows.Forms.Button favoriteButton;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button moreInfoButton;
    }
}