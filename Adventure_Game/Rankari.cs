using System;

namespace Adventure_Game
{
    /*
     * The Rankari Player Class
     * as part of the FACTORY
     * creates a Rankari object
     */

    class Rankari : Player
    {
        public Rankari(string rName, Player_Weapon rWeapon)
            : base(rName, Player_Class.Rankari, 300, rWeapon)
        {
        }

        public override void BattleCry()
        {
            Text_Buffer.Add("\nI am Rankari! Hear me ROAR!");
        }

        public override void Stats()
        {
            string message = ("Current stats for " + _name + " of " + _class);
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            Text_Buffer.Add(message + "\n" + underline);
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        } 
    }
}
