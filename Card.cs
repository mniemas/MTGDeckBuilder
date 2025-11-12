namespace MTGDeckBuilder;

public abstract class Card
{
    private string name { get; set; }
    private double price { get; set; }
    private int convertManaCost { get; set; }
    private string manaCost { get; set; }
    private List<Color> colorIdentity { get; set; }
    private string text { get; set; }

    public Card(string name, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text)
    {
        this.name = name;
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