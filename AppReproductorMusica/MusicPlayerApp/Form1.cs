using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace AppReproductorMusica
{
    public partial class AppReproductorMusica : Form
    {
        private bool isDragging = false;
        private int offsetX, offsetY;
        private List<string> selectedSongs = new List<string>();
        private List<string> selectedPaths = new List<string>();
        private Timer songPositionTimer = new Timer();
        private Color defaultButtonColor;

        public AppReproductorMusica()
        {
            InitializeComponent();

            this.MouseDown += AppReproductorMusica_MouseDown;
            this.MouseMove += AppReproductorMusica_MouseMove;
            this.MouseUp += AppReproductorMusica_MouseUp;

            TBarSong.Scroll += TBarSong_Scroll;
            songPositionTimer.Interval = 1000;
            songPositionTimer.Tick += SongPositionTimer_Tick;

            axWindowsMediaPlayerMusic.settings.autoStart = false;
            defaultButtonColor = BtnRepeatSong.BackColor;
        }

        private void AppReproductorMusica_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offsetX = e.X;
                offsetY = e.Y;
            }
        }

        private void AppReproductorMusica_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int newX = this.Left + e.X - offsetX;
                int newY = this.Top + e.Y - offsetY;
                this.Location = new Point(newX, newY);
            }
        }

        private void AppReproductorMusica_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void UpdateSongPosition(int mouseX)
        {
            if (axWindowsMediaPlayerMusic.currentMedia != null)
            {
                int progressBarWidth = TBarSong.Width - 4;
                int newPosition = (int)((mouseX / (double)progressBarWidth) * 100);

                newPosition = Math.Max(TBarSong.Minimum, Math.Min(TBarSong.Maximum, newPosition));

                TBarSong.Value = newPosition;
                double newTime = (newPosition / 100.0) * axWindowsMediaPlayerMusic.currentMedia.duration;
                axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition = newTime;

                LabelCurrentTime.Text = TimeSpan.FromSeconds(newTime).ToString(@"mm\:ss");
                LabelDuration.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.currentMedia.duration).ToString(@"mm\:ss");
            }
        }

        String[] paths, files;

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    string songPath = ofd.FileNames[i];
                    string songTitle = ofd.SafeFileNames[i];

                    if (!IsSongInList(songTitle))
                    {
                        listBoxSongs.Items.Add(songTitle);
                        selectedSongs.Add(songTitle);
                        selectedPaths.Add(songPath);
                    }
                }
            }
        }

        private bool IsSongInList(string songTitle)
        {
            return selectedSongs.Contains(songTitle);
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBoxSongs.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < selectedPaths.Count)
            {
                PlaySelectedSong(selectedIndex);
            }
        }

        private void PlaySelectedSong(int index)
        {
            if (index >= 0 && index < selectedPaths.Count)
            {
                DetenerReproduccion();
                axWindowsMediaPlayerMusic.URL = selectedPaths[index];
                songPositionTimer.Start();
            }
        }

        private void DetenerReproduccion()
        {
            axWindowsMediaPlayerMusic.Ctlcontrols.stop();
            songPositionTimer.Stop();
            TBarSong.Value = 0;
            LabelCurrentTime.Text = "00:00";
            LabelDuration.Text = "00:00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxSongs.Items.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PlayNextSong()
        {
            if (listBoxSongs.Items.Count > 0)
            {
                int selectedIndex = listBoxSongs.SelectedIndex;
                selectedIndex = (selectedIndex + 1) % listBoxSongs.Items.Count;
                listBoxSongs.SelectedIndex = selectedIndex;
                PlaySelectedSong(selectedIndex);
            }
        }

        private void PlayPreviousSong()
        {
            if (listBoxSongs.Items.Count > 0)
            {
                int selectedIndex = listBoxSongs.SelectedIndex;
                selectedIndex = (selectedIndex - 1 + listBoxSongs.Items.Count) % listBoxSongs.Items.Count;
                listBoxSongs.SelectedIndex = selectedIndex;
                PlaySelectedSong(selectedIndex);
            }
        }

        private bool isRepeatingSong = false;
        private bool isRepeatingList = false;

        private void RepeatSong()
        {
            isRepeatingSong = !isRepeatingSong;

            if (isRepeatingSong)
            {
                axWindowsMediaPlayerMusic.settings.setMode("loop", true);
                BtnRepeatSong.BackColor = Color.Green;
            }
            else
            {
                axWindowsMediaPlayerMusic.settings.setMode("loop", false);
                BtnRepeatSong.BackColor = defaultButtonColor;
            }
        }

        private void RepeatPlaylist()
        {
            if (listBoxSongs.Items.Count > 0)
            {
                int lastIndex = listBoxSongs.Items.Count - 1;

                if (listBoxSongs.SelectedIndex == lastIndex && axWindowsMediaPlayerMusic.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
                {
                    listBoxSongs.SelectedIndex = 0;
                    PlaySelectedSong(0);
                }
            }
        }

        private void ContinueCurrentSong()
        {
            axWindowsMediaPlayerMusic.Ctlcontrols.play();
            songPositionTimer.Start();
        }

        private void PauseCurrentSong()
        {
            axWindowsMediaPlayerMusic.Ctlcontrols.pause();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            PlayNextSong();
            ContinueCurrentSong();
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            PlayPreviousSong();
            ContinueCurrentSong();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            PauseCurrentSong();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            ContinueCurrentSong();
        }

        private void BtnRepeatSong_Click(object sender, EventArgs e)
        {
            RepeatSong();
        }

        private void TBarSong_Scroll(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayerMusic.currentMedia != null)
            {
                int newPosition = TBarSong.Value;
                double newTime = (newPosition / 100.0) * axWindowsMediaPlayerMusic.currentMedia.duration;

                axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition = newTime;

                LabelCurrentTime.Text = TimeSpan.FromSeconds(newTime).ToString(@"mm\:ss");
                LabelDuration.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.currentMedia.duration).ToString(@"mm\:ss");
            }
        }

        private void SongPositionTimer_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayerMusic.currentMedia != null)
            {
                int newPosition = (int)((axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition / axWindowsMediaPlayerMusic.currentMedia.duration) * 100);

                if (newPosition < TBarSong.Minimum)
                {
                    TBarSong.Value = TBarSong.Minimum;
                }
                else if (newPosition > TBarSong.Maximum)
                {
                    TBarSong.Value = TBarSong.Maximum;
                }
                else
                {
                    TBarSong.Value = newPosition;
                }

                LabelCurrentTime.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition).ToString(@"mm\:ss");
                LabelDuration.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.currentMedia.duration).ToString(@"mm\:ss");
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            DetenerReproduccion();
        }

        private void TBarVolume_Scroll(object sender, EventArgs e)
        {
            int newVolume = TBarVolume.Value;
            axWindowsMediaPlayerMusic.settings.volume = newVolume;
        }

        private void BtnRepeatList_Click(object sender, EventArgs e)
        {
            isRepeatingList = !isRepeatingList;

            if (isRepeatingList)
            {
                axWindowsMediaPlayerMusic.settings.setMode("loop", true);
                BtnRepeatList.BackColor = Color.Green;
            }
            else
            {
                axWindowsMediaPlayerMusic.settings.setMode("loop", false);
                BtnRepeatList.BackColor = defaultButtonColor;
            }
            RepeatPlaylist();
        }
    }
}
