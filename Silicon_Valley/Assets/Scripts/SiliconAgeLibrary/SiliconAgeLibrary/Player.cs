using System;
using System.Collections;
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
        public int TokensSet { get; set; }
        public string TokenEvent { get; set; }
        public Queue<string> EventQueue { get; set; }
        public Queue<int> TokenQueue { get; set; }
        public string EventLog { get; set; }
        public int AgCount { get; set; }
        

        public Player(string name)
        {
            PlayerName = name;
            ShippableCode = 0;
            Servers = 0;
            Hardware = 0;
            Investors = 0;
            Coffee = 10;
            ToolCol = new Tools();
            AgCount = 0;
            CurrentTokenCount = 5;
            TotalTokenCount = 5;
            PiecesSet = false;
            TokensSet = 0;
            TokenEvent = "";
            EventLog = "";
            EventQueue = new Queue<string>();
            TokenQueue = new Queue<int>();
        }

        public string DisplayResourceCard()
        {
            return $"Player: {PlayerName}\nCoffee: {Coffee}\nTokenCount: {CurrentTokenCount}/{TotalTokenCount}\n" +
                $"ShippableCode: {ShippableCode}\nServers: {Servers}\nHardware: {Hardware}\n" +
                $"Investors: {Investors}\n";
        }

        public string DisplayTools()
        {
            string temp = "";
            foreach (Tool t in ToolCol.ToolArr)
            {
                temp += $"{t.Value} | ";
            }
            return temp;
        }
    }
}
