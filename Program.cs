namespace MTGDeckBuilder;

class Program
{
    static void Main(string[] args)
    {
        // testing
        Processor p = new Processor("C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\cards.txt",
            "C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\prices.txt");
        Console.WriteLine("Processing starting");
        List<Card> cards = p.process();
        Console.WriteLine("Processing done");
        
        // filter testing
        SortAlphTemplate fs  = new SortAlphTemplate();
        Console.WriteLine("Before: " + cards.Count);
        cards = fs.FilterByColor(new  List<Color>() { Color.RED, Color.BLUE }, cards);
        Console.WriteLine("After color: " + cards.Count);
        cards = fs.FilterByConvertManaCost(4, cards);
        Console.WriteLine("After cmc: " + cards.Count);
        cards = fs.FilterByCardType(new CreatureCard("hold", "1", 10, 
            5, "w", new List<Color>() { Color.BLACK }, "text", "3", "3", "Human"), cards);
        Console.WriteLine("After type: " + cards.Count);
        cards = fs.FilterByPrice(20, cards);
        Console.WriteLine("After price: " + cards.Count);
        fs.sort(cards);
        foreach (Card c in cards)
        {
            Console.WriteLine("");
            Console.WriteLine(c);
        }

    }
}