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
        public AppReproductorMusica()
        {
            InitializeComponent();

            // Agregar los eventos de manejo de eventos de ratón
            this.MouseDown += AppReproductorMusica_MouseDown;
            this.MouseMove += AppReproductorMusica_MouseMove;
            this.MouseUp += AppReproductorMusica_MouseUp;


            TBarSong.Scroll += TBarSong_Scroll;
            songPositionTimer.Interval = 1000; // Actualiza cada segundo (puedes ajustar el intervalo según tus preferencias)
            songPositionTimer.Tick += SongPositionTimer_Tick;

            axWindowsMediaPlayerMusic.settings.autoStart = false; // Deshabilitar la reproducción automática
        }
        // Agregar el evento MouseDown al formulario
        private void AppReproductorMusica_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                offsetX = e.X;
                offsetY = e.Y;
            }
        }

        // Agregar el evento MouseMove al formulario
        private void AppReproductorMusica_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int newX = this.Left + e.X - offsetX;
                int newY = this.Top + e.Y - offsetY;
                this.Location = new Point(newX, newY);
            }
        }

        // Agregar el evento MouseUp al formulario
        private void AppReproductorMusica_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Desactivar el estado de arrastre cuando se suelta el botón del ratón
                isDragging = false;
            }
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
                // Detener la reproducción actual antes de cargar una nueva canción
                DetenerReproduccion();

                // Cargar y reproducir la nueva canción
                axWindowsMediaPlayerMusic.URL = selectedPaths[index];

                // Iniciar la actualización del scroll
                songPositionTimer.Start();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBoxSongs.Items.Clear();
        }
        //
        //Botones de ventana
        //
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
        //
        //botones de reproduccion
        //
        private void PlayNextSong()
        {
            if (listBoxSongs.Items.Count > 0)
            {
                int selectedIndex = listBoxSongs.SelectedIndex;

                // Incrementar el índice para ir a la siguiente canción o volver al principio si se llega al final
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

                // Decrementar el índice para ir a la canción anterior o al final si se está en la primera canción
                selectedIndex = (selectedIndex - 1 + listBoxSongs.Items.Count) % listBoxSongs.Items.Count;

                listBoxSongs.SelectedIndex = selectedIndex;
                PlaySelectedSong(selectedIndex);
            }
        }
        // Función para alternar el estado de repetición (indefinido o desactivado)
        private bool isRepeating = false; // Variable para controlar la repetición
        private Color defaultButtonColor; // Almacena el color por defecto del botón
        private bool isRepeatingSong = false;
        private bool isRepeatingList = false;
        private void RepeatSong()
        {
            isRepeatingSong = !isRepeatingSong; // Alternar el estado de la repetición de la canción

            if (isRepeatingSong)
            {
                // Configura el modo de repetición en bucle
                axWindowsMediaPlayerMusic.settings.setMode("loop", true);
                BtnRepeatSong.BackColor = Color.Green; // Cambiar el color del botón a verde
            }
            else
            {
                // Desactiva el modo de repetición
                axWindowsMediaPlayerMusic.settings.setMode("loop", false);
                BtnRepeatSong.BackColor = defaultButtonColor; // Restaura el color por defecto del botón
            }
        }
        private void RepeatPlaylist()
        {
            if (listBoxSongs.Items.Count > 0)
            {
                // Obtén el índice de la última canción en la lista
                int lastIndex = listBoxSongs.Items.Count - 1;

                // Comprueba si la última canción está siendo reproducida
                if (listBoxSongs.SelectedIndex == lastIndex && axWindowsMediaPlayerMusic.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
                {
                    // Vuelve a la primera canción de la lista
                    listBoxSongs.SelectedIndex = 0;
                    PlaySelectedSong(0);
                }
            }
        }
        private void DetenerReproduccion()
        {
            // Detener la reproducción actual
            axWindowsMediaPlayerMusic.Ctlcontrols.stop();

            // Detener la actualización del scroll
            songPositionTimer.Stop();

            // Reiniciar el control de scroll
            TBarSong.Value = 0;
        }

        private void ContinueCurrentSong()
        {
            // Continuar la reproducción
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
        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            PlayPreviousSong();
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
                // Obtén el valor actual del control TBarSong y ajusta la posición en la canción
                int newPosition = TBarSong.Value;
                double newTime = (newPosition / 100.0) * axWindowsMediaPlayerMusic.currentMedia.duration;

                axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition = newTime; // Establece la posición en la canción

                // Actualiza las etiquetas de tiempo
                LabelCurrentTime.Text = TimeSpan.FromSeconds(newTime).ToString(@"mm\:ss");
                LabelDuration.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.currentMedia.duration).ToString(@"mm\:ss");
            }
        }

        private void SongPositionTimer_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayerMusic.currentMedia != null)
            {
                int newPosition = (int)((axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition / axWindowsMediaPlayerMusic.currentMedia.duration) * 100);

                // Asegúrate de que el valor esté dentro del rango permitido
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

                // Actualiza las etiquetas de tiempo
                LabelCurrentTime.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.Ctlcontrols.currentPosition).ToString(@"mm\:ss");
                LabelDuration.Text = TimeSpan.FromSeconds(axWindowsMediaPlayerMusic.currentMedia.duration).ToString(@"mm\:ss");
            }
        }
        private void TBarVolume_Scroll(object sender, EventArgs e)
        {
            // Obtén el valor actual del control TBarVolume
            int newVolume = TBarVolume.Value;

            // Establece el volumen del reproductor al nuevo valor
            axWindowsMediaPlayerMusic.settings.volume = newVolume;
        }

        private void BtnRepeatList_Click(object sender, EventArgs e)
        {
            isRepeatingList = !isRepeatingList; // Alternar el estado de la repetición de la lista de canciones

            if (isRepeatingList)
            {
                // Configura el modo de repetición en bucle
                axWindowsMediaPlayerMusic.settings.setMode("loop", true);
                BtnRepeatList.BackColor = Color.Green; // Cambiar el color del botón a verde
            }
            else
            {
                // Desactiva el modo de repetición
                axWindowsMediaPlayerMusic.settings.setMode("loop", false);
                BtnRepeatList.BackColor = defaultButtonColor; // Restaura el color por defecto del botón
            }
            RepeatPlaylist();
        } 
    }
}
