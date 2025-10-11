namespace Project3_Prototype;

public class Skill(string name, string type) : IMyClonable<Skill>
{
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;

    public Skill Clone() => new(Name, Type);

    public override string ToString() => $"{Name} [{Type}]";
}