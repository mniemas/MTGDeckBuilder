using System.Transactions;

namespace MTGDeckBuilder;

public class LandCard : Card
{
    private List<LandType> landType { get; set; }

    public LandCard() : base()
    {
        landType = new List<LandType>();
    }
    public LandCard(string name, string uuid, double price, List<Color> colorIdentity, string text, List<LandType> landType) : base(name, uuid, price,  0, "", colorIdentity, text){
        this.landType = landType;
    }
    
    public override string ToString()
    {
        string result = base.ToString() + "\nIs a ";
        foreach (LandType lt in landType)
        {
            result += lt.ToString() + " ";
        }

        return result;
    }
}