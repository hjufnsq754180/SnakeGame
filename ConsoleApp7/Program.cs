﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            // Рамка
            HorizontalLine lineUp = new HorizontalLine(0, 78, 0, '+');
            VerticalLine lineLeft = new VerticalLine(0, 24, 0, '+');
            HorizontalLine lineDown = new HorizontalLine(0, 78, 24, '+');
            VerticalLine lineRieght = new VerticalLine(0, 24, 78, '+');
            lineUp.Drow();
            lineLeft.Drow();
            lineDown.Drow();
            lineRieght.Drow();

            // Точки
            Point p = new Point(4, 5, '*');
            /* p1.x = 1;
             p1.y = 3;
             p1.sym = '*'; */
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '#');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat (food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else 
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandKey(key.Key);
                }
            }

            Console.ReadKey();
        }
    }
}
