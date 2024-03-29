﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using Console = Colorful.Console;

namespace Snake_Console
{
    class Game
    {
        ConsoleKeyInfo key;
        bool IAmAlive = true;
        Snake snake;
        Food food;
        Wall wall;
        Scoreboard scoreboard;
        int lvl = 1;

        public Game()
        {
            snake = new Snake(new Point(10, 10), Color.White, 'O');
            wall = new Wall(new Point(1, 1), Color.BlueViolet, '#');
            food = new Food(new Point(15, 15), Color.Yellow, '$');
            scoreboard = new Scoreboard();
        }

        public void Start()
        {
            SoundPlayer eat = new SoundPlayer(@"Sounds\food.wav");
            Console.CursorVisible = false;
            Console.SetWindowSize(40, 20);
            Console.SetBufferSize(40, 20);
            wall.Draw();
            food.Draw();
            snake.Draw();
            scoreboard.Draw();
            while (IAmAlive && key.Key != ConsoleKey.Escape)
            {
                food.Draw();
                snake.Move(key);
                snake.Draw();
                wall.Draw();
                scoreboard.Draw();
                if (snake.Boom(food))
                {
                    eat.Play();
                    scoreboard.score += 10;
                    if(scoreboard.score % 100 == 0)
                    {
                        lvl++;
                        snake.ChangeLevel();
                        wall.LoadLevel(lvl);
                    }
                    food.Spawn(wall.GoodSpots, snake.Chel);
                    snake.Chel.Add(new Point(30, 19));
                }
                else if ((snake.Chel.Count > 2 && snake.Boom(snake, 1)) || snake.Boom(wall))
                {
                    IAmAlive = false;
                    GameOver();
                }
                key = Console.ReadKey();
            }
        }


        public Color ColorConsole()
        {
            int A;
            A = 0;
           // A = 0 + Console.CursorTop * 12;
            return Color.FromArgb(255, A % 255, A % 255);
        }


        public void GameOver()
        {
            SoundPlayer Death = new SoundPlayer(@"Sounds\death.wav");
            Death.Play();
            Console.ResetColor();
            Console.Clear();
            
            //G
            for(int i = 4; i < 7; i++)
            {
                Console.SetCursorPosition(8, i);
                Console.Write("*", ColorConsole());
            }
            for (int i = 10; i < 13; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("*", ColorConsole());
            }
            for (int i = 10; i < 13; i++)
            {
                Console.SetCursorPosition(i, 8);
                Console.Write("*", ColorConsole());
            }
            for (int i = 11; i < 14; i++)
            {
                Console.SetCursorPosition(i, 6);
                Console.Write("*", ColorConsole());
            }
            Console.SetCursorPosition(9, 7);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(9, 3);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(13, 3);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(13, 7);
            Console.Write("*", ColorConsole());

            //A
            for (int i = 16; i < 19; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 5);
                Console.Write("*", ColorConsole());
            }
            for (int i = 3; i < 9; i++)
            {
                Console.SetCursorPosition(15, i);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(19, i);
                Console.Write("*", ColorConsole());
            }

            //M
            for (int i = 2; i < 9; i++)
            {
                Console.SetCursorPosition(21, i);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(27, i);
                Console.Write("*", ColorConsole());
            }
            Console.SetCursorPosition(22, 3);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(26, 3);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(23, 4);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(25, 4);
            Console.Write("*", ColorConsole());
            Console.SetCursorPosition(24, 5);
            Console.Write("*", ColorConsole());

            //E
            for (int i = 30; i < 34; i++)
            {
                Console.SetCursorPosition(i, 2);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 5);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 8);
                Console.Write("*", ColorConsole());
            }
            for (int i = 2; i < 9; i++)
            {
                Console.SetCursorPosition(29, i);
                Console.Write("*", ColorConsole());
            }

            //O
            for (int i = 11; i < 16; i++)
            {
                Console.SetCursorPosition(10, i);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(14, i);
                Console.Write("*", ColorConsole());
            }
            for (int i = 11; i < 14; i++)
            {
                Console.SetCursorPosition(i, 10);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 16);
                Console.Write("*", ColorConsole());
            }

            //V
            for (int i = 10; i < 13; i++)
            {
                Console.SetCursorPosition(16, i);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(20, i);
                Console.Write("*", ColorConsole());
            }
            for (int i = 13; i < 16; i++)
            {
                Console.SetCursorPosition(17, i);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(19, i);
                Console.Write("*", ColorConsole());
            }
            Console.SetCursorPosition(18, 16);
            Console.Write("*", ColorConsole());

            //E
            for (int i = 22; i < 26; i++)
            {
                Console.SetCursorPosition(i, 10);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 13);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 16);
                Console.Write("*", ColorConsole());
            }
            for (int i = 10; i < 17; i++)
            {
                Console.SetCursorPosition(22, i);
                Console.Write("*", ColorConsole());
            }

            //R
            for (int i = 10; i < 17; i++)
            {
                Console.SetCursorPosition(27, i);
                Console.Write("*", ColorConsole());
            }
            for (int i = 27; i < 30; i++)
            {
                Console.SetCursorPosition(i, 10);
                Console.Write("*", ColorConsole());
                Console.SetCursorPosition(i, 13);
                Console.Write("*", ColorConsole());
            }
            for (int i = 10; i < 13; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write("*", ColorConsole());
            }
            for (int i = 14; i < 17; i++)
            {
                Console.SetCursorPosition(30, i);
                Console.Write("*", ColorConsole());
            }
            System.Threading.Thread.Sleep(3000);
            Console.ReadKey();
        }
    }

}
