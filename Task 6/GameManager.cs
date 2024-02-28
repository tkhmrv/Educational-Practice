using System;

namespace Exercise_6
{
    class GameManager
    {
        private Player player;
        private Enemy enemy;
        private SpellHandler spellHandler; // Поле для хранения экземпляра SpellHandler
        private int hpPlayer;

        public void Start()
        {
            Introduction();
            Initialize();

            try
            {
                while (true)
                {
                    ChooseSpell();
                    HandleSpell();
                    if (CheckEndGame())
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
        }

        private void Introduction()
        {
            Console.WriteLine("Добро пожаловать, темный маг! Ваша миссия - победить босса и принести мир и покой в наш мир!");
            Console.WriteLine("У вас в арсенале есть несколько заклинаний:\n");

            Console.WriteLine("1 - Рашамон – призывает теневого духа для нанесения урона ()" +
                "\r\n\t Наносит 100 - 400 единиц урона" +
                "\r\n\t Отнимает 100 хп у игрока\n");

            Console.WriteLine("2 - Хуганзакура - (Может быть выполнен только после призыва теневого духа)" +
                "\r\n\t Наносит от 50 до 300 единиц урона в течение 2 ходов\n");

            Console.WriteLine("3 - Песнь Архангела – Исполнив оду, вы получаете благословение Архангела. Урон босса по вам не пройдет" +
                "\r\n\t Полное восстановление здоровья" +
                "\r\n\t Можно использовать один раз за бой\n");

            Console.WriteLine("4 - Зеркальное отражение - создает временное зеркало, отражающее 70% урона обратно на врага" +
                "\r\n\t Игрок получает 30% урона" +
                "\r\n\t Действует 2 хода\n");

            Console.WriteLine("5 - Сфера временного замедления - создает сферу, замораживающую время на 1 ход" +
                "\r\n\t Умножает урон игрока вдвое" +
                "\r\n\t Можно использовать один раз за бой\n");
        }

        private void Initialize()
        {
            Random random = new Random();
            hpPlayer = random.Next(500, 2001);
            int hpEnemy = random.Next(hpPlayer, (int)(hpPlayer * 1.5));

            player = new Player(hpPlayer);
            enemy = new Enemy(hpEnemy);

            spellHandler = new SpellHandler(player, enemy, false, false, 0, 0, 0, false); // Создание экземпляра SpellHandler

            Console.WriteLine($"Здоровье босса - {hpEnemy} хп");
            Console.WriteLine($"Ваше здоровье - {hpPlayer} хп");
            Console.WriteLine();
        }

        private void ChooseSpell()
        {
            Console.WriteLine("Выберите заклинание из арсенала:" + Environment.NewLine +
                "\t1 - Рашамон" + Environment.NewLine +
                "\t2 - Хуганзакура" + Environment.NewLine +
                "\t3 - Песнь Архангела" + Environment.NewLine +
                "\t4 - Зеркальное отражение" + Environment.NewLine +
                "\t5 - Сфера временного замедления");

            Console.Write("Ваш выбор: ");
        }

        private void HandleSpell()
        {
            string spell = Console.ReadLine();
            spellHandler.Handle(spell, hpPlayer); // Использование существующего экземпляра SpellHandler
        }

        private bool CheckEndGame()
        {
            if (player.IsDead() && enemy.IsDead())
            {
                Console.WriteLine();
                Console.WriteLine("*************************************************************************");
                Console.WriteLine("Вы пожертвовали собой, одолев врага. Люди будут оплакивать и помнят вас как великого героя!" + Environment.NewLine +
                    "Спасибо, герой!\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы победили, отдав за это свою жизнь");
                Console.ResetColor();
                Console.WriteLine("*************************************************************************");
                Console.ReadKey();
                return true;
            }
            else if (player.IsDead())
            {
                Console.WriteLine();
                Console.WriteLine("*************************************************************************");
                Console.WriteLine($"Ваша жизнь оборвалась. Вы умерли от удара чудовища, так и не убив его." + Environment.NewLine +
                    "Надеюсь, следующие герои смогут спасти этот мир.\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Вы проиграли эту битву");
                Console.ResetColor();
                Console.WriteLine("*************************************************************************");
                Console.ReadKey();
                return true;
            }
            else if (enemy.IsDead())
            {
                Console.WriteLine();
                Console.WriteLine("*************************************************************************");
                Console.WriteLine("Враг повержен, люди могут спать спокойно, а ваш подвиг запомнят на века! " + Environment.NewLine +
                    "Спасибо, герой!\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы победили!");
                Console.ResetColor();
                Console.WriteLine("*************************************************************************");
                Console.ReadKey();
                return true;
            }

            return false;
        }
    }
}
