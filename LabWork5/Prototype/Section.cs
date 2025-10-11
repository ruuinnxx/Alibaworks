namespace Project3_Prototype;

public class Section(string title, string text) : IPrototype
{
    public string Title { get; private set; } = title;
    public string Text { get; private set; } = text;


    public IPrototype Clone() =>
        new Section(Title, Text);

    public override string ToString() =>
        $"Раздел {Title}, текст {Text}";
}
