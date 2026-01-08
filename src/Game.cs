using System;
using System.Dynamic;
using System.Net.Sockets;

class Game
{
	// Private fields

	private Player player ;
	private Parser parser ;

	// Constructor
	public Game()
	{
		parser = new Parser();
		player = new Player();
		CreateRooms();
	}

	// Initialise the Rooms (and the Items)
	private void CreateRooms()
	{
		// Create the rooms
		Room outside = new Room("are outside the main entrance of the university");
		Room theatre = new Room("are in a lecture theatre");
		Room pub = new Room("are in the campus pub");
		Room lab = new Room("are in a computing lab");
		Room office = new Room("are in the computing admin office");
        Room test = new Room ("are in the test room"); 
		Room the_woods = new Room ("are in a thick forest , all alone");
		Room house = new Room ("see a log cabin");
		Room living_room= new Room ("are in a living room ");
		Room bathroom= new Room ("need to pee or something , what are you doing in the bathroom");
		Room bedroom= new Room ("are in a bedroom.");    
		

		// Initialise room exits
		outside.AddExit("east", theatre);
		outside.AddExit("south", lab);
		outside.AddExit("west", pub);
        outside.AddExit("up", test);

        test.AddExit("west", pub);
        test.AddExit("down", outside);

		theatre.AddExit("west", outside);
		theatre.AddExit("east",the_woods);


		pub.AddExit("east", outside);
      
		lab.AddExit("north", outside);
		lab.AddExit("east", office);

		the_woods.AddExit("north", house);

		
		office.AddExit("west", lab);
		
		// Create your Items here
		// ...
		// And add them to the Rooms
		// ...

		// Start game outside
	  player.currentRoom = outside;
	}

	//  Main play routine. Loops until end of play.
	public void Play()
	{
		PrintWelcome();

		// Enter the main command loop. Here we repeatedly read commands and
		// execute them until the player wants to quit.
		bool finished = false;
		while (!finished)
		{
			Command command = parser.GetCommand();
			finished = ProcessCommand(command);
		}
		Console.WriteLine("Thank you for playing.");
		Console.WriteLine("Press [Enter] to continue.");
		Console.ReadLine();
	}

	// Print out the opening message for the player.
	private void PrintWelcome()
	{
		Console.WriteLine();
		Console.WriteLine("Welcome to Zuul!");
		Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
		Console.WriteLine("Type 'help' if you need help.");
		Console.WriteLine();
	Console.WriteLine(player.currentRoom.GetLongDescription());
	}

	// Given a command, process (that is: execute) the command.
	// If this command ends the game, it returns true.
	// Otherwise false is returned.
	private bool ProcessCommand(Command command)
	{
		bool wantToQuit = false;

		if(command.IsUnknown())
		{
			Console.WriteLine("I don't know what you mean...");
			return wantToQuit; // false
		}

		switch 	(command.CommandWord)
		{	
			case "status":
			status() ;
			break;

			case "look": 
			look();
			break;
			
			case "blow": 
			    Blowup();
			  break;
			case "help":
				PrintHelp();
				break;
			case "go":
				GoRoom(command);
				break;
			case "quit":
				wantToQuit = true;
				break;
				
			

		}

		return wantToQuit;
	}

	// ######################################
	// implementations of user commands:
	// ######################################
	
	// Print out some help information.
	// Here we print the mission and a list of the command words.
	private void PrintHelp()
	{
		Console.WriteLine("You are lost. You are alone.");
		Console.WriteLine("You wander around at the university.");
		Console.WriteLine();
		// let the parser print the commands
		parser.PrintValidCommands();
	}

	// Try to go to one direction. If there is an exit, enter the new
	// room, otherwise print an error message.
	private void GoRoom(Command command)
	{
		if(!command.HasSecondWord())
		{
			// if there is no second word, we don't know where to go...
			Console.WriteLine("Go where?");
			return;
		}

		string direction = command.SecondWord;

		// Try to go to the next room.
		Room nextRoom = player.currentRoom.GetExit(direction);
		if (nextRoom == null)
		{
			Console.WriteLine("There is no door to "+direction+"!");
			return;
		}

		player.currentRoom = nextRoom;
		Console.WriteLine(player.currentRoom.GetLongDescription());
	} 
	
	private void Blowup()
	{
		Console.WriteLine("you blow up.");
		Console.WriteLine();
		 
	}
	
	private void look()
	{
		Console.WriteLine(player.currentRoom.GetLongDescription());

	} 
	
	private void status()
	{
	
		Console.WriteLine("you have " +player.health+" Life points");


    }

	
	
}
