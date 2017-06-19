using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * handle directions int the game
     */

    struct Direction
    {
        public const string _north  = "north";
        public const string _south  = "south";
        public const string _east   = "east";
        public const string _west   = "west";

        public static bool is_valid(string direction)
        {
            switch (direction)
            {
                case Direction._north :
                    return true;
                case Direction._south :
                    return true;
                case Direction._east :
                    return true;
                case Direction._west :
                    return true;
            }

            return false;
        }
    }
    /*
     * the areas in the world map
     * joined together, to be
     * navigated by the player
     */

    public class Room
    {

        private string description; // the description of the roomn
        private string title;  // the name of the room;

        private List<string> room_exits;  // the exits in the rooms
        private List<Item> room_items;  // the items in the room;
        private List<Non_PLayer> room_enemies; // the enemies in the room

        public int enemyCount = 0;

        # region properties

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public List<Item> Room_Items
        {
            get { return room_items; }
            set { room_items = value; }
        }

        public List<Non_PLayer> Room_Enemies
        {
            get { return room_enemies; }
            set { room_enemies = value; }
        }
        #endregion

        public Room()
        {
            room_exits = new List<string>();
            room_items = new List<Item>();
            room_enemies = new List<Non_PLayer>();
        }

        //describe the room
        public void describe()
        {
            Text_Buffer.Add(this.title);
            Text_Buffer.Add(this.description);
            Text_Buffer.Add(this.enemyList());
            Text_Buffer.Add(this.itemList());
            Text_Buffer.Add(this.exitList());
        }

        public void print_room_name()
        {
            Text_Buffer.Add(this.title);
        }

        public Item print_item(string item_name)
        {
            foreach (Item item in this.room_items)
            {
                if (item.Name.ToLower() == item_name.ToLower())
                {
                    return item;
                }
            }

            return null;
        }

        public void add_enemy(Non_PLayer enemy)
        {
            this.room_enemies.Add(enemy);
            enemyCount++;
        }

        public void remove_enemy(Non_PLayer enemy)
        {
            this.room_enemies.Remove(enemy);
            enemyCount--;
        }

        //Add, remove, check exits in room:
        public void add_exit(string direction)
        {
            //if there isn't an exit already at the requested
            //direction, put one there.
            if (this.room_exits.IndexOf(direction) == -1)
            {
                this.room_exits.Add(direction);
            }
        }

        public void remove_exit(string direction)
        {
            if (this.room_exits.IndexOf(direction) == -1)
            {
                this.room_exits.Remove(direction);
            }
        }

        public bool has_exit(string direction)
        {
            foreach (string valid in this.room_exits)
            {
                if (direction == valid)
                {
                    return true;
                }
            }
            return false;
        }

        // get the item list
        private string itemList()
        {
            string item_name = "";
            string message = "\nYou have found:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            //iterate through the items to see if there are any:
            if (this.room_items.Count > 0)
            {
                foreach (Item item in this.room_items)
                {
                    item_name += "\n< " + item.Name + " >";
                }
            }
            else
            {
                //item_name = "\n< none >";
                return null;
            }
            return message + " \n" + underline + item_name;
        }

        //now get the exits
        private string exitList()
        {
            string exit_name = "";
            string message = "\nFrom here you can travel:";
            string underline = "";
            underline = underline.PadLeft(message.Length,'-');

            //iterate through the items to see if there are any:
            if (this.room_exits.Count > 0)
            {
                foreach (string exit in this.room_exits)
                {
                    exit_name += "\n~ " + exit + " ~";
                }
            }
            else
            {
                //exit_name = "\n< none >";
                return null;
            }
            return message + "\n" + underline + exit_name;
        }

        // get the enemies list
        private string enemyList()
        {
            string enemy_name = "";
            string message = "\n*** ENEMY ALERT ***:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            //iterate through the items to see if there are any:
            if (this.enemyCount > 0)
            {
                foreach (Non_PLayer ememy in this.room_enemies)
                {
                    enemy_name += "\n< " + Non_PLayer._name + " of " + Non_PLayer._class + " >";
                }
            }
            else
            {
                //enemy_name = "\n< none >";
                return null;
            }

            return message + " \n" + underline + enemy_name 
                + "\nEnemy HEALTH:\t" + Non_PLayer._health + "\nENEMY WEAPON:\t" + Non_PLayer._weapon +
                "\n" + underline;
        }

        //get the location of the room on the map
        private string locate_room()
        {
            //iterate the y coordinates
            for (int y = 0; y < World_Grid._Rooms.GetLength(1); y++)
            {
                //iterate the x coordinates
                for (int x = 0; x < World_Grid._Rooms.GetLength(0); x++)
                {
                    if(this == World_Grid._Rooms[x, y])
                    {
                        return x.ToString() + y.ToString();
                    }
                }
            }

            return "This room does not exist...";
        }

    }
}
