namespace AppReproductorMusica
{
    partial class AppReproductorMusica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppReproductorMusica));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.btnSelectSongs = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayerMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnNext = new System.Windows.Forms.Button();
            this.BtnPrevious = new System.Windows.Forms.Button();
            this.BtnPause = new System.Windows.Forms.Button();
            this.BtnPlay = new System.Windows.Forms.Button();
            this.BtnRepeatSong = new System.Windows.Forms.Button();
            this.BtnRepeatList = new System.Windows.Forms.Button();
            this.TBarSong = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LabelDuration = new System.Windows.Forms.Label();
            this.LabelCurrentTime = new System.Windows.Forms.Label();
            this.TBarVolume = new System.Windows.Forms.TrackBar();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarSong)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.PaleTurquoise;
            this.TopPanel.Controls.Add(this.BtnMinimize);
            this.TopPanel.Controls.Add(this.BtnClose);
            this.TopPanel.Controls.Add(this.lblLogo);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(680, 35);
            this.TopPanel.TabIndex = 0;
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.Red;
            this.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnMinimize.ForeColor = System.Drawing.Color.White;
            this.BtnMinimize.Location = new System.Drawing.Point(569, 0);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(54, 31);
            this.BtnMinimize.TabIndex = 7;
            this.BtnMinimize.Text = "-";
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.Red;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(623, 0);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(54, 31);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.Text = "X";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogo.Location = new System.Drawing.Point(21, 10);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(156, 16);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "App Reproductor Música";
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.ItemHeight = 16;
            this.listBoxSongs.Location = new System.Drawing.Point(485, 52);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(183, 244);
            this.listBoxSongs.TabIndex = 1;
            this.listBoxSongs.SelectedIndexChanged += new System.EventHandler(this.listBoxSongs_SelectedIndexChanged);
            // 
            // btnSelectSongs
            // 
            this.btnSelectSongs.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSelectSongs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectSongs.ForeColor = System.Drawing.Color.White;
            this.btnSelectSongs.Location = new System.Drawing.Point(485, 303);
            this.btnSelectSongs.Name = "btnSelectSongs";
            this.btnSelectSongs.Size = new System.Drawing.Size(183, 31);
            this.btnSelectSongs.TabIndex = 2;
            this.btnSelectSongs.Text = "Seleccionar Canciones";
            this.btnSelectSongs.UseVisualStyleBackColor = false;
            this.btnSelectSongs.Click += new System.EventHandler(this.btnSelectSongs_Click);
            // 
            // axWindowsMediaPlayerMusic
            // 
            this.axWindowsMediaPlayerMusic.Enabled = true;
            this.axWindowsMediaPlayerMusic.Location = new System.Drawing.Point(10, 52);
            this.axWindowsMediaPlayerMusic.Name = "axWindowsMediaPlayerMusic";
            this.axWindowsMediaPlayerMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayerMusic.OcxState")));
            this.axWindowsMediaPlayerMusic.Size = new System.Drawing.Size(0, 0);
            this.axWindowsMediaPlayerMusic.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(485, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Eliminar Canciones";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BtnNext
            // 
            this.BtnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(167, 60);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(45, 39);
            this.BtnNext.TabIndex = 6;
            this.BtnNext.Text = "»";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // BtnPrevious
            // 
            this.BtnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrevious.Location = new System.Drawing.Point(11, 60);
            this.BtnPrevious.Name = "BtnPrevious";
            this.BtnPrevious.Size = new System.Drawing.Size(46, 39);
            this.BtnPrevious.TabIndex = 7;
            this.BtnPrevious.Text = "«";
            this.BtnPrevious.UseVisualStyleBackColor = true;
            this.BtnPrevious.Click += new System.EventHandler(this.BtnPrevious_Click);
            // 
            // BtnPause
            // 
            this.BtnPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BtnPause.Location = new System.Drawing.Point(114, 60);
            this.BtnPause.Name = "BtnPause";
            this.BtnPause.Size = new System.Drawing.Size(47, 39);
            this.BtnPause.TabIndex = 8;
            this.BtnPause.Text = "||";
            this.BtnPause.UseVisualStyleBackColor = true;
            this.BtnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // BtnPlay
            // 
            this.BtnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlay.Location = new System.Drawing.Point(63, 60);
            this.BtnPlay.Name = "BtnPlay";
            this.BtnPlay.Size = new System.Drawing.Size(45, 39);
            this.BtnPlay.TabIndex = 9;
            this.BtnPlay.Text = "►";
            this.BtnPlay.UseVisualStyleBackColor = true;
            this.BtnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            // 
            // BtnRepeatSong
            // 
            this.BtnRepeatSong.Location = new System.Drawing.Point(218, 60);
            this.BtnRepeatSong.Name = "BtnRepeatSong";
            this.BtnRepeatSong.Size = new System.Drawing.Size(54, 39);
            this.BtnRepeatSong.TabIndex = 10;
            this.BtnRepeatSong.Text = "Repetir";
            this.BtnRepeatSong.UseVisualStyleBackColor = true;
            this.BtnRepeatSong.Click += new System.EventHandler(this.BtnRepeatSong_Click);
            // 
            // BtnRepeatList
            // 
            this.BtnRepeatList.Location = new System.Drawing.Point(278, 60);
            this.BtnRepeatList.Name = "BtnRepeatList";
            this.BtnRepeatList.Size = new System.Drawing.Size(69, 39);
            this.BtnRepeatList.TabIndex = 11;
            this.BtnRepeatList.Text = "Repetir Lista";
            this.BtnRepeatList.UseVisualStyleBackColor = true;
            this.BtnRepeatList.Click += new System.EventHandler(this.BtnRepeatList_Click);
            // 
            // TBarSong
            // 
            this.TBarSong.LargeChange = 1;
            this.TBarSong.Location = new System.Drawing.Point(43, 11);
            this.TBarSong.Maximum = 100;
            this.TBarSong.Name = "TBarSong";
            this.TBarSong.Size = new System.Drawing.Size(389, 45);
            this.TBarSong.TabIndex = 12;
            this.TBarSong.Scroll += new System.EventHandler(this.TBarSong_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TBarVolume);
            this.panel1.Controls.Add(this.LabelDuration);
            this.panel1.Controls.Add(this.LabelCurrentTime);
            this.panel1.Controls.Add(this.TBarSong);
            this.panel1.Controls.Add(this.BtnRepeatList);
            this.panel1.Controls.Add(this.BtnPause);
            this.panel1.Controls.Add(this.BtnRepeatSong);
            this.panel1.Controls.Add(this.BtnNext);
            this.panel1.Controls.Add(this.BtnPlay);
            this.panel1.Controls.Add(this.BtnPrevious);
            this.panel1.Location = new System.Drawing.Point(0, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(479, 109);
            this.panel1.TabIndex = 13;
            // 
            // LabelDuration
            // 
            this.LabelDuration.AutoSize = true;
            this.LabelDuration.Location = new System.Drawing.Point(438, 14);
            this.LabelDuration.Name = "LabelDuration";
            this.LabelDuration.Size = new System.Drawing.Size(34, 13);
            this.LabelDuration.TabIndex = 15;
            this.LabelDuration.Text = "00:00";
            // 
            // LabelCurrentTime
            // 
            this.LabelCurrentTime.AutoSize = true;
            this.LabelCurrentTime.Location = new System.Drawing.Point(3, 14);
            this.LabelCurrentTime.Name = "LabelCurrentTime";
            this.LabelCurrentTime.Size = new System.Drawing.Size(34, 13);
            this.LabelCurrentTime.TabIndex = 14;
            this.LabelCurrentTime.Text = "00:00";
            // 
            // TBarVolume
            // 
            this.TBarVolume.BackColor = System.Drawing.SystemColors.Control;
            this.TBarVolume.CausesValidation = false;
            this.TBarVolume.LargeChange = 1;
            this.TBarVolume.Location = new System.Drawing.Point(353, 60);
            this.TBarVolume.Maximum = 100;
            this.TBarVolume.Name = "TBarVolume";
            this.TBarVolume.Size = new System.Drawing.Size(119, 45);
            this.TBarVolume.TabIndex = 16;
            this.TBarVolume.Value = 100;
            this.TBarVolume.Scroll += new System.EventHandler(this.TBarVolume_Scroll);
            // 
            // AppReproductorMusica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 387);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axWindowsMediaPlayerMusic);
            this.Controls.Add(this.btnSelectSongs);
            this.Controls.Add(this.listBoxSongs);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppReproductorMusica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Player App";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayerMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TBarSong)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBarVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.ListBox listBoxSongs;
        private System.Windows.Forms.Button btnSelectSongs;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayerMusic;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnMinimize;
        private System.Windows.Forms.Button BtnNext;
        private System.Windows.Forms.Button BtnPrevious;
        private System.Windows.Forms.Button BtnPause;
        private System.Windows.Forms.Button BtnPlay;
        private System.Windows.Forms.Button BtnRepeatSong;
        private System.Windows.Forms.Button BtnRepeatList;
        private System.Windows.Forms.TrackBar TBarSong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelCurrentTime;
        private System.Windows.Forms.Label LabelDuration;
        private System.Windows.Forms.TrackBar TBarVolume;
    }
}

