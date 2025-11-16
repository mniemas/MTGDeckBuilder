namespace MTGDeckBuilder;

public struct Stats
{
    private string power { get; set; }
    private string toughness { get; set; }

    public Stats(string power, string toughness)
    {
        this.power = power;
        this.toughness = toughness;
    }

    public override string ToString()
    {
        return this.power + " /  " + this.toughness;
    }
}