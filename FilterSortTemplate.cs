namespace MTGDeckBuilder;

public abstract class FilterSortTemplate
{
    public List<Card> FilterSort(string filter, List<Card> currList)
    {
        return sort(currList);
        // NOT DONE

    }

    
    public List<Card> FilterByPrice(double price, List<Card> currList)
    {
        List<Card> result = new List<Card>();
        foreach (Card card in currList)
        {
            if (price >= card.price)
            {
                result.Add(card);
            }
        }
        return result;
    }
    
    public List<Card> FilterByColor(List<Color> colors, List<Card> currList)
    {
        List<Card> result = new List<Card>();
        bool add = false;
        foreach (Card card in currList)
        {
            add = true;
            if (colors.Count == card.colorIdentity.Count)
            {
                foreach (Color color in colors)
                {
                    if (!(card.colorIdentity.Contains(color)))
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    result.Add(card);
                }
            }
        }
        return result;
    }
    
    
    public List<Card> FilterByConvertManaCost(int mana, List<Card> currList)
    {
        List<Card> result = new List<Card>();
        foreach (Card card in currList)
        {
            if (mana >= card.convertManaCost)
            {
                result.Add(card);
            }
        }
        return result;
    }

    public List<Card> FilterByCardType(Card c, List<Card> currList)
    {
        List<Card> result = new List<Card>();
        foreach (Card card in currList)
        {
            if (c.GetType() == card.GetType())
            {
                result.Add(card);
            }
        }
        return result;
    }
    
    public abstract List<Card> sort(List<Card> currList);
    
}