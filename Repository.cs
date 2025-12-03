using System.Runtime.InteropServices;

namespace MTGDeckBuilder;

public class Repository : IRepository
{
    
    public List<Card> Cards { get; set; }

    public Repository()
    {
        Cards = new List<Card>();
    }

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    public List<Card> GetAll()
    {
        return Cards;
    }
    
    public Card Search(string CardName)
    {
        foreach (Card card in Cards)
        {
            if (card.name == CardName)
            {
                return card;
            }
        }
        return null;
    }
}