namespace MTGDeckBuilder;

public abstract class Card
{
    public string name { get; set; }
    public string uuid { get; set; }
    public double price { get; set; }
    public int convertManaCost { get; set; }
    private string manaCost { get; set; }
    public List<Color> colorIdentity { get; set; }
    private string text { get; set; }

    public Card(string name, string uuid, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text)
    {
        this.name = name;
        this.uuid = uuid;
        this.price = price;
        this.convertManaCost = convertManaCost;
        this.manaCost = manaCost;
        this.colorIdentity = colorIdentity;
        this.text = text;
    }

    public override string ToString()
    {
        return this.name + " - " + this.manaCost + " - $" + this.price + "\n" + this.text;
    }
}