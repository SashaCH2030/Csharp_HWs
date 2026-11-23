public interface IDamageCalculator
{
    int CalculateDamage(int baseDamage, int armor);
}

public class StandardDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int armor)
    {
        return Math.Max(0, baseDamage - armor);
    }
}

public class CriticalDamageCalculator : IDamageCalculator
{
    private readonly Random _random = new Random();

    public int CalculateDamage(int baseDamage, int armor)
    {
        bool isCrit = _random.NextDouble() < 0.30;
        int rawDamage = isCrit ? (int)(baseDamage * 2.5) : baseDamage;

        if (isCrit)
            Console.Write(" [КРИТИЧЕСКИЙ УДАР!] ");

        return Math.Max(0, rawDamage - armor);
    }
}

public class PiercingDamageCalculator : IDamageCalculator
{
    public int CalculateDamage(int baseDamage, int armor)
    {
        int effectiveArmor = armor / 2;
        return Math.Max(0, baseDamage - effectiveArmor);
    }
}

public class DamageSystem
{
    private readonly IDamageCalculator _calculator;

    public DamageSystem(IDamageCalculator calculator)
    {
        _calculator = calculator;
    }

    public int ApplyAttack(int baseDamage, int targetArmor)
    {
        return _calculator.CalculateDamage(baseDamage, targetArmor);
    }
}

class Program
{
    static void Main()
    {
        int baseDamage = 40;
        int targetArmor = 20;

        Console.WriteLine($"Входные данные: базовый урон = {baseDamage}, броня цели = {targetArmor}\n");

        DamageSystem standardSystem = new DamageSystem(new StandardDamageCalculator());
        Console.WriteLine($"1. Обычный расчёт: {standardSystem.ApplyAttack(baseDamage, targetArmor)} урона");

        DamageSystem piercingSystem = new DamageSystem(new PiercingDamageCalculator());
        Console.WriteLine($"2. Пробивающий расчёт: {piercingSystem.ApplyAttack(baseDamage, targetArmor)} урона");

        DamageSystem critSystem = new DamageSystem(new CriticalDamageCalculator());
        Console.Write("3. Критический расчёт: ");
        int critResult = critSystem.ApplyAttack(baseDamage, targetArmor);
        Console.WriteLine($"{critResult} урона");
    }
}