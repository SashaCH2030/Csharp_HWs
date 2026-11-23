//public interface ICombatant
//{
//    string Name { get; }
//    int HP { get; set; }
//    bool IsAlive { get; }

//    void Attack(ICombatant target);
//    void TakeDamage(int damage);
//}

//// Класс Рыцарь
//public class Knight : ICombatant
//{
//    public string Name { get; }
//    public int HP { get; set; }
//    public int AttackPower { get; }
//    public int Armor { get; }
//    public bool IsAlive => HP > 0;

//    public Knight(string name, int hp, int attackPower, int armor)
//    {
//        Name = name;
//        HP = hp;
//        AttackPower = attackPower;
//        Armor = armor;
//    }

//    public void Attack(ICombatant target)
//    {
//        if (!IsAlive) return;
//        Console.WriteLine($"[Рыцарь] {Name} атакует {target.Name} мечом с силой {AttackPower}!");
//        target.TakeDamage(AttackPower);
//    }

//    public void TakeDamage(int damage)
//    {
//        int actualDamage = Math.Max(0, damage - Armor);
//        HP = Math.Max(0, HP - actualDamage);
//        Console.WriteLine($"[Рыцарь] {Name} поглотил {Armor} урона броней и получил {actualDamage} урона. Осталось HP: {HP}");
//    }
//}

//// Класс Маг
//public class Mage : ICombatant
//{
//    public string Name { get; }
//    public int HP { get; set; }
//    public int MagicPower { get; }
//    public int Mana { get; private set; }
//    public bool IsAlive => HP > 0;

//    public Mage(string name, int hp, int magicPower, int mana)
//    {
//        Name = name;
//        HP = hp;
//        MagicPower = magicPower;
//        Mana = mana;
//    }

//    public void Attack(ICombatant target)
//    {
//        if (!IsAlive) return;

//        if (Mana >= 15)
//        {
//            Mana -= 15;
//            Console.WriteLine($"[Маг] {Name} кастует заклинание в {target.Name} на {MagicPower} урона! (Осталось маны: {Mana})");
//            target.TakeDamage(MagicPower);
//        }
//        else
//        {
//            Console.WriteLine($"[Маг] У {Name} не хватает маны ({Mana}/15), бьет посохом на 5 урона!");
//            target.TakeDamage(5);
//        }
//    }

//    public void TakeDamage(int damage)
//    {
//        HP = Math.Max(0, HP - damage);
//        Console.WriteLine($"[Маг] {Name} получает {damage} чистого урона. Осталось HP: {HP}");
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        ICombatant knight = new Knight("Артур", hp: 100, attackPower: 25, armor: 8);
//        ICombatant mage = new Mage("Мерлин", hp: 75, magicPower: 35, mana: 40);

//        int round = 1;
//        while (knight.IsAlive && mage.IsAlive)
//        {
//            Console.WriteLine($"\n--- Раунд {round} ---");

//            knight.Attack(mage);
//            if (!mage.IsAlive) break;

//            mage.Attack(knight);
//            round++;
//        }

//        Console.WriteLine("\n--- Бой окончен! ---");
//        string winner = knight.IsAlive ? knight.Name : mage.Name;
//        Console.WriteLine($"Победитель: {winner}");
//    }
//}

