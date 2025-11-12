namespace MTGDeckBuilder;

public struct Stats
{
    private int power { get; set; }
    private int toughness { get; set; }

    public Stats(int power, int toughness)
    {
        this.power = power;
        this.toughness = toughness;
    }

    public override string ToString()
    {
        return this.power + " /  " + this.toughness;
    }
}