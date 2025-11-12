namespace MTGDeckBuilder;

public class NonPermanentCard : NonCreatureCard
{
    public NonPermanentCard(string name, double price, int convertManaCost, string manaCost, List<Color> colorIdentity, string text, string type) : base(name, price,  convertManaCost, manaCost, colorIdentity, text, type)
    {
    }
    
    public override string ToString()
    {
        return base.ToString() + "\nPermanent";
    }
}