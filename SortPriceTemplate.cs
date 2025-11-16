namespace MTGDeckBuilder;
public class SortPriceTemplate : FilterSortTemplate
{
    public SortPriceTemplate() { }

    public override List<Card> sort(List<Card> currList)
    {
        currList.Sort(CompareByPrice);
        return currList;
    }

    private static int CompareByPrice(Card c1, Card c2)
    {
        return c1.price.CompareTo(c2.price);
    }
    
}