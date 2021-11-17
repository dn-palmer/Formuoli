using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconAgeLibrary
{
    
    class GameEvents
    {
        Random r = new Random();
        public void FieldReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 2;

            player.CoffeeUpdate(true, diceTotal);

        }


    }
}
