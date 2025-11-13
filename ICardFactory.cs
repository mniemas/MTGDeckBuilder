namespace MTGDeckBuilder;

public interface ICardFactory
{
    // think we might want CreateCard to actually take in parameters lmao
    // should prob take in every parameter (some can be null) bc they all have
    // to use same CreateCard
    // Sorta like:
    // public Card CreateCard(string name, double price, int convertManaCost,
    //    string manaCost, ArrayList<Color> colorIdentity, string text, int manaCount, int power,
    //    int toughness, string type)
    // then just not use the unneeded things in each subclass?
    // also may want to change manaCount for lands (maybe like mountain, swamp etc enums)?
    // manaCount is very hard to parse for
    // might actually want power/toughness as a str in the cases of * / * ?
}