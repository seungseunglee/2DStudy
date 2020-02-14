using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jong2D;
using Jong2D.Utility;

namespace _2DStudy
{
    public class Character
    {
        private const int STEP = 5;
        private Image image { get; set; }
        public Vector2D pos = new Vector2D();
        private int posture { get; set; }   // 0:좌-뛰 1:우-뛰 2:좌-서 3:우-서
        private int frame { get; set; }
        private double adjustDelay;


        public Character(int x, int y)
        {
            pos = new Vector2D(x, y);
            frame = 0;
            posture = 1;
        }

        public void uploadImage(string url)
        {
            image = Context.LoadImage(url);
            Program.Resources.Add(image);
        }
        
        // 좌로 달리기
        public void runLeft()
        {
            posture = 0;
        }

        // 우로 달리기
        public void runRight()
        {
            posture = 1;
        }

        // 제자리에 서기
        public void stand()
        {
            switch(posture)
            {
                case 0:
                    posture = 2; move();
                    break;
                case 1:
                    posture = 3; move();
                    break;
                default: break;
            }
        }

        public void jump()
        {
            pos.y += STEP;

        }

        public void move()
        {
            switch (posture)
            {
                case 0: pos.x -= STEP; break;
                case 1: pos.x += STEP; break;
                default: break;
            }

            #region >> 끝까지 도달하면 방향 전환
            // 처음 지점 도달-> 우로 뛸 차례
            if (pos.x <= 30)
            {
                pos.x = 30;
            }
            // 끝 지점 도달-> 좌로 뛸 차례
            else if (pos.x >= 770)
            {
                pos.x = 770;
            }
            #endregion  

            image.ClipRender(new Rectangle(frame * 100, posture * 100, 100, 100), pos);

            frame = (frame + 1) % 8;

        }
    }
}