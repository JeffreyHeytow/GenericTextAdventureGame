using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    class Game_Manager
    {
        public static Non_PLayer enemy = Non_PlayerFactory.Generate_NPC();

        //Welcone Screen
        public static void title_screen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(Game_Utilities.wrap("*** Welcome to Generic Adventure Time!" + 
                " A gaming experiment by Jeff Heytow, novice programmer. ***", 
                Console.WindowWidth));
            Console.WriteLine(Game_Utilities.wrap("\n\nPlease note that you can type 'help' " +
                "at any time to see a list of available commands.", Console.WindowWidth));
            Console.WriteLine("\nPress any key to begin...");

            Console.CursorVisible = false; //get rid of the cursor
            Console.ReadKey();
            Console.CursorVisible = true; // bring cursor back		this.room_enemies	Keyword 'this' is not valid in a static property, static method, or static field initializer	

            Console.Clear();
        }

        public static void start_game()
        {
            Player.get_room().describe();
            Text_Buffer.Add("\nEnemy is located at [ " + enemy._X_Position +
            ", " + enemy._Y_Position + " ]");
            Text_Buffer.Add("\nYou are located at [ " + Player._Player._X_Position +
                ", " + Player._Player._Y_Position + " ]");
            Text_Buffer.print();
        }

        public static void end_game(string endText)
        {
            Program.quit = true;
            Console.Clear();
            Console.WriteLine(Game_Utilities.wrap(endText, Console.WindowWidth));

            //force to close window after game ends...
            Console.WriteLine("You may now close this window.");
            Console.CursorVisible = false;
            //infanite loop so no action can be taken...
            while (true)
            {
                Console.ReadKey(true);
            }
        }

        public static void check_game_rules()
        {
            Console.Clear();

            if (Player._Player._X_Position == Game_Manager.enemy._X_Position &&
                Player._Player._Y_Position == Game_Manager.enemy._Y_Position)
            {
                Text_Buffer.Add("You have encountered an enemy!");
                Game_Manager.enemy.Identify();
                Text_Buffer.Add("\nEnemy Stats are:");
                Game_Manager.enemy.NPC_Stats();
            }

        }
    }
}
