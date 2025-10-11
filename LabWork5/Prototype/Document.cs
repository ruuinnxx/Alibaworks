using System.Text;

namespace Project3_Prototype;

public class Document(string title, string content) : IPrototype
{

    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public List<Section> Sections { get; private set; } = new ();
    public List<Image> Images { get; private set; } = new ();

    public void AddSection(Section section) =>
        Sections.Add(section);

    public void AddImage(Image image) =>
        Images.Add(image);
    
    public IPrototype Clone()
    {
        Document clone = new Document(Title, Content);

        foreach (var section in Sections)
            clone.AddSection((Section)section.Clone());
        
        foreach (var image in Images)
            clone.AddImage((Image)image.Clone());

        return clone;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"Документ: {Title}");
        sb.AppendLine($"Контетн: {Content}");
        
        foreach (var section in Sections)
            sb.AppendLine(" " + section);

        foreach (var image in Images)
            sb.AppendLine(" " + image);

        return sb.ToString();
    }
}