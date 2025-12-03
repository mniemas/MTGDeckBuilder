namespace MTGDeckBuilder;

public class NonCreaturePermanentFactory : ICardFactory
{
    private List<Color> ColorParsing(string ColorList)
    {
        List<Color> ColorIdentity = new List<Color>();
        string[] ColorIter = ColorList.Split(',');
        foreach (string color in ColorIter)
        {
            char[] trim = [' ', '"'];
            string c = color.Trim(trim);
            switch (c)
            {
                case "B":
                    ColorIdentity.Add(Color.BLACK);
                    break;
                case "U":
                    ColorIdentity.Add(Color.BLUE);
                    break;
                case "R":
                    ColorIdentity.Add(Color.RED);
                    break;
                case "W":
                    ColorIdentity.Add(Color.WHITE);
                    break;
                case "G":
                    ColorIdentity.Add(Color.GREEN);
                    break;

            }
                
        }

        if (ColorIdentity.Count == 0)
        {
            ColorIdentity.Add(Color.COLORLESS);
        }
        return ColorIdentity;
    }
    
    public Card CreateCard(string[] attr)
    {
        int manaCost = 0;
        try
        {
            manaCost = (int)(double.Parse(attr[51]));
        }
        catch (Exception)
        {
            manaCost = 0;
        }
        Card ReturnCard = new PermanentCard(attr[52].Trim('"'),attr[79].Trim('"'),0,manaCost,attr[50],ColorParsing(attr[8]),attr[75].Trim('"').Trim('"'),attr[77].Trim('"'));
        return ReturnCard;
    }
}