using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crazy_Game
{
    public class EnemyDoc
    {
        public List<FireBall> fireBalls;
        public int score { get; set; }
        public int EnemyLife { get; set; }
        public List<Enemy> enemies { get; set; }
      
        public EnemyDoc()
        {
            fireBalls = new List<FireBall>();
            score = 0;
            EnemyLife = 3;
            enemies = new List<Enemy>();
        }
        public void addEnemy(Point position)
        {
            Enemy enemy = new Enemy();
            enemy.Position = position;
            enemies.Add(enemy);
        }
        public void Draw(Graphics g)
        {
            foreach (Enemy e in enemies)
            {
                e.Draw(g);
            }
        }
        public void Move(int width)
        {
            foreach (Enemy e in enemies)
            {
                e.Move();
            }
        }
        public void enemyLoseLife()
        {
           EnemyLife--;
        }
        public int getEnemyLife()
        {
            return EnemyLife;
        }
     
    }
}
