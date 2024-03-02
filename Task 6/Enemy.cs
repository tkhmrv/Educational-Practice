namespace Exercise_6
{
    // Класс Enemy представляет врага в игре
    internal class Enemy
    {
        // Свойство Health представляет текущее количество здоровья у врага
        public int Health { get; private set; }

        // Конструктор класса Enemy принимает начальное значение здоровья врага
        public Enemy(int health)
        {
            Health = health;
        }

        // Метод IsDead проверяет здоровье врага
        // Возвращает true, если враг мертв
        public bool IsDead()
        {
            return Health <= 0;
        }

        // Метод TakeDamage принимает количество урона и уменьшает здоровье врага на эту величину
        public void TakeDamage(int damage)
        {
            Health -= damage;
        }
    }
}
