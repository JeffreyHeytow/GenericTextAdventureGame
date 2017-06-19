using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * A simple placeholder class used to 
     * create non-playable enemies in the game
     * as part of the FACTORY DESIGN PATTERN
     */

    //abstract class for non-player
    public abstract class Non_PLayer
    {
        //the non-player's location
        private static int _x_position;
        private static int _y_position;
        private static Non_PLayer _non_player;

        #region properties
        // the non-player's attributes
        public static NPC_Names _name { get; set; }
        public static NPC_Class _class { get; set; }
        public static int _health { get; set; }
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

        public static Non_PLayer _Non_Player
        {
            get { return _non_player; }
            set { _non_player = value; }
        }
  
        #endregion

        protected Non_PLayer(NPC_Names npName, NPC_Class npClass, int npHealth, Player_Weapon npWeapon)
        {
            _name = npName;
            _class = npClass;
            _health = npHealth;
            _weapon = npWeapon;
        }

        //itentify enemy
        public abstract void Identify();
        public abstract void NPC_Stats();

        //show enemy stats
        public static void npc_stats()
        {
            string message = ("Current Enemy Staus:");
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            Text_Buffer.Add(message + "\n" + underline);
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        }

        //get the current room the npc is located in:
        public static Room npc_get_room()
        {
            return World_Grid._Rooms[_x_position, _y_position];
        }

        public string npc_direction()
        {
            Random random = new Random();
            var directions = new List<string> { "north", "south", "east", "west" };
            int index = random.Next(directions.Count);
            var direction = directions[index];
            directions.RemoveAt(index);
            return direction;
        }

        /*
         * to be used with an UPDATE PATTERN?
         * maybe put a random direction in and update position?
         */
        public void npc_move(string direction)
        {

            //first we need to get the current room
            //the player is in so we can see where to move
            Room room = Non_PLayer.npc_get_room();

            if (!room.has_exit(direction))
            {
                Text_Buffer.Add("NPC can't go that way.");
                return; // return out of the method so another command can be given
            }

            room.remove_enemy(Game_Manager.enemy);
            ;

            switch (direction)
            {
                case Direction._north:
                    Game_Manager.enemy._Y_Position--; //move up one on the grid
                    room.add_enemy(Game_Manager.enemy);
                    break;
                case Direction._south:
                    Game_Manager.enemy._Y_Position++;  //move down one on the grid
                    room.add_enemy(Game_Manager.enemy);
                    break;
                case Direction._east:
                    Game_Manager.enemy._X_Position++; //move right one on the grid
                    room.add_enemy(Game_Manager.enemy);
                    break;
                case Direction._west:
                    Game_Manager.enemy._X_Position--;  //move left one on the grid
                    room.add_enemy(Game_Manager.enemy);
                    break;

                //no need for  a default since the direction has
                //already been checked as valid or not.
            }

            //get the description of the current room.
            //Non_PLayer.npc_get_room().describe();
            
        }

    }
}
