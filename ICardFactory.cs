namespace MTGDeckBuilder;

public interface ICardFactory
{
    // CreateCard(array of strings) - parse array for according variables
    // also may want to change manaCount for lands (maybe like mountain, swamp etc enums)?
    // manaCount is very hard to parse for
    // might actually want power/toughness as a str in the cases of * / * ?
}