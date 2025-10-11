namespace Project3_Prototype;

public class Image(string url) : IPrototype
{
    public string Url { get; private set; } = url;

    public IPrototype Clone() => new Image(Url);

    public override string ToString() => $"Изображение: {Url}";
}