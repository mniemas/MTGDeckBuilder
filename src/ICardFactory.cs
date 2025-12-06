namespace MTGDeckBuilder;

public interface ICardFactory
{
    public Card CreateCard(string[] attr);
}