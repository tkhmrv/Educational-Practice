using System;

namespace Exercise_6
{
    class SpellHandler
    {
        private readonly Player player; // Игрок
        private readonly Enemy enemy; // Противник
        private bool isFadeSpiritExist; // Существует ли призванный теневой дух
        private bool isImmortal; // Бессмертен ли игрок
        private int durationHukanzacura; // Длительность Хуганзакуры
        private int durationMirrorReflection; // Длительность Зеркального отражения
        private int durationTimeSphere; // Длительность Сферы временного замедления
        private bool timeSphereUsed; // Использовалась ли Сфера временного замедления

        // Конструктор класса
        public SpellHandler(Player player, Enemy enemy, bool isFadeSpiritExist, bool isImmortal,
            int durationHukanzacura, int durationMirrorReflection, int durationTimeSphere, bool timeSphereUsed)
        {
            this.player = player;
            this.enemy = enemy;
            this.isFadeSpiritExist = isFadeSpiritExist;
            this.isImmortal = isImmortal;
            this.durationHukanzacura = durationHukanzacura;
            this.durationMirrorReflection = durationMirrorReflection;
            this.durationTimeSphere = durationTimeSphere;
            this.timeSphereUsed = timeSphereUsed;
        }

        // Метод для обработки заклинания
        public void Handle(string spell, int hpPlayer)
        {
            Random random = new Random();
            int receivedDamage = 0; // Полученный урон
            int dealtDamage = 0; // Нанесенный урон

            switch (spell)
            {
                case "1": // Первое заклинание
                    isFadeSpiritExist = true;

                    dealtDamage += random.Next(100, 401);
                    receivedDamage += random.Next(200, 701) + 100;
                    break;

                case "2": // Второе заклинание
                    if (isFadeSpiritExist)
                    {
                        durationHukanzacura += 2;
                        isFadeSpiritExist = false;
                        receivedDamage += random.Next(200, 701);
                    }
                    else
                    {
                        Console.WriteLine("У вас нет призванных теневых духов." + Environment.NewLine);
                        return;
                    }
                    break;

                case "3": // Третье заклинание
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Вы мертвы и не можете использовать это заклинание." + Environment.NewLine);
                        return;
                    }
                    else if (isImmortal)
                    {
                        Console.WriteLine("Вы уже используете Песнь Архангела и не можете использовать ее повторно." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        player.Heal(hpPlayer); // Исцеляем игрока
                        isImmortal = true;
                        Console.WriteLine($"Вы чувствуете прилив сил.");
                    }
                    break;

                case "4": // Четвертое заклинание
                    if (durationMirrorReflection > -2)
                    {
                        durationMirrorReflection--;
                        receivedDamage += (int)(random.Next(200, 701) * 0.3);
                        int reflectedDamage = (int)(receivedDamage * 0.7);
                        dealtDamage = reflectedDamage;
                        Console.WriteLine($"Зеркальное отражение: осталось {durationMirrorReflection + 2} хода(-ов).");
                    }
                    else
                    {
                        Console.WriteLine("Вы не находитесь под воздействием Зеркального отражения." + Environment.NewLine);
                        return;
                    }
                    break;

                case "5": // Пятое заклинание
                    if (timeSphereUsed)
                    {
                        Console.WriteLine("Сфера временного замедления уже была использована и больше недоступна." + Environment.NewLine);
                        return;
                    }
                    else
                    {
                        durationTimeSphere--;
                        dealtDamage += (random.Next(200, 701) * 2);
                        Console.WriteLine($"Сфера временного замедления: осталось {durationTimeSphere + 1} хода(-ов).");
                        timeSphereUsed = true;
                    }
                    break;

                default: // Если заклинание не опознано
                    Console.WriteLine("Вы не знаете такого заклинания, попробуйте еще раз.");
                    Console.WriteLine();
                    return;
            }

            if (durationHukanzacura != 0) // Если активна Хуганзакура
            {
                durationHukanzacura--;
                dealtDamage += random.Next(50, 301);
                Console.WriteLine($"Хуганзакура: осталось {durationHukanzacura} хода(-ов).");
            }

            // Если игрок бессмертен, то он не получает урон
            if (isImmortal)
            {
                receivedDamage = 0;
                isImmortal = false;
            }
            else
            {
                player.TakeDamage(receivedDamage); // Получение урона игроком
            }
            enemy.TakeDamage(dealtDamage); // Получение урона противником

            Console.WriteLine();
            Console.WriteLine($"Нанесено {dealtDamage} единиц урона.");
            Console.WriteLine($"Получено {receivedDamage} единиц урона.");

            Console.WriteLine();
            Console.WriteLine($"Здоровье босса - {enemy.Health} хп");
            Console.WriteLine($"Ваше здоровье - {player.Health} хп");
            Console.WriteLine();
        }
    }
}
