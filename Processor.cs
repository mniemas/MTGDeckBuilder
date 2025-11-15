using System.Text.RegularExpressions;

namespace MTGDeckBuilder;

public class Processor : IProcessor
{
    private string[] cardLines {get; set;}
    
    private string[] priceLines {get; set;}
    
    public Processor(string cardFilePath, string priceFilePath)
    {
        this.cardLines = File.ReadAllLines(cardFilePath);
        this.priceLines = File.ReadAllLines(priceFilePath);
    }

    public IRepository process()
    {
        IRepository rep = new Repository();
        
        foreach (string card in cardLines)
        {
            string[] cardParts = Regex.Split(card, ",(?=(?:[^\\\"]*\\\"[^\\\"]*\\\")*[^\\\"]*$)");
            string type = cardParts[78];
            // List length: 82
            // Creature type: index 78
            ICardFactory factory = FindFactory(type);
            Card c = factory.CreateCard(cardParts);
            c.price = findPrice(c.uuid);
            rep.add(c);
        }
        return rep;
    }

    public double findPrice(string uuid)
    {
        foreach (string price in priceLines)
        {
            string[] priceParts = price.Split(',');
            if (uuid == priceParts[7])
            {
                return double.Parse(priceParts[4]);
            }
        }
        return 0;
    }
    

    public ICardFactory FindFactory(string type)
    {
        if (type.Contains("Creature"))
        {
            return new CreatureCardFactory();
        }
        else if (type.Contains("Land"))
        {
            return new LandCardFactory();
        }
        else if (type.Contains("Instant") || type.Contains("Sorcery"))
        {
            return new NonPermanentCardFactory();
        }
        else
        {
            return new PermanentCardFactory();
        }
    }
}