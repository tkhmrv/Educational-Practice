namespace Exercise_6
{
    // Класс Game представляет точку входа в программу
    class Game
    {
        static void Main()
        {
            // Создаем экземпляр класса GameManager для управления игровым процессом
            GameManager gameManager = new GameManager();
            // Запускаем игру, вызывая метод Start
            gameManager.Start();
        }
    }
}
