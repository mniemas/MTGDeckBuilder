namespace MTGDeckBuilder;

class Program
{
    static void Main(string[] args)
    {
        Processor p = new Processor("C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\cards.txt",
            "C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\prices.txt");
        p.process();
    }
}