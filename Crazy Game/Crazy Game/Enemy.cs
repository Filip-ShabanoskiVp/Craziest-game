using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Game
{
   public class Enemy
    {
       
        public int Radius = 30;
        public Point Position { get; set; }
        public Image ImageEnemy { get; set; }
        public Image ImageEnemyScary { get; set; }
        public Image ImageEnemyGhost { get; set; }
       public Image ImageEnemyGhotsPurple { get; set; }
    
        public int DifferentEnemies { get; set; }
        public Enemy()
        {
      
            ImageEnemy = Properties.Resources.enemyRight;
            ImageEnemyScary = Properties.Resources.enemyScary;
            ImageEnemyGhost = Properties.Resources.ghost;
            ImageEnemyGhotsPurple = Properties.Resources.ghostPurple;
            ImageEnemy.Tag = "EnemyPic";
            ImageEnemyScary.Tag = "EnemyPic";
            ImageEnemyGhost.Tag = "EnemyPic";
            ImageEnemyGhotsPurple.Tag = "EnemyPic";
            Random r = new Random();
            DifferentEnemies = r.Next(5);
        }
        public void Move()
        {
            Position = new Point(Position.X + 10, Position.Y);
        }

        public void Draw(Graphics g)
        {

            if (DifferentEnemies == 0)
            {
                g.DrawImage(ImageEnemy, Position.X - Radius, Position.Y - Radius, 50, 50);
            }
            else if (DifferentEnemies == 1)
            {
                g.DrawImage(ImageEnemyScary, Position.X - Radius, Position.Y - Radius, 93, 93);
            }
            else if (DifferentEnemies == 2)
            {
                g.DrawImage(ImageEnemyGhost, Position.X - Radius, Position.Y - Radius, 50, 50);
            }
            else if (DifferentEnemies == 3)
            {
                g.DrawImage(ImageEnemyGhotsPurple, Position.X - Radius, Position.Y - Radius, 50, 50);
            }

        }
        public Image getEnemyImage()
        {
            if (DifferentEnemies == 0)
            {
                return ImageEnemy;
            }
            else if (DifferentEnemies == 1)
            {
                return ImageEnemyScary;
            }
            else if (DifferentEnemies == 2)
            {
                return ImageEnemyGhost;
            }
            else 
            {
                return ImageEnemyGhotsPurple;
            }
        }
        
    }
}
