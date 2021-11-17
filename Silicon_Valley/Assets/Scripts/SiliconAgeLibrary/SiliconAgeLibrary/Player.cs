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
        public string PlayerThemeColor { get; set; }
        public bool PiecesSet { get; set; }

        public Player(string name)
        {
            PlayerName = name;
            ShippableCode = 0;
            Servers = 0;
            Hardware = 0;
            Investors = 0;
            Coffee = 10;
            CurrentTokenCount = 5;
            TotalTokenCount = 5;
            PiecesSet = false;
        }

        public string DisplayResourceCard()
        {
            return $"Player: {PlayerName}\nCoffee: {Coffee}\nTokenCount: {CurrentTokenCount}/{TotalTokenCount}\n" +
                $"ShippableCode: {ShippableCode}\nServers: {Servers}\nHardware: {Hardware}\n" +
                $"Investors: {Investors}\n";
        }

    }
}
