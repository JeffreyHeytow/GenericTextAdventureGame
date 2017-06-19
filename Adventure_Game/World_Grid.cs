using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * this will build the map of the game
     * which will contain rooms to be navigated 
     * by the player
     */

    class World_Grid
    {
        private static Room[,] _rooms;

        public static Room[,] _Rooms
        {
            get { return _rooms; }
            set { _rooms = value; }
        }


        public static void initialize()
        {
            build_map();
        }

        private static void build_map()
        {
            //create the grid that holds the rooms:
            /*
             *          x0      x1      x2
             *      
             *  y0      r1  |   r2
             *                  --
             *  y1      r4  |   r3   
             *  
             *  y2
             */
            _rooms = new Room[2, 2];

            Room room;
            Item item;
            Player player;
            
            player = PlayerFactory.GeneratePlayer();
            Player._Player = player;


            //////////////////////////////// room 1 ////////////////////////
            room = new Room();
            item = new Item();
            string underline = "";

            //assign the new room to a location on the grid;
            _rooms[0, 0] = room; //x0, y0
          

            //setup room properties;

            room.Title = "\n\t\tCave Of Really Stinky Death";
            room.Description = "\nA large, ominous cave that is very dark and smells like Farinza shit.";
            underline = underline.PadLeft(room.Description.Length, '-');
            room.Title += "\n" + underline;
            room.Description += "\n\n" + underline;
            room.add_exit(Direction._east);


           //setup item
            item.Name = "Torch";
            item.PickupText = "You are now carrying the torch.";

           //add item to room
            room.Room_Items.Add(item);

            //////////////////////////////// room 2 ////////////////////////
            room = new Room();
            item = new Item();

            //assign room;
            _rooms[1, 0] = room; //x1, y0


            //setup room;
            room.Title = "\n\t\tCavern Passageway";
            room.Description = "\nA Just a long, dark passageway through the cave. Nothing interesting.";
            underline = underline.PadLeft(room.Description.Length, '-');
            room.Title += "\n" + underline;
            room.Description += "\n\n" + underline;
            room.add_exit(Direction._west);
            room.add_exit(Direction._south);


            //////////////////////////////// room 3 ////////////////////////
            room = new Room();
            item = new Item();

            //assign room;
            _rooms[1, 1] = room; //x1, y1


            //setup room;
            room.Title = "\n\t\tCavern Corridor";
            room.Description = "\n A long damp cooridor that has a foul smell.";
            underline = underline.PadLeft(room.Description.Length, '-');
            room.Title += "\n" + underline;
            room.Description += "\n\n" + underline;
            room.add_exit(Direction._north);
            room.add_exit(Direction._west);

            //////////////////////////////// room 4 ////////////////////////
            room = new Room();
            item = new Item();

            //assign room;
            _rooms[0, 1] = room; //x0, y1


            //setup room;
            room.Title = "\n\t\tMysterious Shrine";
            room.Description = "\nA mysterious shrine to a Blood God hidden deep within the cave.";
            underline = underline.PadLeft(room.Description.Length, '-');
            room.Title += "\n" + underline;
            room.Description += "\n\n" + underline;
            room.add_exit(Direction._east);


            //setup item
            item.Name = "Ring Of Power";
            item.PickupText = "You have grabbed the Ring Of Power!";

            //add item to room
            room.Room_Items.Add(item);

         

            //////////////////////////////////////////////////////////////////

            //place the player in a room
            player._X_Position = 1;
            player._Y_Position = 0; // puts player in first room.

        }
    }
}
