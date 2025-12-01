namespace MTGDeckBuilder;

public interface IRepository
{
    public Card Search(string CardName);

    public List<Card> Filter(bool[] Filter, string[] Query, Card CardTypeQuery, FilterSortTemplate SortMethod);
    
}