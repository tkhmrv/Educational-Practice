namespace Exercise_6
{
    // Класс Player представляет игрового персонажа
    internal class Player
    {
        // Свойство Health представляет текущее количество здоровья игрока
        public int Health { get; private set; }

        // Конструктор класса Player принимает начальное значение здоровья игрока
        public Player(int health)
        {
            Health = health;
        }

        // Метод IsDead проверяет здоровье игрока
        // Возвращает true, если игрок мертв
        public bool IsDead()
        {
            return Health <= 0;
        }

        // Метод TakeDamage принимает количество урона и уменьшает здоровье игрока на эту величину
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        // Метод Heal восстанавливает здоровье игрока до максимального значения
        public void Heal(int maxHealth)
        {
            Health = maxHealth;
        }
    }
}
