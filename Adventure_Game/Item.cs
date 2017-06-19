using System;
using System.Collections.Generic;
using System.Text;

namespace Adventure_Game
{
    /*
     * game items for player to interact with
     */
    public class Item
    {
        private string name;
        // text that appears when item is taken
        private string pickupText;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PickupText
        {
            get { return pickupText; }
            set { pickupText = value; }
        }

    }
}
