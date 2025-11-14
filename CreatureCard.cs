namespace MTGDeckBuilder;

public class CreatureCard : Card
{
    private Stats stats { get; set; }
    private string type { get; set; }
    
    public CreatureCard(string name, string uuid, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text, int power, int toughness, string type) : base(name, uuid, price,  convertManaCost, manaCost, colorIdentity, text)
    {
        this.stats = new Stats(power, toughness);
        this.type = type;
    }
    
    public override string ToString()
    {
        return base.ToString() + "\nCreature Type: " + this.type + "    " + this.stats.ToString();
    }
}