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
  - Price Dictionary 
    - File Name: Processor.cs
    - Line Numbers: line 9, 17-28, 49
    - Reasoning/Purpose: The prices of cards are mapped to their UID for easy
    - access when building cards. This prevents the program from having to
    - perform another loop to access the correct price by UID.
- I/O:
  - User Input and Program Output
    - File Name: Program.cs
    - Line Numbers: 
      - Input: line 17, 19, 47, 71, 82, 120, 145, 153, 190, 218, 239
      - Output: line 16-282
    - Reasoning/Purpose: The program takes in input for the file path's of
    - data to build from, and numbered commands for the user to take actions
    - and control the filters in the program. The output is used to display
    - the proper information.

Design Patterns
- Singleton
  - Category: Creational
  - File Name: Deck.cs
  - Line Numbers: all
  - Reasoning/Purpose: Only one Deck should be created per run of the program. 
  - The Singleton pattern ensures this occurs by making the constructor private
  - and only creating if an instance does not exist.
- Factory
  - Category: Creational
  - File Name: ICardFactory.cs, CreatureCardFactory.cs, 
  - LandCardFactory.cs, NonCreaturePermanentFactory.cs
  - Line Numbers: all
  - Reasoning/Purpose: The Factory method is used to offload the complexity of 
  - creating cards from the Processor.cs to a dedicated class. This allows the
  - project to more accurately follow the Single Responsibility principle.
- Template
  - Category: Behavioral
  - File Name: FilterSortTemplate.cs, SortAlphTemplate.cs, SortPriceTemplate.cs
  - Line Numbers: all
  - Reasoning/Purpose: The Template method is used to preserve the general logic
  - steps of filtering, while also allowing for different sorting methods. Since 
  - only one step differs, it made sense to use the Factory method.

Design Decisions
- Overall Function
  - The program starts with the Processor class (implementing IProcessor) taking in
  - file paths and parsing data from these files to create Cards. It uses the ICardFactory
  - to offload creation logic, and adds the resulting card to the newly made Repository,
  - returning the Repository when done. The Card class contains the Color enum, and the 
  - CreatureCard subclass contains the Stats struct. After obtaining the Repository, the
  - main program prompts the user for filter data. The main program prompts for a sorting type,
  - and then creates a FilterSortTemplate object of the according type and calls FilterSort(),
  - passing in the filters given by the user. It returns a filtered and sorted list, which the
  - main program then displays. Lastly, the user can Add or Remove from the Deck created in the
  - main program, which holds a List of Cards and totals their prices.
- Card Types as Subclasses
  - Instead of adding card types as enums, as done with colors, this program
  - has classes for each card type. This allows for easier extension as to add
  - a new card type, the programmer only has to add a new class. They do, however
  - also have to add this logic to the Processor class. But even if the processor
  - class is unaltered, it does not break the program as it defaults to NonCreaturePerm
  - if type is not found.
- Repository Vs. Processor
  - The processor and repository are seperated into different classes to follow the
  - Single Responsibility Principle. Rather than the Processor creating, storing, and
  - searching the master list of cards - these tasks are divided. It is the processor's
  - responsibility to create the cards, while it is repository's responsibility to
  - store and search for cards.
- Abstractions
  - The main Card class is abstract to prevent an untyped card from being created, and 
  - to ensure every class that depends on the Card depends on an abstraction rather than 
  - a concrete class. A similar logic applies to the FilterSortTemplate, ensuring a class
  - with no specific sorting method is never created, and allows for dependencies on the 
  - abstract superclass. ICardFactory, IRepository, and IProcessor are all abstract for
  - this same rationale - so other classes can depend on abstractions.
