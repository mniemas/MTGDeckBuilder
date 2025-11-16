namespace MTGDeckBuilder;

public class LandCardFactory : ICardFactory
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
    
    private List<LandType> LandParsing(string Lands)
    {
        List<LandType> LandTypes = new List<LandType>();
        string[] iter = Lands.Split(',');
        if (iter.Length < 1)
        {
            return LandTypes;
        } 
        else {
            foreach (string land in iter)
            {
                switch (land)
                {
                    case "Forest":
                        LandTypes.Add(LandType.FOREST);
                        break;
                    case "Mountain":
                        LandTypes.Add(LandType.MOUNTAIN);
                        break;
                    case "Swamp":
                        LandTypes.Add(LandType.SWAMP);
                        break;
                    case "Island":
                        LandTypes.Add(LandType.ISLAND);
                        break;
                    case "Plains":
                        LandTypes.Add(LandType.PLAINS);
                        break;

                }
            }
        }

        return  LandTypes;
    }
    
    public Card CreateCard(string[] attr)
    {
        
        Card ReturnCard = new LandCard(attr[52],attr[79],double.Parse(attr[58]),ColorParsing(attr[8]),attr[75],LandParsing(attr[73]));
        return ReturnCard;
        

    }
}