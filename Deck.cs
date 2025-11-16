namespace MTGDeckBuilder;

public class Deck
{
    public List<Card> Cards { get; private set; }
    private Deck(List<Card> cards) {Cards = cards;}

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    public void Remove(Card card)
    {
        Cards.Remove(card);
    }
}