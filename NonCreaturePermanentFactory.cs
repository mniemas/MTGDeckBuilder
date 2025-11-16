namespace MTGDeckBuilder;

public class NonCreaturePermanentFactory : ICardFactory
{
    private List<Color> ColorParsing(string ColorList)
    {
        List<Color> ColorIdentity = new List<Color>();
        string[] ColorIter = ColorList.Split(',');
        if (ColorIter.Length < 1)
        {
            ColorIdentity.Add(Color.COLORLESS);
        } 
        else {
            foreach (string color in ColorIter)
            {
                switch (color)
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
        }
        return ColorIdentity;
    }
    
    public Card CreateCard(string[] attr)
    {
        Card ReturnCard = new PermanentCard(attr[52],attr[79],double.Parse(attr[58]),int.Parse(attr[15]),attr[50],ColorParsing(attr[8]),attr[75],attr[77]);
        return ReturnCard;
    }
}