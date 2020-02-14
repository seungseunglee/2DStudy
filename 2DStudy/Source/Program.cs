using Jong2D;
using Jong2D.Utility;
using SDL2;
using System;
using System.Collections.Generic;
using System.Threading;

namespace _2DStudy
{
    //string baseDir = @"..\..\..\Resources\";
    //Font font = Context.LoadFont(baseDir + "ConsolaMalgun.TTF", 16);
    //Image grass = Context.LoadImage(baseDir + "grass.png");
    //Image character = Context.LoadImage(baseDir + "run_animation.png");
    //Music music = Context.LoadMusic(baseDir + "background.mp3");

    public class Program
    {
        //Screen dimension constants
        private static Character[] character = new Character[2];
        private const double delay = 0.1;
        private static double adjustDelay = 0.0;
        private const int SCREEN_WIDTH = 800;
        private const int SCREEN_HEIGHT = 480;
        private static bool CloseGame { get; set; }

        static void HandleEvents()
        {
            var events = Context.GetGameEvents();
            foreach (GameEvent e in events)
            {
                Console.WriteLine(e.Type);
                switch (e.Type)
                {
                    // 키보드 처리
                    case SDL.SDL_EventType.SDL_KEYDOWN:
                        {
                            Console.WriteLine(e.Key);
                            if (e.Key == SDL.SDL_Keycode.SDLK_RIGHT)
                            {
                                // 우측 이동
                                adjustDelay = 0.05;
                                character[0].runRight();
                            }
                            else if (e.Key == SDL.SDL_Keycode.SDLK_LEFT)
                            {
                                // 왼쪽 이동
                                adjustDelay = 0.05;
                                character[0].runLeft();
                            }
                            else if (e.Key == SDL.SDL_Keycode.SDLK_UP)
                            {
                                // 제자리에 서기
                                character[0].stand();
                            }
                            else if (e.Key == SDL.SDL_Keycode.SDLK_SPACE)
                            {
                                // 점프 하기
                                character[0].jump();
                            }
                            /*else if (e.Key == SDL.SDL_Keycode.SDLK_g)
                            {
                                // 우측 이동
                                delay = 0.05;
                                character[1].runRight();
                            }
                            else if (e.Key == SDL.SDL_Keycode.SDLK_d)
                            {
                                // 왼쪽 이동
                                delay = 0.05;
                                character[1].runLeft();
                            }
                            else if (e.Key == SDL.SDL_Keycode.SDLK_r)
                            {
                                // 제자리에 서기
                                character[1].stand();
                            }*/
                            else if (e.Key == SDL.SDL_Keycode.SDLK_ESCAPE)
                            {
                                // 종료 처리
                                CloseGame = true;
                            }
                        }
                        break;
                    case SDL.SDL_EventType.SDL_MOUSEMOTION:
                        {
                            int x = e.x;
                            int y = Program.SCREEN_HEIGHT - e.y;
                            Console.WriteLine($"{x}, {y}");
                        }
                        break;
                    case SDL.SDL_EventType.SDL_QUIT:
                        {
                            // 종료 처리
                            CloseGame = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public static List<IResource> Resources = new List<IResource>();
        static void Main(string[] args)
        {
            Context.CreateWindow(Program.SCREEN_WIDTH, Program.SCREEN_HEIGHT);
            Context.OnClosed += Close;      // 종료 이벤트 등록

            // 리소스 생성
            string baseDir = @"..\..\..\Resources\";
            Font font = Context.LoadFont(baseDir + "ConsolaMalgun.TTF", 16);
            Image grass = Context.LoadImage(baseDir + "grass.png");

            Image[] background = new Image[4];
            string[] backgroundTitle = { "backgroundDay.png", "backgroundNight.jpg", "backgroundDawn.png", "backgroundSky.jpeg" };
            for(int i=0; i<background.Length; i++)
            {
                background[i] = Context.LoadImage(baseDir + backgroundTitle[i]);
                Resources.Add(background[i]);
            }

            for (int i = 0; i < 1 /*character.Length*/; i++)
            {
                character[i] = new Character(200 * (1 + i), 80);
                character[i].uploadImage(baseDir + "animation_sheet.png");
            }

            Music music = Context.LoadMusic(baseDir + "background.mp3");
            music.PlayRepeat();

            Resources.Add(font);
            Resources.Add(grass);
            Resources.Add(music);

            // 게임 루프
            CloseGame = false;
                                
            while (CloseGame == false)
            {
                adjustDelay = 0;

                // 이벤트 처리
                HandleEvents();

                Context.ClearWindow();

                font.Render(100, 300, "Sample", new Color(100, 25, 25));
                background[0].Render(Program.SCREEN_WIDTH / 2, Program.SCREEN_HEIGHT / 2, new Size2D(Program.SCREEN_WIDTH, Program.SCREEN_HEIGHT));
                grass.Render(Program.SCREEN_WIDTH / 2, 30);

                for (int i = 0; i < 1/*character.Length*/; i++)
                {
                    character[i].move();
                }

                // 화면 바꿈
                Context.UpdateWindow();     

                Context.Delay(delay - adjustDelay);
            }

            Context.CloseWindow();
        }

        static void Close()
        {
            Console.WriteLine("Close!");
            foreach (var resource in Resources)
            {
                resource.Dispose();
            }
        }
    }
}
