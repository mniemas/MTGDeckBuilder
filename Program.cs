namespace MTGDeckBuilder;

class Program
{
    static void Main(string[] args)
    {
        bool noFiles = true;
        string filePath = "";
        string pricePath = "";
        
        Deck deck = Deck.GetInstance();
        
        Processor p;
        while (noFiles)
        {
            Console.Write("Please enter the full file path for the card data: ");
            filePath = Console.ReadLine();
            Console.Write("Please enter the full file path for price data: ");
            pricePath = Console.ReadLine();
            try
            {
                Console.WriteLine("Loading...");
                p = new Processor(filePath, pricePath);
                noFiles = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid file path.");
            }
        }
        
        // testing
        //Processor p = new Processor("C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\cards.txt",
        //    "C:\\\\Users\\\\ivyni\\\\RiderProjects\\\\MTGDeckBuilder\\\\prices.txt");
        
        // C:\\Users\\ivyni\\RiderProjects\\MTGDeckBuilder\\cards.txt
        // C:\\Users\\ivyni\\RiderProjects\\MTGDeckBuilder\\prices.txt
        p = new Processor(filePath, pricePath);
        Console.WriteLine("Processing starting");
        Repository rep = p.process();
        Console.WriteLine("Processing done");

        bool active = true;
        while (active)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Filter for cards");
            Console.WriteLine("2. Add to deck");
            Console.WriteLine("3. Remove from deck");
            Console.WriteLine("4. Display deck");
            Console.WriteLine("5. Exit");
            String input = Console.ReadLine();
            String[] Query;
            bool[] filts = [false, false, false, false];
            if (input == "1")
            {
                bool filtering = true;
                
                double price = -1;
                string priceFil = "";
                
                string colors = null;
                
                int cmc = -1;
                string cmcFil = "";
                
                Card c = null;
                String cardFil = "";
                
                while (filtering)
                {
                    Console.WriteLine("What would you like to filter for?");
                    Console.WriteLine("1. Card type");
                    Console.WriteLine("2. Converted mana cost");
                    Console.WriteLine("3. Color");
                    Console.WriteLine("4. Price");
                    Console.WriteLine("5. Filter");
                    String filterIn = Console.ReadLine();
                    if (filterIn == "1")
                    {

                        bool cardFilter = true;
                        while (cardFilter)
                        {
                            Console.WriteLine("What card type would you like to filter for?");
                            Console.WriteLine("1. Creature");
                            Console.WriteLine("2. Land");
                            Console.WriteLine("3. Non-Creature Permanent (Artifact, Enchantment, etc.)");
                            Console.WriteLine("4. Non-Permanent (Instant, Sorcery)");
                            String cardTypeIn = Console.ReadLine();
                            if (cardTypeIn == "1")
                            {
                                c = new CreatureCard();
                                cardFilter = false;
                                cardFil = "Creature";
                                filts[0] = true;

                            }
                            else if (cardTypeIn == "2")
                            {
                                c = new LandCard();
                                cardFilter = false;
                                cardFil = "Land";
                                filts[0] = true;
                            }
                            else if (cardTypeIn == "3")
                            {
                                c = new PermanentCard();
                                cardFilter = false;
                                cardFil = "Non-Creature Permanent";
                                filts[0] = true;
                            }
                            else if (cardTypeIn == "4")
                            {
                                c = new NonPermanentCard();
                                cardFilter = false;
                                cardFil = "Non-Permanent";
                                filts[0] = true;
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }
                    }
                    else if (filterIn == "2")
                    {
                        bool cmcFilter = true;
                        while (cmcFilter)
                        {
                            Console.WriteLine("What max cmc do you want to filter for?");
                            String cmcIn = Console.ReadLine();
                            try
                            {
                                cmcFil = cmcIn;
                                cmc = int.Parse(cmcIn);
                                cmcFilter = false;
                                filts[1] = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }

                    }
                    else if (filterIn == "3")
                    {
                        Console.WriteLine("What colors do you want to filter for?");
                        Console.WriteLine("Enter:");
                        Console.WriteLine("     W: White");
                        Console.WriteLine("     U: Blue");
                        Console.WriteLine("     B: Black");
                        Console.WriteLine("     G: Green");
                        Console.WriteLine("     R: Red");
                        Console.WriteLine("     CL: Colorless");
                        Console.WriteLine("Example: RB");
                        colors = Console.ReadLine();
                        filts[2] = true;
                    }
                    else if (filterIn == "4")
                    {
                        bool priceFilter = true;
                        while (priceFilter)
                        {
                            Console.WriteLine("What max price do you want to filter for?");
                            String priceIn = Console.ReadLine();
                            try
                            {
                                priceFil = priceIn;
                                price = double.Parse(priceIn);
                                priceFilter = false;
                                filts[3] = true;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Invalid input.");
                            }
                        }

                    }
                    else if (filterIn == "5")
                    {
                        filtering = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }

                    Console.WriteLine("Filters: ");
                    Console.WriteLine("     Card Type: " + cardFil);
                    Console.WriteLine("     CMC: " + cmcFil);
                    Console.WriteLine("     Color: " + colors);
                    Console.WriteLine("     Price: $" + priceFil);
                    Query = [cardFil, cmcFil, colors, priceFil];
                }

                bool sortingAsk = true;
                FilterSortTemplate fs = new SortAlphTemplate();
                while (sortingAsk)
                {
                    Console.WriteLine("How would you like to sort?");
                    Console.WriteLine("1. Alphabetically");
                    Console.WriteLine("2. By Price");
                    String sortingIn = Console.ReadLine();
                    if (sortingIn == "1")
                    {
                        fs = new SortAlphTemplate();
                        sortingAsk = false;
                    }
                    else if (sortingIn == "2")
                    {
                        fs = new SortPriceTemplate();
                        sortingAsk = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                
                Console.WriteLine("Filtering...");
                List<Card> filtered = rep.Filter(filts,Query,c,fs);
                printCards(filtered);
                
            }
            else if (input == "2")
            {
                Console.Write("Enter card name to add: ");
                String name = Console.ReadLine();
                // REPOSITORY STUFF
                deck.Add(rep.Search(name));
            }
            else if (input == "3")
            {
                // REPOSITORY STUFF
            }
            else if (input == "4")
            {
                Console.WriteLine("Deck:");
                printCards(deck.Cards);
            }
            else if (input == "5")
            {
                Console.WriteLine("Goodbye!");
                active = false;
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            
        }

    }

    public static void printCards(List<Card> cards)
    {
        foreach (Card card in cards)
        {
            Console.WriteLine(card);
            Console.WriteLine("");
        }
    }
}