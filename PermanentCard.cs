namespace MTGDeckBuilder;

public class PermanentCard : NonCreatureCard
{
    public PermanentCard(string name, string uuid, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text, string type) : base(name,  uuid, price,  convertManaCost, manaCost, colorIdentity, text, type)
    {
    }
    
    public override string ToString()
    {
        return base.ToString() + "\nPermanent";
    }
}