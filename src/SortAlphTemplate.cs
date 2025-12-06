namespace MTGDeckBuilder;

public class SortAlphTemplate : FilterSortTemplate
{
    public SortAlphTemplate() { }

    public override List<Card> sort(List<Card> currList)
    {
        currList.Sort(CompareByAlph);
        return currList;
    }

    private static int CompareByAlph(Card c1, Card c2)
    {
        return c1.name.CompareTo(c2.name);
    }
}