using System;
using System.IO;

namespace Task_7
{
    class Program
    {
        // Путь к файлу с картой
        const string MapFilePath = @"C:\Users\smmrv\Desktop\Practice\Task 7\bin\Debug\maps\level01.txt";
        // Общее количество шагов, которые можно сделать
        const int TotalMoves = 202;

        static void Main(string[] args)
        {
            bool isRunning = true;
            int cubeDX = 0, cubeDY = 0; // Изменение координаты по X и Y при движении куба
            int movesMade = 0; // Количество сделанных шагов
            Console.CursorVisible = false;
            // Считываем карту из файла
            char[,] map = ReadMap(out int cubeX, out int cubeY);

            // Устанавливаем размер окна консоли и выводим инструкции
            SetConsole(100, 40);

            // Рисуем карту
            DrawMap(map);

            while (isRunning)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.H)
                {
                    // Если нажата H, показываем правильный маршрут
                    FollowCorrectPath(map, ref cubeX, ref cubeY, ref cubeDX, ref cubeDY, ref movesMade);
                    isRunning = false;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    // Если нажат Escape, выходим из игры
                    Console.SetCursorPosition(35, 17);
                    Console.WriteLine("Вы вышли из игры!\n");
                    isRunning = false;
                }
                else if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.A || key.Key == ConsoleKey.S || key.Key == ConsoleKey.D)
                {
                    // Если нажата WASD, обрабатываем движение куба
                    ChooseMotion(key, ref cubeDX, ref cubeDY);

                    bool repeatedPath = MoveCube(map, ref cubeX, ref cubeY, cubeDX, cubeDY, ref movesMade);
                    if (repeatedPath)
                    {
                        Console.ReadKey();
                        break;
                    }
                }
                else
                {
                    // Если нажата другая клавиша, выводим сообщение об ошибке
                    Console.SetCursorPosition(35, 17);
                    Console.WriteLine("Этот символ не является элементом управления!\n");
                    continue;
                }
            }
            Console.SetCursorPosition(35, 17);
            Console.WriteLine();
            Console.SetCursorPosition(35, 19);
        }

        // Следование правильному маршруту
        static void FollowCorrectPath(char[,] map, ref int cubeX, ref int cubeY, ref int cubeDX, ref int cubeDY, ref int movesMade)
        {
            // Правильный маршрут
            string correctPath = "AAASSSDWWDSSSAASSDWDDWWWWDSSSDWWWD" +
                        "SSSSAASAASAASDDDWDSSAAAASSSSDWWWDSSSDWWWDSSSD" +
                        "WWWWWWWDSSSSSSSDWDSDWWAAWDWAWDDSSDSSSDDDWAAWD" +
                        "DWAAWAWDDSDWWAAAAAAWWWWWWDSSSSSDWWWWWDSSSSSDD" +
                        "WAWDWAWWDSDWDSSASDSASDSSSSSSSSAAA";

            foreach (char c in correctPath)
            {
                switch (c)
                {
                    case 'A':
                        cubeDX = 0;
                        cubeDY = -2;
                        break;
                    case 'S':
                        cubeDX = 2;
                        cubeDY = 0;
                        break;
                    case 'D':
                        cubeDX = 0;
                        cubeDY = 2;
                        break;
                    case 'W':
                        cubeDX = -2;
                        cubeDY = 0;
                        break;
                }
                MoveCube(map, ref cubeX, ref cubeY, cubeDX, cubeDY, ref movesMade);

                System.Threading.Thread.Sleep(200);

                if (movesMade == TotalMoves)
                {
                    Console.ReadKey();
                    break;
                }
            }
        }

        // Выбор направления движения куба
        static void ChooseMotion(ConsoleKeyInfo key, ref int cubeDX, ref int cubeDY)
        {
            switch (key.Key)
            {
                case ConsoleKey.W:
                    cubeDX = -2;
                    cubeDY = 0;
                    break;
                case ConsoleKey.S:
                    cubeDX = 2;
                    cubeDY = 0;
                    break;
                case ConsoleKey.A:
                    cubeDX = 0;
                    cubeDY = -2;
                    break;
                case ConsoleKey.D:
                    cubeDX = 0;
                    cubeDY = 2;
                    break;
                default:
                    break;
            }
        }

        // Движение куба
        static bool MoveCube(char[,] map, ref int X, ref int Y, int DX, int DY, ref int movesMade)
        {
            bool isMoveNotRestricted = map[X + DX / 2, Y + DY / 2] != '║' &&
                map[X + DX / 2, Y + DY / 2] != '═' &&
                map[X + DX / 2, Y + DY / 2] != '╠' &&
                map[X + DX / 2, Y + DY / 2] != '╣' &&
                map[X + DX / 2, Y + DY / 2] != '╦' &&
                map[X + DX / 2, Y + DY / 2] != '╩' &&
                map[X + DX / 2, Y + DY / 2] != '╬' &&
                (X + DX / 2) < map.GetLength(0) - 1 && (X + DX / 2) > 0 &&
                (Y + DY / 2) < map.GetLength(1) - 1 && (Y + DY / 2) > 0;

            if (isMoveNotRestricted)
            {
                if (map[X + DX, Y + DY] != '¤')
                {
                    Console.SetCursorPosition(Y, X);
                    Console.Write('¤');
                    map[X, Y] = '¤';
                    X += DX;
                    Y += DY;
                    Console.SetCursorPosition(Y, X);
                    Console.Write('■');

                    movesMade++;
                    DrawBar(movesMade);

                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(35, 15);
                    Console.Write("Вы уже проходили в данном месте!");
                    Console.SetCursorPosition(35, 16);
                    Console.Write("Вы проиграли, игра закончена!");
                    Console.ResetColor();
                    return true;
                }
            }
            return false;
        }

        // Установка параметров консоли и вывод инструкций
        static void SetConsole(int length, int height)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(length, height);
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("Игра - заброшенный музей");
            Console.SetCursorPosition(35, 1);
            Console.WriteLine();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("В музее 195 комнат. Составьте маршрут для посетителей:");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("Необходимо посетить каждую комнату, не заходя дважды");
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("ни в одну из них. Также нужно включить пунктирный маршрут.");
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("Пройденный путь отмечается символом ¤.");
            Console.SetCursorPosition(35, 6);
            Console.WriteLine();
            Console.SetCursorPosition(35, 7);
            Console.WriteLine($"Маршрут можно пройти за {TotalMoves} шага.");
            Console.SetCursorPosition(35, 8);
            Console.WriteLine();
            Console.SetCursorPosition(35, 9);
            Console.WriteLine("Используйте WASD для передвижения.");
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("H - подсказка по маршруту.");
            Console.SetCursorPosition(35, 11);
            Console.WriteLine("ESC - выход из игры.");
            Console.SetCursorPosition(0, 0);
        }

        // Вывод карты на экран
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        // Вывод информации о шагах и прогрессе
        static void DrawBar(int movesMade)
        {
            int percentage = (movesMade * 100) / TotalMoves;

            if (percentage > 80) Console.ForegroundColor = ConsoleColor.Red;
            else if ((percentage > 40) && (percentage <= 80)) Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if ((percentage >= 0) && (percentage <= 40)) Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 32);
            if (movesMade <= TotalMoves)
            {
                Console.WriteLine($"Осталось ходов - {Convert.ToString(TotalMoves - movesMade),3:N0} из {TotalMoves}");

                Console.SetCursorPosition(30, 32);
                for (int i = 0; i < (TotalMoves - movesMade); i += TotalMoves / 10)
                {
                    Console.Write('#');
                }
                for (int i = 10; i < 11; i++)
                {
                    Console.Write('_');
                }
            }
            else
            {
                Console.WriteLine($"Вы потратили больше ходов, чем нужно! Текущее количество: {movesMade + (movesMade - TotalMoves + 1)}");
            }

            Console.ResetColor();
        }

        // Считывание карты из файла
        static char[,] ReadMap(out int cubeX, out int cubeY)
        {
            cubeX = 0;
            cubeY = 0;

            string[] newFile = File.ReadAllLines(MapFilePath);
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        cubeX = i;
                        cubeY = j;
                    }
                }
            }
            return map;
        }
    }
}
