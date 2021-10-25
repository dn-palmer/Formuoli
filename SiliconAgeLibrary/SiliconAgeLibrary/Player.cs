using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconAgeLibrary;

namespace SiliconAgeLibrary
{
    //DP:Inherits the Players Resources Class for easier instatiating and to prevent class clutter. 
    public class Player : PlayerResources
    {
        //More Properties which are also basic af
        public string PlayerName { get; set; }
        public int TurnNumber { get; set; }
        public string PlayerThemeColor { get; set; }


    }
}
