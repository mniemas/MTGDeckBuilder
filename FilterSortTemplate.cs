namespace MTGDeckBuilder;

public abstract class FilterSortTemplate
{
    public List<Card> FilterSort(double price, string colors, int cmc, Card c, List<Card> currList)
    {
        if (price >= 0)
        {
            currList = FilterByPrice(price, currList);
        }
        if (colors != null)
        {
            List<Color> colorList = new List<Color>();
            if(colors.Contains("CL"))
            {
                colorList.Add(Color.COLORLESS);
            }
            else
            {
                if (colors.Contains("B"))
                {
                    colorList.Add(Color.BLACK);
                }

                if (colors.Contains("U"))
                {
                    colorList.Add(Color.BLUE);
                }

                if (colors.Contains("R"))
                {
                    colorList.Add(Color.RED);
                }

                if (colors.Contains("G"))
                {
                    colorList.Add(Color.GREEN);
                }

                if (colors.Contains("W"))
                {
                    colorList.Add(Color.WHITE);
                }
            }
            currList = FilterByColor(colorList, currList);
        }
        if (cmc >= 0)
        {
            currList = FilterByConvertManaCost(cmc,  currList);
        }
        if (c != null)
        {
            currList = FilterByCardType(c, currList);
        }
        
        return sort(currList);
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