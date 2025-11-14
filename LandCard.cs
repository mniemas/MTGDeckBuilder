using System.Transactions;

namespace MTGDeckBuilder;

public class LandCard : Card
{
    private List<LandType> landType { get; set; }
    
    public LandCard(string name, string uuid, double price, List<Color> colorIdentity, string text, List<LandType> landType) : base(name, uuid, price,  0, "", colorIdentity, text){
        this.landType = landType;
    }
    
    public override string ToString()
    {
        return base.ToString() + "Is a " + this.landType.ToString();;
    }
}