using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /* 
     * a class to help extract commands
     * from user input
     */
    static class Game_Utilities
    {
        /*
         * user commands are:
         * ~ move
         * ~ look
         * ~ take
         * ~ drop
         * ~ help
         * this method will extract the command 
         * from the user input.
         */

        public static string extract_command(string line)
        {
            //variable to hold the space between words in the user input:
            int index_of = line.IndexOf(' ');

            //check if there even is a space, or if only one
            //word was typed into the prompt:

            if (index_of == -1)  // -1 is false...
            {
                return line;
            }
            else //there are more than one word
            {
                //return just the letters from the 
                //begining to the space.
                return line.Substring(0, index_of);
            }
        }

        // get the second half of the input...
        // i.e. "east" or "north", etc..
        public static string extract_action(string line)
        {
            int index_of = line.IndexOf(' ');

            if (index_of == -1)
            {
                return ""; // there was no second word so return nothing.
            }
            else
            {
                return line.Substring(index_of + 1, // add one to cover the space
                    line.Length - index_of - 1); // the entire string, -d what is before the space.
            }
        }
         // to fit the text onto the console window size.
        public static string wrap(string text, int bufferWidth)
        {
            string result = "";
            string[] lines = text.Split('\n'); //split all the wods at the new line indicator.

            //search all the lines, one at a time
            foreach (string line in lines)
            {
                int line_length = 0; //count the length of the line
                string[] words = line.Split(' '); // break the lines up into words, indicated by the space

                //search all of the words
                foreach (string word in words)
                {
                    //check if adding next word goes over length limit
                    if (word.Length + line_length >= bufferWidth - 1)
                    {
                        //if it does, make a new line, and reset the line length.
                        result += "\n";
                        line_length = 0;
                    }
                    //add a space back in after all of the words
                    result += word + " ";
                    //increase the line length by the size of the new word and the space.
                    line_length += word.Length + 1;
                }
                // re-assemble the text back into lines
                result += "\n";
            }
            return result;
        }
    }
}
