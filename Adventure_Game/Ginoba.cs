using System;

namespace Adventure_Game
{
    /*
     * The Ginoba Player class
     * as part of the FACTORY
     * creates a Ginoba object
     */

    class Ginoba : Player
    {
        public Ginoba(string gName, Player_Weapon gWeapon)
            : base(gName, Player_Class.Ginoba, 200, gWeapon)
        {
        }

        public override void BattleCry()
        {
            Text_Buffer.Add("\nI am Ginoba, the wisest of them all.");
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
