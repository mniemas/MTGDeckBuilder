using System.Runtime.InteropServices;

namespace MTGDeckBuilder;

public class Repository : IRepository
{
    
    public List<Card> Cards { get; set; }

    public void Add(Card card)
    {
        Cards.Add(card);
    }

    public List<Card> Filter(bool[] filter, string[] Query, Card CardTypeQuery, FilterSortTemplate SortMethod)
    {

        List<Card> ReturnList;
        Card TypeFilter;
        if (filter[0] == false)
        {
            TypeFilter = null;
        }
        else
        {
            TypeFilter = CardTypeQuery; 
        }

    int CMCFilter;
        if (Query[1] == "" || filter[1] == false)
        {
            CMCFilter = 0;
        }
        else
        {
            CMCFilter = int.Parse(Query[1]);
        }
        string ColorFilter;
        if (filter[3] == false)
        {
            ColorFilter = null;
        }
        else
        {
            ColorFilter = Query[2];
        }
        double PriceFilter;
        if (Query[3] == "" || filter[2] == false)
        {
            PriceFilter = 0;
        }
        else
        {
            PriceFilter = int.Parse(Query[3]);
        }
        switch (SortMethod)
        {
            case (SortPriceTemplate):

                ReturnList = SortMethod.FilterSort(PriceFilter,ColorFilter,CMCFilter,TypeFilter,Cards);
                        
                break;
            case (SortAlphTemplate):
                ReturnList = SortMethod.FilterSort(PriceFilter,ColorFilter,CMCFilter,TypeFilter,Cards);
                break;
            default:
                Console.WriteLine("ERROR: Invalid input");
                break;
            }
        try
        {
            return ReturnList;
        }
        catch (Exception e)
        {
            Console.WriteLine("There are no search results for this query.");
            throw;
        };
    }



    public Card Search(string CardName)
    {
        foreach (Card card in Cards)
        {
            if (card.name == CardName)
            {
                return card;
            }
        }
        return null;
    }
}