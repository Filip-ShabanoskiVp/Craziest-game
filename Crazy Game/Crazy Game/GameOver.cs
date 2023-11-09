using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crazy_Game
{
    public partial class GameOver : Form
    {
        GamePlay GamePlay;
        public GameOver(int score)
        {
            InitializeComponent();
            lblScore.Text = score.ToString();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            GamePlay = new GamePlay();
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this.Hide();
            GamePlay gamePlay = new GamePlay();
            gamePlay.ShowDialog();
        }
    }
}
