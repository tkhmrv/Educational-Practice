using System;

namespace Exercise_6
{
    class SpellHandler
    {
        private readonly Player player;
        private readonly Enemy enemy;
        private bool isFadeSpiritExist;
        private bool isImmortal;
        private int durationHukanzacura;
        private int durationMirrorReflection;
        private int durationTimeSphere;
        private bool timeSphereUsed;

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

        public void Handle(string spell, int hpPlayer)
        {
            Random random = new Random();
            int receivedDamage = 0;
            int dealtDamage = 0;

            switch (spell)
            {
                case "1":
                    isFadeSpiritExist = true;

                    dealtDamage += random.Next(100, 401);
                    receivedDamage += random.Next(200, 701) + 100;
                    break;

                case "2":
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

                case "3":
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
                        player.Heal(hpPlayer);
                        isImmortal = true;
                        Console.WriteLine($"Вы чувствуете прилив сил.");
                    }
                    break;

                case "4":
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

                case "5":
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

                default:
                    Console.WriteLine("Вы не знаете такого заклинания, попробуйте еще раз.");
                    Console.WriteLine();
                    return;
            }

            if (durationHukanzacura != 0)
            {
                durationHukanzacura--;
                dealtDamage += random.Next(50, 301);
                Console.WriteLine($"Хуганзакура: осталось {durationHukanzacura} хода(-ов).");
            }


            if (isImmortal)
            {
                receivedDamage = 0;
                isImmortal = false;
            }
            else
            {
                player.TakeDamage(receivedDamage);
            }
            enemy.TakeDamage(dealtDamage);

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
