using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crazy_Game
{
    public partial class Form1 : Form
    {
        SoundPlayer music;
        public bool Music { get; set; }
        public Form1()
        {
            InitializeComponent();
            music = new SoundPlayer(global::Crazy_Game.Properties.Resources.Soundtrack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Music = true;
            music.PlayLooping();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Quiting_game quitting = new Quiting_game();
            if(quitting.ShowDialog()==System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
           
        }

        

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            How_to_play how_To_Play = new How_to_play();
            how_To_Play.ShowDialog();
            this.Show();
        }

        private void btnPlayNow_Click(object sender, EventArgs e)
        {
            this.Hide();
            GamePlay gamePlay = new GamePlay();
            gamePlay.ShowDialog();
            music.Stop();
         
        }

        private void SoundImg_Click(object sender, EventArgs e)
        {
            music.Stop();
            Music= !Music;
            if(Music)
            {
                music.PlayLooping();
                SoundImg.Image = Properties.Resources.soundOn;
            }
            else
            {
                SoundImg.Image = Properties.Resources.soundOff;
            }
        }
    }
}
