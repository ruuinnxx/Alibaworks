namespace Project3_Prototype;

public class Weapon(string name, int damage) : IMyClonable<Weapon>
{
    public string Name { get; set; } = name;
    public int Damage { get; set; } = damage;

    public Weapon Clone() => new(Name, Damage);

    public override string ToString() => $"{Name} (урон: {Damage})";
}