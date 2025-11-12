using System.Transactions;

namespace MTGDeckBuilder;

public class LandCard : Card
{
    private string manaCount { get; set; }
    
    public LandCard(string name, double price, List<Color> colorIdentity, string text, string manaCount) : base(name, price,  0, "", colorIdentity, text){
        this.manaCount = manaCount;
    }
    
    public override string ToString()
    {
        return base.ToString() + "Taps for " + manaCount + " Mana";
    }
}