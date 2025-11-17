using System.Text.RegularExpressions;

namespace MTGDeckBuilder;

public class Processor : IProcessor
{
    private string[] cardLines {get; set;}
    private string[] priceLines {get; set;}
    private Dictionary<string, double> prices { get; set;}
    
    public Processor(string cardFilePath, string priceFilePath)
    {
        this.cardLines = File.ReadAllLines(cardFilePath);
        this.priceLines = File.ReadAllLines(priceFilePath);
        this.prices  = new Dictionary<string, double>();
        int i = 0;
        foreach (string line in this.priceLines)
        {
            
            string[] priceParts = line.Split(',');

            try
            {
                prices.Add(priceParts[7], double.Parse(priceParts[4]));
            }
            catch (Exception e)
            {
            }
        }
    }
    

    
    public List<Card> process()
    {
        //IRepository rep = new Repository();
        List<Card> cards = new List<Card>();
        int i = 0;
        
        foreach (string card in cardLines)
        {
            string[] cardParts = Regex.Split(card, ",(?=(?:[^\\\"]*\\\"[^\\\"]*\\\")*[^\\\"]*$)");
            string type = cardParts[78];
            ICardFactory factory = FindFactory(type);
            Card c = factory.CreateCard(cardParts);
            double price = 0;
            try
            {
                price = prices[c.uuid];
            }
            catch (Exception e)
            {
                price = 0;
            }
            c.price = price;
            
            //rep.add(c);
            cards.Add(c);
            
            //testing
            i++;
            Console.WriteLine(cardParts[8]);
            Console.WriteLine("Card " + i + " / " + cardLines.Length + " " + c.colorIdentity.Count);
        }
        //return rep;
        return cards;  // temp return until rep implemented
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
            return new NonPermanentFactory();
        }
        else
        {
            return new NonCreaturePermanentFactory();
        }
    }
    
}