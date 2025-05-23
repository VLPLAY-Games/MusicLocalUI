﻿namespace MusicLocalUI
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
            this.OrderBut = new System.Windows.Forms.Button();
            this.RandomBut = new System.Windows.Forms.Button();
            this.RepeatBut = new System.Windows.Forms.Button();
            this.folderStatusLabel = new System.Windows.Forms.Label();
            this.scanningLabel = new System.Windows.Forms.Label();
            this.currentFileLabel = new System.Windows.Forms.Label();
            this.scan_folder = new System.Windows.Forms.Button();
            this.scanProgressBar = new System.Windows.Forms.ProgressBar();
            this.ChangeLangEN = new System.Windows.Forms.Button();
            this.ChangeLangRU = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.select_folder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.path_to_folder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TrackCreated = new System.Windows.Forms.Label();
            this.TrackSize = new System.Windows.Forms.Label();
            this.TrackExtension = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainApp_KeyDown);
            // 
            // musicListBox
            // 
            this.musicListBox.FormattingEnabled = true;
            this.musicListBox.HorizontalScrollbar = true;
            this.musicListBox.Location = new System.Drawing.Point(509, 47);
            this.musicListBox.Name = "musicListBox";
            this.musicListBox.Size = new System.Drawing.Size(463, 589);
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
            this.groupBox1.Controls.Add(this.OrderBut);
            this.groupBox1.Controls.Add(this.RandomBut);
            this.groupBox1.Controls.Add(this.RepeatBut);
            this.groupBox1.Controls.Add(this.folderStatusLabel);
            this.groupBox1.Controls.Add(this.scanningLabel);
            this.groupBox1.Controls.Add(this.currentFileLabel);
            this.groupBox1.Controls.Add(this.scan_folder);
            this.groupBox1.Controls.Add(this.scanProgressBar);
            this.groupBox1.Controls.Add(this.ChangeLangEN);
            this.groupBox1.Controls.Add(this.ChangeLangRU);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.select_folder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.path_to_folder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(18, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 430);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // OrderBut
            // 
            this.OrderBut.Enabled = false;
            this.OrderBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBut.Location = new System.Drawing.Point(11, 179);
            this.OrderBut.Name = "OrderBut";
            this.OrderBut.Size = new System.Drawing.Size(73, 25);
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
            this.RandomBut.Location = new System.Drawing.Point(90, 179);
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
            this.RepeatBut.Location = new System.Drawing.Point(169, 179);
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
            this.scanningLabel.Location = new System.Drawing.Point(8, 362);
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
            this.currentFileLabel.Location = new System.Drawing.Point(6, 379);
            this.currentFileLabel.Name = "currentFileLabel";
            this.currentFileLabel.Size = new System.Drawing.Size(0, 17);
            this.currentFileLabel.TabIndex = 14;
            // 
            // scan_folder
            // 
            this.scan_folder.Enabled = false;
            this.scan_folder.Location = new System.Drawing.Point(11, 307);
            this.scan_folder.Name = "scan_folder";
            this.scan_folder.Size = new System.Drawing.Size(75, 23);
            this.scan_folder.TabIndex = 12;
            this.scan_folder.Text = "Scan";
            this.scan_folder.UseVisualStyleBackColor = true;
            this.scan_folder.Click += new System.EventHandler(this.scan_folder_Click);
            // 
            // scanProgressBar
            // 
            this.scanProgressBar.Location = new System.Drawing.Point(11, 336);
            this.scanProgressBar.Name = "scanProgressBar";
            this.scanProgressBar.Size = new System.Drawing.Size(446, 23);
            this.scanProgressBar.Step = 1;
            this.scanProgressBar.TabIndex = 11;
            this.scanProgressBar.Visible = false;
            // 
            // ChangeLangEN
            // 
            this.ChangeLangEN.Enabled = false;
            this.ChangeLangEN.Location = new System.Drawing.Point(410, 17);
            this.ChangeLangEN.Name = "ChangeLangEN";
            this.ChangeLangEN.Size = new System.Drawing.Size(47, 23);
            this.ChangeLangEN.TabIndex = 10;
            this.ChangeLangEN.Text = "EN";
            this.ChangeLangEN.UseVisualStyleBackColor = true;
            // 
            // ChangeLangRU
            // 
            this.ChangeLangRU.Enabled = false;
            this.ChangeLangRU.Location = new System.Drawing.Point(357, 17);
            this.ChangeLangRU.Name = "ChangeLangRU";
            this.ChangeLangRU.Size = new System.Drawing.Size(47, 23);
            this.ChangeLangRU.TabIndex = 9;
            this.ChangeLangRU.Text = "RU";
            this.ChangeLangRU.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(256, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 24);
            this.label6.TabIndex = 8;
            this.label6.Text = "Language";
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
            this.groupBox2.Controls.Add(this.TrackCreated);
            this.groupBox2.Controls.Add(this.TrackSize);
            this.groupBox2.Controls.Add(this.TrackExtension);
            this.groupBox2.Controls.Add(this.TrackBitRate);
            this.groupBox2.Controls.Add(this.TrackDuration);
            this.groupBox2.Controls.Add(this.TotalTime);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.TotalFiles);
            this.groupBox2.Location = new System.Drawing.Point(18, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 242);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // TrackCreated
            // 
            this.TrackCreated.AutoSize = true;
            this.TrackCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackCreated.Location = new System.Drawing.Point(256, 172);
            this.TrackCreated.Name = "TrackCreated";
            this.TrackCreated.Size = new System.Drawing.Size(70, 20);
            this.TrackCreated.TabIndex = 19;
            this.TrackCreated.Text = "Created:";
            // 
            // TrackSize
            // 
            this.TrackSize.AutoSize = true;
            this.TrackSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackSize.Location = new System.Drawing.Point(256, 143);
            this.TrackSize.Name = "TrackSize";
            this.TrackSize.Size = new System.Drawing.Size(44, 20);
            this.TrackSize.TabIndex = 18;
            this.TrackSize.Text = "Size:";
            // 
            // TrackExtension
            // 
            this.TrackExtension.AutoSize = true;
            this.TrackExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackExtension.Location = new System.Drawing.Point(256, 114);
            this.TrackExtension.Name = "TrackExtension";
            this.TrackExtension.Size = new System.Drawing.Size(83, 20);
            this.TrackExtension.TabIndex = 17;
            this.TrackExtension.Text = "Extension:";
            // 
            // TrackBitRate
            // 
            this.TrackBitRate.AutoSize = true;
            this.TrackBitRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBitRate.Location = new System.Drawing.Point(256, 85);
            this.TrackBitRate.Name = "TrackBitRate";
            this.TrackBitRate.Size = new System.Drawing.Size(64, 20);
            this.TrackBitRate.TabIndex = 16;
            this.TrackBitRate.Text = "Bit rate:";
            // 
            // TrackDuration
            // 
            this.TrackDuration.AutoSize = true;
            this.TrackDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackDuration.Location = new System.Drawing.Point(256, 58);
            this.TrackDuration.Name = "TrackDuration";
            this.TrackDuration.Size = new System.Drawing.Size(74, 20);
            this.TrackDuration.TabIndex = 15;
            this.TrackDuration.Text = "Duration:";
            // 
            // TotalTime
            // 
            this.TotalTime.AutoSize = true;
            this.TotalTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTime.Location = new System.Drawing.Point(7, 85);
            this.TotalTime.Name = "TotalTime";
            this.TotalTime.Size = new System.Drawing.Size(110, 20);
            this.TotalTime.TabIndex = 14;
            this.TotalTime.Text = "Total duration:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(254, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 29);
            this.label8.TabIndex = 5;
            this.label8.Text = "Track info";
            // 
            // TotalFiles
            // 
            this.TotalFiles.AutoSize = true;
            this.TotalFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalFiles.Location = new System.Drawing.Point(7, 58);
            this.TotalFiles.Name = "TotalFiles";
            this.TotalFiles.Size = new System.Drawing.Size(59, 20);
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
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Button ChangeLangEN;
        private System.Windows.Forms.Button ChangeLangRU;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.Label TrackExtension;
        private System.Windows.Forms.Label TrackBitRate;
        private System.Windows.Forms.Label TrackDuration;
        private System.Windows.Forms.Label TrackSize;
        private System.Windows.Forms.Label TrackCreated;
        private System.Windows.Forms.Button RepeatBut;
        private System.Windows.Forms.Button RandomBut;
        private System.Windows.Forms.Button OrderBut;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

