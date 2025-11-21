namespace MTGDeckBuilder;

public class Deck
{
    private static Deck _instance;
    public List<Card> Cards { get; private set; }
    public double Price { get; set; }

    private Deck()
    {
        Cards = new List<Card>();
        Price = 0;
    }

    public static Deck GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Deck();
        }
        return _instance;
    }

    public void Add(Card card)
    {
        Cards.Add(card);
        Price += card.price;
    }

    public void Remove(Card card)
    {
        Cards.Remove(card);
        Price -=  card.price;
    }
}