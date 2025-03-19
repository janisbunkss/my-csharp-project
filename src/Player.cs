using System.Collections.Generic;
using System;


namespace MyCSharpProject
{
    internal class Player
    {
        private string name;
        private int health;
        private List<string> inventory;

        public Player(string name, int health)
        {
            this.name = name;
            this.health = health;
            inventory = new List<string>();
        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        public string InventoryContents()
        {
            return inventory.Count > 0 ? string.Join(", ", inventory) : "Your inventory is empty.";
        }
    }
}
