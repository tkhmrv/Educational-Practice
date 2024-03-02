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

        // Готовое решение судоку
        private static readonly string[] completeSudoku =
        {
            "534678912",
            "672195348",
            "198342567",
            "859761423",
            "426853791",
            "713924856",
            "961537284",
            "287419635",
            "345286179"
        };

        // Константы для размеров ячеек, разделителей и сетки судоку
        private const int CellSize = 44;
        private const int SeparatorWidth = 2;
        private const int SectionSize = 3;
        private const int SectionCount = 9;
        private const int GridOffset = 40;

        public Sudoku()
        {
            InitializeComponent();
            InitializeSudoku();
        }

        // Метод для инициализации судоку
        private void InitializeSudoku()
        {
            // Создание ячеек и добавление разделителей
            cells = new TextBox[SectionCount, SectionCount];
            AddSeparators();

            for (int i = 0; i < SectionCount; i++)
            {
                for (int j = 0; j < SectionCount; j++)
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

        // Метод для добавления разделителей
        private void AddSeparators()
        {
            for (int i = 1; i < SectionCount; i++)
            {
                if (i % SectionSize == 0)
                {
                    // Горизонтальные разделители
                    AddSeparator(GridOffset, i * CellSize + GridOffset - SeparatorWidth, CellSize * SectionCount, SeparatorWidth);
                    // Вертикальные разделители
                    AddSeparator(i * CellSize + GridOffset - SeparatorWidth, GridOffset, SeparatorWidth, CellSize * SectionCount);
                }
            }
        }

        // Метод для добавления разделителя
        private void AddSeparator(int x, int y, int width, int height)
        {
            Label separator = new Label
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.Black
            };
            Controls.Add(separator);
        }

        // Обработчик события изменения содержимого ячейки
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

        // Метод для проверки наличия конфликтов в ячейке
        private bool IsConflict(int row, int col, int value)
        {
            // Проверка строки и столбца
            for (int i = 0; i < SectionCount; i++)
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

        // Метод для подсветки конфликтных ячеек
        private void HighlightConflicts(int row, int col, Color color)
        {
            // Подсветка строки и столбца
            for (int i = 0; i < SectionCount; i++)
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

        // Автоматическое заполнение судоку
        private void ButtonAutoSolution_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SectionCount; i++)
            {
                for (int j = 0; j < SectionCount; j++)
                {
                    cells[i, j].Text = completeSudoku[i][j].ToString();
                }
            }
        }

        // Новая игра
        private void ButtonNewGame_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей и разблокировка ячеек
            foreach (var cell in cells)
            {
                cell.Text = "";
                cell.Enabled = true;
            }
        }

        // Захват условий
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

        // Разблокировка ячеек
        private void ButtonUnlock_Click(object sender, EventArgs e)
        {
            // Разблокировка всех ячеек
            foreach (var cell in cells)
            {
                cell.Enabled = true;
            }
        }

        // Сохранение состояния судоку
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int fileNumber = 1;
                using (StreamWriter writer = new StreamWriter($"sudoku_game_number_{fileNumber}.txt"))
                {
                    for (int i = 0; i < SectionCount; i++)
                    {
                        for (int j = 0; j < SectionCount; j++)
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

        // Импорт состояния судоку из файла
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
                        for (int i = 0; i < SectionCount; i++)
                        {
                            string line = reader.ReadLine();
                            if (line != null && line.Length == SectionCount)
                            {
                                for (int j = 0; j < SectionCount; j++)
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
