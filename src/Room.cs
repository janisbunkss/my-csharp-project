using System;
using System.Collections.Generic; // lets us use the list<> and dictionary<>.

namespace MyCSharpProject
{
    internal class Room
    {
        private string description;
        private List<string> items;
        private Dictionary<string, Room> connectedRooms;

        public Room(string description)
        {
            this.description = description;
            items = new List<string>();
            connectedRooms = new Dictionary<string, Room>();
        }

        public string GetDescription()
        {
            return description;
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        public string ListItems()
        {
            return items.Count > 0 ? string.Join(", ", items) : "No items";
        }

        public void AddConnectedRoom(string direction, Room room)
        {
            connectedRooms[direction] = room;
        }

        public Room GetConnectedRoom(string direction)
        {
            return connectedRooms.ContainsKey(direction) ? connectedRooms[direction] : null;
        }

        public string ListConnectedRooms()
        {
            return connectedRooms.Count > 0 ? string.Join(", ", connectedRooms.Keys) : "No exits";
        }
    }
}

