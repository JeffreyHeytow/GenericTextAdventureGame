using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure_Game
{
    class Egnor : Non_PLayer
    {
        public Egnor(NPC_Names _name, Player_Weapon eWeapon)
            : base(_name, NPC_Class.Egnor, 150, eWeapon)
        {
            this._X_Position = 0;
            this._Y_Position = 1;
        }

        public override void Identify()
        {
            Text_Buffer.Add("\nI am from Egnor and will outsmart you!");
        }

        public override void NPC_Stats()
        {
            Text_Buffer.Add("Health:\t" + _health);
            Text_Buffer.Add("Weapon:\t" + _weapon);
        }
    }

}
