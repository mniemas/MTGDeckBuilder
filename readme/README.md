Project Overview
This project is a card filtering and deck building tool for Magic: The Gathering. 
The program allows users to filter by card type, converted mana cost, price, and color.
The user is able to add and remove cards to a deck using their name.
The deck tracks the total price as cards are added and removed.
The files for card prices and data must be formatted the same as cards are in
the AllPrintings.csv on mtgjson.com. 

Build & Run Instructions 
Tools & Build:
- JetBrains Rider: 2025.2
- .NET SDK: 9.0.304
- C# Compiler: Roslyn (from .NET SDK 9.0.304)
- Build Tool: MSBuild 17.14.16
Run Instructions:
- Download all files.
- Compile using IDE and C# complier.
- Run Program.cs.
- When prompted, input full file path for cards.txt and prices.txt.
  - If you wish to use an updated card and price list, download updated files from mtgjson.com 
  - Download AllPrintingsCSV files zip, and use cards.txt in zip as card data, and cardPrices as
  - price data. Paste full file path of new files.
- Filter according to preferences, use Filter command when finished.
- Add and remove to deck.
- Exit program (5) when finished.

OOP Features
- Inheritance:
  - Card Subclasses
    - File Name: Card.cs, CreatureCard.cs, LandCard.cs, NonCreatureCard.cs
    - Line Numbers: all, line 3, line 5, line 3
    - Reasoning/Purpose: Creature, Land, and NonCreature Card inherit from Card 
    - to share common attributes.
  - FilterSort Subclasses
    - File Name: FilterSortTemplate.cs, SortAlphTemplate.cs, SortPriceTemplate.cs
    - Line Numbers: all, line 3, line 2
    - Reasoning/Purpose: SortAlphTemplate and SortPriceTemplate inherit from 
    - FilterSortTemplate to override sort() method while keeping same general 
    - filtering steps.
- Interfaces:
  - ICardFactory
    - File Name: ICardFactory.cs
    - Line Numbers: all
    - Reasoning/Purpose: ICardFactory defines how all classes that implement it 
    - (CardFactory classes) should have a method that creates (and returns) a card 
    - given an array of strings. 
  - IProcessor
    - File Name: IProcessor.cs
    - Line Numbers: all
    - Reasoning/Purpose: Defines how processor classes must have a method that
    - processes cards into an IRepository and returns that object.
  - IRepository
    - File Name: IRepository.cs
    - Line Numbers: all
    - Reasoning/Purpose: Defines how Repository implements must be able to search
    - for a Card by name and return it, add a Card to the greater list, and return
    - the full list of Cards.
- Polymorphism:
  - CardList
    - File Name: Processor.cs
    - Line Numbers: line 37, 58
    - Reasoning/Purpose: All Card Subclasses can be stored in the same 
    - list, as they are all Card objects.
  - FilterSort Method Calling
    - File Name: Program.cs
    - Line Numbers: line 189, 198, 203, 213
    - Reasoning/Purpose: FilterSort subclasses can act as their super FilterSort class,
    - while still calling the correct sort() method within the class.
- Access Modifiers:
  - Card Fields:
    - File Name: Card.cs, CreatureCard.cs, LandCard.cs, NonCreatureCard.cs
    - Line Numbers: line 5-11, line 5-6, line 7, line 5
    - Reasoning/Purpose: Variables that do not need to accessed outside the 
    - class are made private to prevent unintended access, others are made
    - public.
  - Deck Privatization:
    - File Name: Deck.cs
    - Line Numbers: line 9-14
    - Reasoning/Purpose: Deck constructor is private to implement Singleton.
  - FilterSort Private Methods:
    - File Name: FilterSortTemplate.cs
    - Line Numbers: line 60-124
    - Reasoning/Purpose: Specific filtering methods do not need to be accessed
    - outside the class, as they are called in the Template method, and so are
    - made private.
- Struct:
  - Stats Struct
    - File Name: Stats.cs
    - Line Numbers: all
    - Reasoning/Purpose: Stats struct use to store the power and toughness
    - of Creature Cards.
- Enum:
  - Color Enum
    - File Name: Color.cs
    - Line Numbers: all
    - Reasoning/Purpose: Color enum used to represent Color Identity of cards.
- Data Structure:
- I/O:

Design Patterns

Design Decisions
