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
        private Image image { get; set; }
        public Vector2D pos = new Vector2D();
        private int posture { get; set; }
        private int frame { get; set; }

        public Character()
        {
            pos = new Vector2D(100, 80);
            frame = 0;
            posture = 1;
        }

        public void uploadImage(string url)
        {
            image = Context.LoadImage(url);
            Program.Resources.Add(image);
        }
        
        // 좌로 뛰기
        public void runLeft()
        {
            posture = 0;
            pos.x -= 2;

            move();
        }

        // 우로 뛰기
        public void runRight()
        {
            posture = 1;
            pos.x += 2;

            move();
        }

        public void stand()
        {
            switch(posture)
            {
                case 0: posture = 2; move(); break;
                case 1: posture = 3; move(); break;
                default: break;
            }
        }

        public void jump()
        {

        }

        public void move()
        {
            switch (posture)
            {
                case 0: pos.x -= 2; break;
                case 1: pos.x += 2; break;
                default: break;
            }

            image.ClipRender(new Rectangle(frame * 100, posture * 100, 100, 100), pos);

            frame = (frame + 1) % 8;

            // 처음 지점 도달-> 우로 뛸 차례
            if (pos.x < 0)
            {
                posture = 1;
            }
            // 끝 지점 도달-> 좌로 뛸 차례
            else if (pos.x > 800)
            {
                posture = 0;
            }
        }
    }
}