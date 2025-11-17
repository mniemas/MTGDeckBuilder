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
        /*
        List<Card> cards = new List<Card>();
        LandCard ld = new LandCard("Mt", "ooo", 0.12, new List<Color>()
            { Color.RED }, "text", new List<LandType>() { LandType.MOUNTAIN });
        CreatureCard cd = new CreatureCard("abest", "ooo", 1.64, 6, "{mana}",
            new List<Color>() { Color.RED, Color.BLACK}, "text", "3", "3", "cleric");
        CreatureCard cd2 = new CreatureCard("Dels", "ooo", 1.01, 6, "{mana}",
            new List<Color>() { Color.BLACK }, "text", "3", "3", "cleric");
        CreatureCard cd3 = new CreatureCard("Aalex", "ooo", 4.05, 6, "{mana}",
            new List<Color>() { Color.BLACK }, "text", "3", "3", "cleric");
        cards.Add(ld);
        cards.Add(cd);
        cards.Add(cd2);
        cards.Add(cd3);
        */
        
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
        

        /*
        List<Card> cards3 = fs.FilterByCardType(ld, cards);
        foreach (Card c in cards3)
        {
            Console.WriteLine(c);
        }

        fs.sort(cards);
        
        */

    }
}