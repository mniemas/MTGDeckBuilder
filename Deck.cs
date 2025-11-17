namespace MTGDeckBuilder;

public class Deck
{
    public List<Card> Cards { get; private set; }
    public double Price { get; set; }

    private Deck(List<Card> cards)
    {
        Cards = cards;
        foreach (Card card in cards)
        {
            Price += card.price;
        }
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