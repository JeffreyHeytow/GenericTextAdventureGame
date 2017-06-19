using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{

    // the different classes for NPC players
    //in the game
    public enum NPC_Class
    {
        Egnor = 1, Tyrania = 2, Erstine = 3
    }

    public enum NPC_Names
    {
       Danius, Rukkus, Malious, Fin, Grogg
    }

    /*
    * This is the FACTORY that will produce
    * the enemies in the game
    */
    class Non_PlayerFactory
    {
        ~Non_PlayerFactory()
        {
        }

        public static Non_PLayer Generate_NPC()
        {
            Non_PLayer npc = null;

            Array values = Enum.GetValues(typeof(NPC_Names));
            Random random = new Random();
            NPC_Names randomName = 
                (NPC_Names)values.GetValue(random.Next(values.Length));

            Array rValues = Enum.GetValues(typeof(NPC_Class));
            Random cRandom = new Random();
            NPC_Class randomClass =
                (NPC_Class)rValues.GetValue(cRandom.Next(rValues.Length));

            Array wValues = Enum.GetValues(typeof(Player_Weapon));
            Random wRandom = new Random();
            Player_Weapon randomWeapon =
                (Player_Weapon)wValues.GetValue(wRandom.Next(wValues.Length));

            switch (randomClass)
            {
                case NPC_Class.Egnor :
                    npc = new Egnor(randomName, randomWeapon);
                    break;
                case NPC_Class.Erstine :
                    npc = new Erstine(randomName, randomWeapon);
                    break;
                case NPC_Class.Tyrania :
                    npc = new Erstine(randomName, randomWeapon);
                    break;
                default :
                    Text_Buffer.Add("No Player Detected...");
                    break;
            }

            return npc;
        }
    }
}
