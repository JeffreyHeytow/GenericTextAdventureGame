using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    class Game_Processor
    {
        // determine what action to take based 
        // on the user input
        public static void process(string input)
        {

            // get the first half and trim it to one easy to read command
            string command = Game_Utilities.extract_command(input.Trim().Trim().ToLower());
            // get the second half and trim it to one easy to read command
            string action = Game_Utilities.extract_action(input.Trim().Trim().ToLower());

            string direction = Game_Manager.enemy.npc_direction();


            // now take action based on the input given:
            /*
             * user commands are:
             * ~ move       - moves the player
             * ~ look       - describes the current area
             * ~ take       - takes an object from the area
             * ~ stats      - displays the Player's current stats
             * ~ drop       - drops an object from the area
             * ~ inventory  - lists the player's inventory items
             * ~ help       - displays the list of user commands
             * ~ quit       - exits the game
             */
            switch (command)
            {
                case "move":
                    Player.move(action);
                    Text_Buffer.Add("\nYou are located at [ " + Player._Player._X_Position +
                         ", " + Player._Player._Y_Position + " ]");
                    break;
                case "battlecry":
                    Player._Player.BattleCry();
                    break;
                case "look":
                    Player.get_room().describe();
                    break;
                case "take":
                    Player.pickup_item(action);
                    break;
                case "drop":
                    Player.drop_item(action);
                    break;
                case "stats":
                    Player.stats();
                    break;
                case "inventory":
                    Player.print_inventory();
                    break;
                case "help":
                    help_screen();
                    break;
                case "quit":
                    Program.quit = true;
                    return;
            }

            process_enemy(direction);
            Game_Manager.check_game_rules();
            Text_Buffer.print();
        }

        public static void process_enemy(string input)
        {
            Game_Manager.enemy.npc_move(input);
            Text_Buffer.Add("\nEnemy is located at [ " + Game_Manager.enemy._X_Position +
                ", " + Game_Manager.enemy._Y_Position+ " ]");
        }

        public static void help_screen()
        {
            string message = "Available Commands:";
            string underline = "";
            underline = underline.PadLeft(75, '-');

            Text_Buffer.Add(message + "\n" + underline);
            Text_Buffer.Add("~\tmove\t\t-\tto travel north, south, east, west\t~");
            Text_Buffer.Add("~\tlook\t\t-\tto see your surroundings\t\t~");
            Text_Buffer.Add("~\ttake\t\t-\tto add an item to your inventory\t~");
            Text_Buffer.Add("~\tdrop\t\t-\tto drop an item from your inventory\t~");
            Text_Buffer.Add("~\tstats\t\t-\tto see your current stats\t\t~");
            Text_Buffer.Add("~\tinventory\t-\tto see what you are carrying\t\t~");
            Text_Buffer.Add("~\thelp\t\t-\tto bring up the help menu\t\t~");
            Text_Buffer.Add("~\tquit\t\t-\tto end the game\t\t\t\t~");
            Text_Buffer.Add(underline);
        }
    }
}
