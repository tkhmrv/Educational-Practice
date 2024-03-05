using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tasks_11_12
{
    public partial class Sudoku : Form
    {
        // Массив ячеек судоку
        private TextBox[,] cells;

        // Константы для размеров ячеек, разделителей и сетки судоку
        private const int CellSize = 44;
        private const int SeparatorWidth = 2;
        private const int SectionSize = 3;
        private const int SectionCellAmount = 9;
        private const int GridOffset = 40;

        public Sudoku()
        {
            InitializeComponent();
            InitializeSudoku();
        }

        /// <summary>
        /// Метод для инициализации судоку
        /// </summary>
        private void InitializeSudoku()
        {
            // Создание ячеек и добавление разделителей
            cells = new TextBox[SectionCellAmount, SectionCellAmount];
            AddSeparators();

            for (int i = 0; i < SectionCellAmount; i++)
            {
                for (int j = 0; j < SectionCellAmount; j++)
                {
                    // Вычисление цвета блока
                    Color blockColor = ((i / SectionSize) + (j / SectionSize)) % 2 == 0 ? Color.White : Color.FromArgb(240, 240, 240);

                    // Создание и настройка ячейки судоку
                    TextBox cell = new TextBox
                    {
                        Location = new Point(j * CellSize + GridOffset, i * CellSize + GridOffset),
                        Size = new Size(CellSize, CellSize),
                        Font = new Font(FontFamily.GenericSansSerif, 20),
                        AutoSize = true,
                        TextAlign = HorizontalAlignment.Center,
                        Multiline = true,
                        MaxLength = 1,
                        BackColor = blockColor,
                        Tag = new int[] { i, j }
                    };
                    cell.TextChanged += CellContentChanged;
                    cells[i, j] = cell;
                    Controls.Add(cell);
                }
            }
        }

        /// <summary>
        /// Метод для отображения разделителей в форме
        /// </summary>
        private void AddSeparators()
        {
            for (int i = 1; i < SectionCellAmount; i++)
            {
                if (i % SectionSize == 0)
                {
                    // Горизонтальные разделители
                    CreateSeparator(GridOffset, i * CellSize + GridOffset - SeparatorWidth, CellSize * SectionCellAmount, SeparatorWidth);
                    // Вертикальные разделители
                    CreateSeparator(i * CellSize + GridOffset - SeparatorWidth, GridOffset, SeparatorWidth, CellSize * SectionCellAmount);
                }
            }
        }

        /// <summary>
        /// Метод для создание разделителей
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void CreateSeparator(int x, int y, int width, int height)
        {
            Label separator = new Label
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.Black
            };
            Controls.Add(separator);
        }

        /// <summary>
        /// Обработчик события изменения содержимого ячейки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellContentChanged(object sender, EventArgs e)
        {
            TextBox cell = sender as TextBox;
            if (cell == null)
                return;

            int row = ((int[])cell.Tag)[0];
            int col = ((int[])cell.Tag)[1];

            // Проверка на корректность ввода и обновление цвета ячейки при необходимости
            if (!string.IsNullOrEmpty(cell.Text) && !char.IsControl(cell.Text[0]))
            {
                if (!char.IsDigit(cell.Text[0]) || cell.Text[0] == '0')
                {
                    cell.Text = "";
                    return;
                }

                int value = int.Parse(cell.Text);
                if (IsConflict(row, col, value))
                {
                    HighlightConflicts(row, col, Color.Red);
                }
                else
                {
                    HighlightConflicts(row, col, Color.Green);
                }
            }
            else
            {
                HighlightConflicts(row, col, Color.Green);
            }
        }

        /// <summary>
        /// Метод для проверки наличия конфликтов в ячейке судоку
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns>true - есть конфликт, false - нет конфликта</returns>
        private bool IsConflict(int row, int col, int value)
        {

            // Проверка строки и столбца
            for (int i = 0; i < SectionCellAmount; i++)
            {
                if (i != col && cells[row, i].Text == value.ToString())
                    return true;

                if (i != row && cells[i, col].Text == value.ToString())
                    return true;
            }

            // Проверка квадрата 3x3
            int rowStart = row - row % SectionSize;
            int colStart = col - col % SectionSize;
            for (int i = rowStart; i < rowStart + SectionSize; i++)
            {
                for (int j = colStart; j < colStart + SectionSize; j++)
                {
                    if ((i != row || j != col) && cells[i, j].Text == value.ToString())
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Метод для подсветки конфликтных ячеек
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="color"></param>
        private void HighlightConflicts(int row, int col, Color color)
        {
            // Подсветка строки и столбца
            for (int i = 0; i < SectionCellAmount; i++)
            {
                cells[row, i].ForeColor = color;
                cells[i, col].ForeColor = color;
            }

            // Подсветка квадрата 3x3
            int rowStart = row - row % SectionSize;
            int colStart = col - col % SectionSize;
            for (int i = rowStart; i < rowStart + SectionSize; i++)
            {
                for (int j = colStart; j < colStart + SectionSize; j++)
                {
                    cells[i, j].ForeColor = color;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------
        //------------------------------------------------- Buttons -------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Автоматическое заполнение судоку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAutoSolution_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей и разблокировка ячеек
            foreach (var cell in cells)
            {
                cell.Text = "";
                cell.Enabled = true;
            }

            int[,] SudokuSolution = SudokuSolver.GenerateSudoku();

            for (int i = 0; i < SectionCellAmount; i++)
            {
                for (int j = 0; j < SectionCellAmount; j++)
                {
                    cells[i, j].Text = SudokuSolution[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Новая игра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей и разблокировка ячеек
            foreach (var cell in cells)
            {
                cell.Text = "";
                cell.Enabled = true;
            }
        }

        /// <summary>
        /// Захват условий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCaptureCondition_Click(object sender, EventArgs e)
        {
            foreach (var cell in cells)
            {
                if (cell.ForeColor == Color.Red)
                {
                    MessageBox.Show("Заполните все поля правильно!");
                    return;
                }

                if (!string.IsNullOrEmpty(cell.Text))
                {
                    cell.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Разблокировка ячеек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonUnlock_Click(object sender, EventArgs e)
        {
            // Разблокировка всех ячеек
            foreach (var cell in cells)
            {
                cell.Enabled = true;
            }
        }

        /// <summary>
        /// Сохранение состояния судоку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int fileNumber = 1;
                using (StreamWriter writer = new StreamWriter($"games/sudoku_game_number_{fileNumber}.txt"))
                {
                    for (int i = 0; i < SectionCellAmount; i++)
                    {
                        for (int j = 0; j < SectionCellAmount; j++)
                        {
                            writer.Write(string.IsNullOrEmpty(cells[i, j].Text) ? "0" : cells[i, j].Text);
                        }
                        writer.WriteLine();
                    }
                }

                fileNumber++;

                MessageBox.Show("Состояние судоку сохранено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении состояния судоку: {ex.Message}");
            }
        }

        /// <summary>
        /// Импорт состояния судоку из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonImport_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    Title = "Выберите файл для загрузки состояния судоку"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        for (int i = 0; i < SectionCellAmount; i++)
                        {
                            string line = reader.ReadLine();
                            if (line != null && line.Length == SectionCellAmount)
                            {
                                for (int j = 0; j < SectionCellAmount; j++)
                                {
                                    cells[i, j].Text = line[j] != '0' ? line[j].ToString() : "";
                                }
                            }
                        }
                    }
                    MessageBox.Show("Состояние судоку загружено успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке состояния судоку: {ex.Message}");
            }
        }
    }
}
