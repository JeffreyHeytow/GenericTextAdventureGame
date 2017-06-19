using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    class Erstine : Non_PLayer
    {
        public Erstine(NPC_Names _name, Player_Weapon eWeapon)
            : base(_name, NPC_Class.Erstine, 250, eWeapon)
        {
            this._X_Position = 0;
            this._Y_Position = 1;
        }

        public override void Identify()
        {
            Text_Buffer.Add("\nI hail from the land of Erstine."); ;
        }

        public override void NPC_Stats()
        {
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        }
    }
}
