using System;

namespace Tasks_11_12
{
    public class SudokuSolver
    {
        private static readonly int SIZE = 9;
        private static readonly int CUBE_SIZE = 3;
        private static readonly Random rand = new Random();

        /// <summary>
        /// Метод для генерации судоку
        /// </summary>
        /// <returns>Думерный массив 9 на 9 с решение судоку</returns>
        public static int[,] GenerateSudoku()
        {
            int[,] board = new int[SIZE, SIZE];

            // Заполняем диагонали
            FillDiagonals(board);

            // Решаем судоку
            Solve(board);

            return board;
        }

        /// <summary>
        /// Метод для заполнения диагоналей судоку
        /// </summary>
        /// <param name="board"></param>
        private static void FillDiagonals(int[,] board)
        {
            for (int i = 0; i < SIZE; i += CUBE_SIZE)
            {
                FillBox(board, i, i);
            }
        }

        /// <summary>
        /// Метод для заполнения квадратной подсетки судоку
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private static void FillBox(int[,] board, int row, int col)
        {
            int value;

            for (int i = 0; i < CUBE_SIZE; i++)
            {
                for (int j = 0; j < CUBE_SIZE; j++)
                {
                    // Генерируем случайное число для заполнения клетки
                    do
                    {
                        value = rand.Next(1, SIZE + 1);
                    } while (IsConflict(board, row + i, col + j, value)); // Проверяем, что число подходит для этой клетки

                    // Заполняем клетку
                    board[row + i, col + j] = value;
                }
            }
        }

        /// <summary>
        /// Метод для решения судоку
        /// </summary>
        /// <param name="board"></param>
        /// <returns>true - значение верное, false - Триггер для возврата к предыдущей клетке и изменения числа</returns>
        private static bool Solve(int[,] board)
        {
            if (!FindEmptyLocation(board, out int row, out int col))
            {
                return true; // Судоку решено успешно
            }

            int[] values = GenerateShuffledNumbers();

            foreach (int value in values)
            {
                if (!IsConflict(board, row, col, value))
                {
                    board[row, col] = value;

                    if (Solve(board)) // Рекурсивно решаем следующую клетку
                    {
                        return true;
                    }

                    board[row, col] = 0;
                }
            }

            return false; // Триггер для возврата к предыдущей клетке и изменения числа
        }

        /// <summary>
        /// Метод для генерации случайной перестановки чисел от 1 до 9
        /// </summary>
        /// <returns>Одномерный массив рандомных чисел 1-9</returns>
        private static int[] GenerateShuffledNumbers()
        {
            int[] values = new int[SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                values[i] = i + 1;
            }

            // Алгоритма "Fisher-Yates"
            for (int i = SIZE - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (values[j], values[i]) = (values[i], values[j]);
            }

            return values;
        }

        /// <summary>
        /// Метод для поиска пустой клетки
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>true - найдена пустая клетка, false - все клетки заполнены</returns>
        private static bool FindEmptyLocation(int[,] board, out int row, out int col)
        {
            for (row = 0; row < SIZE; row++)
            {
                for (col = 0; col < SIZE; col++)
                {
                    if (board[row, col] == 0)
                    {
                        return true;
                    }
                }
            }
            row = -1;
            col = -1;
            return false;
        }

        /// <summary>
        /// Проверяет, можно ли разместить число в клетке, не нарушая правила
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns>true - есть конфликт, false - нет конфликта</returns>
        private static bool IsConflict(int[,] board, int row, int col, int value)
        {
            // Проверка строки и столбца
            for (int i = 0; i < SIZE; i++)
            {
                if (i != col && board[row, i] == value)
                    return true;

                if (i != row && board[i, col] == value)
                    return true;
            }

            // Проверка квадрата 3x3
            int rowStart = row - row % CUBE_SIZE;
            int colStart = col - col % CUBE_SIZE;
            for (int i = rowStart; i < rowStart + CUBE_SIZE; i++)
            {
                for (int j = colStart; j < colStart + CUBE_SIZE; j++)
                {
                    if ((i != row || j != col) && board[i, j] == value)
                        return true;
                }
            }

            return false;
        }
    }
}
