using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    class Tyrania : Non_PLayer
    {
        public Tyrania(NPC_Names _name, Player_Weapon tWeapon)
            : base(_name, NPC_Class.Tyrania, 400, tWeapon)
        {
            this._X_Position = 0;
            this._Y_Position = 1;
        }

        public override void Identify()
        {
            Text_Buffer.Add("\nI am from the mountains of Tyrania");
        }

        public override void NPC_Stats()
        {
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        }
    }
}
