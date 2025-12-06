namespace MTGDeckBuilder;

public interface IRepository
{
    public Card Search(string CardName);
    public void Add(Card card);
    public List<Card> GetAll();

}