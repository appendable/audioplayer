using System;
using System.Windows.Media;
using System.Windows.Forms;

namespace AudioFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
            private MediaPlayer m_mediaPlayer;

            public void Play(string filename)
            {
                if (m_mediaPlayer != null && m_mediaPlayer.Position.TotalSeconds > 0)
            {
                m_mediaPlayer.Play();
            } else
            {
                m_mediaPlayer = new MediaPlayer();
                m_mediaPlayer.Open(new Uri(filename));
                m_mediaPlayer.Play();
            }
         }

            public void SetVolume(int volume)
            {
                if (m_mediaPlayer != null)
            {
                m_mediaPlayer.Volume = volume / 100.0f;
            } else
            {
                MessageBox.Show("You must play something before you can set the volume of the player.", "Error", MessageBoxButtons.OK);
            }
            }

        private string path;

        private void stopWav()
        {
            try
            {
                if (m_mediaPlayer == null)
                {
                    MessageBox.Show("Nothing is playing.", "Error", MessageBoxButtons.OK);
                    return;
                } else
                {
                    m_mediaPlayer.Stop();
                }
                
            } catch
            {
                MessageBox.Show("Nothing is playing.", "Error", MessageBoxButtons.OK);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

                if (path != null)
                {
                    Play(path);
                }
                else
                {
                    MessageBox.Show("You must choose a file to play.", "Error", MessageBoxButtons.OK);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            stopWav();
            m_mediaPlayer = null;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
            }
            else
            {
                MessageBox.Show("An error occurred", "An error occurred", MessageBoxButtons.OK);
                return;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            chooseFile();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_mediaPlayer == null)
                {
                    MessageBox.Show("Nothing is playing.", "Error", MessageBoxButtons.OK);
                    return;
                } else
                {
                    m_mediaPlayer.Pause();
                }
            } catch
            {
                MessageBox.Show("An error occurred.", "Error", MessageBoxButtons.OK);
            }
        }

        private void guna2TrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            SetVolume(guna2TrackBar1.Value);
        }

        private void guna2ProgressBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
