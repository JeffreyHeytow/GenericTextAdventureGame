using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{

    // the different classes of players
    // in the game:
    public enum Player_Class
    {
        Rankari = 1, Nobellus = 2, Ginoba = 3, INCOGNITO
    }

    // the different spells the player
    // can possess
    public enum Player_Weapon
    {
        Knife = 1, Sword = 2, Axe = 3, WarHammer = 4, 
    }

    /*
     * This class represents the player FACTORY
     * where player objects will be created 
     * according to the user's input.
     */

    class PlayerFactory
    {

        ~PlayerFactory()
        {
        }
        
        public static Player GeneratePlayer()
        {
            Player p = null;
          
            string n = string.Empty;
            bool correct = false;

            Text_Buffer.Add("\nPlease enter your name: ");
            Text_Buffer.prompt();
            n = Console.ReadLine();

            while(!correct)
            {
                string newName;
                Text_Buffer.Add("\nIf "  + n + " is correct, press < enter >\n\n\tIf it's not, please re-enter your name now:");
                Text_Buffer.prompt();
                newName = Console.ReadLine();
                if (newName == string.Empty)
                {
                    Text_Buffer.Add("\nWhat a good, strong name, " + n + "!");
                    correct = true;
                }
                else
                {
                    n = newName;
                }

            }

            Player_Class pc = 0;
                Text_Buffer.Add("\nThere are 3 races in this game.");
                Text_Buffer.Add("\tThey are:");
                Text_Buffer.Add("\n\t1.  Rankari");
                Text_Buffer.Add("\t2.  Nobellus");
                Text_Buffer.Add("\t3.  Ginoba");
                Text_Buffer.Add("\nPlease choose one: ");
                Text_Buffer.prompt();
                string t = Console.ReadLine();

                correct = false;
                int i = 0;

                while (!correct)
                {
                    if (t == "1" || t == "2" || t == "3")
                    {
                        i = int.Parse(t);
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice. Try again...");
                        t = Console.ReadLine();
                    }
                }

                switch (i)
                {
                    case 1:
                        pc = Player_Class.Rankari;
                        correct = true;
                        break;

                    case 2:
                        pc = Player_Class.Nobellus;
                        correct = true;
                        break;

                    case 3:
                        pc = Player_Class.Ginoba;
                        correct = true;
                        break;

                    default:
                        Text_Buffer.Add("No race selected!");
                        pc = Player_Class.INCOGNITO;
                        Text_Buffer.print();
                        break;
                }

            Player_Weapon pw = 0;
                Text_Buffer.Add("\nThere are 4 weapons in this game.");
                Text_Buffer.Add("\tThey are:");
                Text_Buffer.Add("\n\t1.  Knife");
                Text_Buffer.Add("\t2.  Sword");
                Text_Buffer.Add("\t3.  Axe");
                Text_Buffer.Add("\t4.  Warhammer");
                Text_Buffer.Add("\nPlease choose one: ");
                Text_Buffer.prompt();
                string s = Console.ReadLine();

                
            correct = false;
                int j = 0;

                while (!correct)
                {
                    if (s == "1" || s == "2" || s == "3" || s == "4")
                    {
                        j = int.Parse(s);
                        correct = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid choice. Try again...");
                        s = Console.ReadLine();
                    }
                }

                switch (j)
                {
                    case 1:
                        pw = Player_Weapon.Knife;
                        break;

                    case 2:
                        pw = Player_Weapon.Sword;
                        break;

                    case 3:
                        pw = Player_Weapon.Axe;
                        break;

                    case 4:
                        pw = Player_Weapon.WarHammer;
                        break;

                    default:
                        Text_Buffer.Add("No weapon selected!");
                        Text_Buffer.print();
                        break;
                }

            switch (pc)
            {
                case Player_Class.Rankari :
                    p = new Rankari(n, pw);
                    break;

                case Player_Class.Nobellus :
                    p = new Nobellus(n, pw);
                    break;

                case Player_Class.Ginoba :
                    p = new Ginoba(n, pw);
                    break;

                default :
                    Text_Buffer.Add("No Player Detected...");
                    break;
            }
            return p;
        }
    }
}
