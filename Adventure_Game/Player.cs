using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * A simple placeholder class used
     * to create players in the game
     * as part of the FACTORY DESIGN PATTERN
     */

    // abstract class for Player
    public abstract class Player
    {
        // the player's location
        private static int _x_position;
        private static int _y_position;
        private static List<Item> _inventory;
        private static Player _player;

        # region properties
        // the player's class
        public static string       _name   { get; set; }
        public static Player_Class _class  { get; set; }
        public static int          _health { get; set; }
        public static Player_Weapon _weapon { get; set; }

        public int _X_Position
        {
            get { return _x_position; }
            set { _x_position = value; }
        }

        public int _Y_Position
        {
            get { return _y_position; }
            set { _y_position = value; }
        }

        public static List<Item> _Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        public static Player _Player
        {
            get { return _player; }
            set { _player = value; }
        }

        # endregion

        protected Player(string pName, Player_Class pClass, int pHealth, Player_Weapon pWeapon)
        {
            _name      = pName;
            _class     = pClass;
            _health    = pHealth;
            _weapon    = pWeapon;
            _inventory = new List<Item>();
        }
    
        // fuction to generate the player's spell -
        // to be overridden by the chosen class...
        public abstract void BattleCry();
        public abstract void Stats();

        public static void stats()
        {
            string message = ("Current stats for " + _name + " of " + _class);
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            Text_Buffer.Add(message + "\n" + underline);
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        }

        //get the current room the player is located in:
        public static Room get_room()
        {
            return World_Grid._Rooms[_x_position, _y_position];
        }

        //get inventory items to drop
        public static Item get_item(string itemName)
        {
            foreach (Item item in _inventory)
            {
                if (item.Name.ToLower() == itemName.ToLower())
                {
                    return item;  //found item
                }

            }
            // no item found
            return null;
        }

        public static void move(string direction)
        {
            //first we need to get the current room
            //the player is in so we can see where to move
            Room room = Player.get_room();

            if (!room.has_exit(direction))
            {
                Text_Buffer.Add("You can't go that way.");
                return; // return out of the method so another command can be given
            }

            switch (direction)
            {
                case Direction._north:
                    _y_position--; //move up one on the grid
                    break;
                case Direction._south:
                    _y_position++;  //move down one on the grid
                    break;
                case Direction._east:
                    _x_position++; //move right one on the grid
                    break;
                case Direction._west:
                    _x_position--;  //move left one on the grid
                    break;

                    //no need for  a default since the direction has
                    //already been checked as valid or not.
            }

            //get the description of the current room.
            Player.get_room().describe();
        }

        //pickup an item
        public static void pickup_item(string itemName)
        {
            //need to find item in the room...
            Room room = Player.get_room();
            Item item = room.print_item(itemName);

            //if there is an item in the room...
            if (item != null)
            {
                //remove it from the room and put it in 
                //the player's inventory
                room.Room_Items.Remove(item);
                Player._inventory.Add(item);
                Text_Buffer.Add(item.PickupText);
                return;
            }
            //else there is no item in the room
            Text_Buffer.Add("There are no items to take.");
        }

        //drop an item
        public static void drop_item(string itemName)
        {

            //need a room to put item in...
            Room room = Player.get_room();
            Item item = get_item(itemName);

            //if there is an item in the room...
            if (item != null)
            {
                //remove it from the player's inventory
                //and put it in the room
                Player._inventory.Remove(item);
                room.Room_Items.Add(item);
                Text_Buffer.Add("You have dropped the " + itemName);
                return;
            }
            //else there is no item in the room
            Text_Buffer.Add("There are no items to take.");
        }

        //display the inventroy:
        public static void print_inventory()
        {
            string message = "Current Inventory:";
            string items = "";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (_inventory.Count > 0)
            {
                foreach (Item item in _inventory)
                {
                    items += "\n< " + item.Name +"\t>";
                }
            }
            else
            {
                items = "\n< Empty >";
            }

            Text_Buffer.Add(message + "\n" + underline + items + "\n" + underline);
        }

    }
}
