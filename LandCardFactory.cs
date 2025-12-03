namespace MTGDeckBuilder;

public class LandCardFactory : ICardFactory
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
    
    private List<LandType> LandParsing(string Lands)
    {
        List<LandType> LandTypes = new List<LandType>();
        char[] toTrim = { ' ', '"' };
        string[] iter = Lands.Split(',');
        if (iter.Length < 1)
        {
            return LandTypes;
        } 
        else {
            foreach (string land in iter)
            {
                switch (land.Trim(toTrim))
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
        
        Card ReturnCard = new LandCard(attr[52].Trim('"'),attr[79].Trim('"'),0,ColorParsing(attr[8]),attr[75].Trim('"').Trim('"'),LandParsing(attr[73]));
        return ReturnCard;
        

    }
}