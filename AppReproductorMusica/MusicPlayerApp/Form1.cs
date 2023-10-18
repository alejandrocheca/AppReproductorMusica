using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayerApp
{
    public partial class MusicPlayerApp : Form
    {
        private List<string> selectedSongs = new List<string>();
        private List<string> selectedPaths = new List<string>();
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        //Create Global Variables of String Type Array to save the titles or name of the Tracks and path of the track
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
                axWindowsMediaPlayerMusic.URL = selectedPaths[index];
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBoxSongs.Items.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            //Code to Close the App
            this.Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            //Code to minimize the window
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Code to Close the App
            this.Close();
        }
    }
}
