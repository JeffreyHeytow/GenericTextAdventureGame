using System;

namespace Adventure_Game
{
    /*
     * The Nobellus Player class
     * as part of the FACTORY
     * creates a Nobellus object
     */

    class Nobellus : Player
    {
        public Nobellus(string nName, Player_Weapon nWeapon)
            : base(nName, Player_Class.Nobellus, 400, nWeapon)
        {
        }

        public override void BattleCry()
        {
            Text_Buffer.Add("\nI am Nobellus, and I fight for what is just.");
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
