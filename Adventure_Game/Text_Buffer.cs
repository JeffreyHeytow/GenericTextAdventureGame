using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * a class used to create a text
     * buffer, so output can be read clearly
     */

    static class Text_Buffer
    {
        // store the string into one output buffer
        private static string output_buffer;

        // add to the buffer
        public static void Add(string text)
        {
            // put all text into the buffer
            // seperated by a new line.
            output_buffer += text + "\n";
        }

        // print the buffer
        public static void print()
        {
            Console.Clear();
            //wrap the text to fit onto the screen correctly
            Console.Write(Game_Utilities.wrap(output_buffer, Console.WindowWidth));
            Console.WriteLine("What would you like to do?");
            Console.Write(">");
            output_buffer = ""; // clear the buffer when done.
        }

        //print the buffer with no prompt:
        public static void prompt()
        {
            Console.Clear();
            Console.Write(Game_Utilities.wrap(output_buffer, Console.WindowWidth));
            Console.Write(">");
            output_buffer = ""; // clear the buffer when done.
        }
    }
}
