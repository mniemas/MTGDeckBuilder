namespace MTGDeckBuilder;

public abstract class NonCreatureCard : Card
{
    private string type { get; set; }
    
    public NonCreatureCard(string name, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text, string type) : base(name, price,  convertManaCost, manaCost, colorIdentity, text)
    {
        this.type = type;
    }
    
    public override string ToString()
    {
        return base.ToString() + "\nCard Type: " + this.type;
    }
}