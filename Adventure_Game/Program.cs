using System;

namespace Adventure_Game
{
    class Program
    {
        public static bool quit = false;

        static void Main(string[] args)
        {
            Game_Manager.title_screen();
            World_Grid.initialize();
            Game_Manager.start_game();

            while (!quit) 
            {
                Game_Processor.process(Console.ReadLine());
            } 
        }
    }
}
