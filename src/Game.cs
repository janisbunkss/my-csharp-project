using System;

namespace MyCSharpProject
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;

        public Game()
        {
            player = new Player("Player", 100);

            Room room1 = new Room("You are in a messy dungeon. There is a diamond sword on the ground nearby.");
            Room room2 = new Room("You are in an unlit dungeon. There is a gold sword on the ground nearby.");
            Room room3 = new Room("You are in a dark dungeon. There is a wooden sword on the ground nearby.");

            room1.AddItem("diamond sword");
            room2.AddItem("gold sword");
            room3.AddItem("wooden sword");

            room1.AddConnectedRoom("north", room2);
            room2.AddConnectedRoom("south", room1);
            room2.AddConnectedRoom("east", room3);
            room3.AddConnectedRoom("west", room2);

            currentRoom = room1;
        }

        public void Start()
        {
            Console.WriteLine("Dungeon Explorer");
            bool playing = true;

            while (playing)
            {
                Console.WriteLine(currentRoom.GetDescription());
                Console.WriteLine("Items in room: " + currentRoom.ListItems());
                Console.WriteLine("Exits: " + currentRoom.ListConnectedRooms());
                Console.WriteLine("Options: 1.'pick up [item]', 2.'inventory', 3.'move [direction]', 'exit'");

                string input = Console.ReadLine()?.ToLower() ?? "";

                if (input.StartsWith("pick up"))
                {
                    string item = input.Substring(8).Trim();
                    if (currentRoom.ListItems().Contains(item))
                    {
                        currentRoom.RemoveItem(item);
                        player.PickUpItem(item);
                    }
                    else
                    {
                        Console.WriteLine($"{item} is not in this room.");
                    }
                }
                else if (input == "inventory")
                {
                    Console.WriteLine("Your inventory: " + player.InventoryContents());
                }
                else if (input.StartsWith("move"))
                {
                    string direction = input.Substring(5).Trim();
                    Room nextRoom = currentRoom.GetConnectedRoom(direction);
                    if (nextRoom != null)
                    {
                        currentRoom = nextRoom;
                        Console.WriteLine($"You moved to the {direction}");
                    }
                    else
                    {
                        Console.WriteLine("You cannot go that way.");
                    }
                }
                else if (input == "exit")
                {
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
        }
    }
}
