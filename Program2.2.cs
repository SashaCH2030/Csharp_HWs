//public class Character
//{
//    public string Name { get; }
//    public int HP { get; set; }

//    public Character(string name, int hp)
//    {
//        Name = name;
//        HP = hp;
//    }
//}

//public interface IUsableItem
//{
//    string Name { get; }
//    void Use(Character user);
//}

//public interface IEquippable
//{
//    bool IsEquipped { get; }
//    void Equip(Character user);
//    void Unequip(Character user);
//}

//public interface IConsumable
//{
//    int Charges { get; }
//}

//public class HealthPotion : IUsableItem, IConsumable
//{
//    public string Name { get; }
//    public int HealAmount { get; }
//    public int Charges { get; private set; }

//    public HealthPotion(string name, int healAmount, int charges)
//    {
//        Name = name;
//        HealAmount = healAmount;
//        Charges = charges;
//    }

//    public void Use(Character user)
//    {
//        if (Charges <= 0)
//        {
//            Console.WriteLine($"[Зелье] В «{Name}» больше не осталось зарядов!");
//            return;
//        }

//        Charges--;
//        user.HP += HealAmount;
//        Console.WriteLine($"[Зелье] {user.Name} выпил «{Name}» (+{HealAmount} HP). Текущее HP: {user.HP}. Осталось зарядов: {Charges}");
//    }
//}

//public class Sword : IUsableItem, IEquippable
//{
//    public string Name { get; }
//    public int DamageBonus { get; }
//    public bool IsEquipped { get; private set; }

//    public Sword(string name, int damageBonus)
//    {
//        Name = name;
//        DamageBonus = damageBonus;
//    }

//    public void Equip(Character user)
//    {
//        IsEquipped = true;
//        Console.WriteLine($"[Оружие] {user.Name} экипировал «{Name}» (+{DamageBonus} к урону).");
//    }

//    public void Unequip(Character user)
//    {
//        IsEquipped = false;
//        Console.WriteLine($"[Оружие] {user.Name} убрал «{Name}» в ножны.");
//    }

//    public void Use(Character user)
//    {
//        if (!IsEquipped)
//            Equip(user);
//        else
//            Unequip(user);
//    }
//}

//public class AncientScroll : IUsableItem, IConsumable
//{
//    public string Name { get; }
//    public string SpellEffect { get; }
//    public int Charges { get; private set; } = 1;

//    public AncientScroll(string name, string spellEffect)
//    {
//        Name = name;
//        SpellEffect = spellEffect;
//    }

//    public void Use(Character user)
//    {
//        if (Charges <= 0)
//        {
//            Console.WriteLine($"[Свиток] «{Name}» уже рассыпался в прах.");
//            return;
//        }

//        Charges--;
//        Console.WriteLine($"[Свиток] {user.Name} читает «{Name}» и активирует эффект: {SpellEffect}! (Зарядов: {Charges})");
//    }
//}

//public class Inventory
//{
//    private readonly List<IUsableItem> _items = new List<IUsableItem>();

//    public void AddItem(IUsableItem item) => _items.Add(item);

//    public void UseAll(Character user)
//    {
//        Console.WriteLine($"\n--- {user.Name} использует все предметы в инвентаре ---");
//        foreach (var item in _items)
//        {
//            item.Use(user);
//        }
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Character hero = new Character("Геральт", 60);
//        Inventory inventory = new Inventory();

//        inventory.AddItem(new HealthPotion("Ласточка", healAmount: 30, charges: 2));
//        inventory.AddItem(new Sword("Серебряный меч", damageBonus: 15));
//        inventory.AddItem(new AncientScroll("Свиток Игни", "Огненная волна по области"));

//        inventory.UseAll(hero);

//        inventory.UseAll(hero);
//    }
//}

