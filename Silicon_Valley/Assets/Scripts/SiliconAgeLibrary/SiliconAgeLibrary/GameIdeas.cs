using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconAgeLibrary;


//DP:Quite a bit of this is just me throwing things at a wall and seeing what sticks. None of this is permanate and I still need to work on how it will
//interact with unitys systems.

//namespace SiliconAgeLibrary
//{
//    public class GameIdeas
//    {
//        //DP:Our players...once we set them up.
//         Player[] Players;
//        //DP:These strings are actually colors in the formate needed for unites SetColor Method an example of this method is
//        //material.SetColor("_Color", Color.red)-"_Color" is the main color of a material. So for Our needs we would just do something
//        //similar to material.SetColor("_Color", Players[i].PlayerThemeColor) this is little example is mostly for me so I do not 
//        //forget later XD
//        string[] playerColorArray = new string[] { "Color.red", "Color.blue", "Color.yellow", "Color.green" };


//        //DP:Creates an array of Player objects that can be used to keep track of Player Resources, Turns,
//        //and ect. 
//        public void NumberOfPlayers(int playerCount)
//        {
//            //DP:Need to do some error checking stuff here to make sure that we do not go over max player count
            
//            for (int i = 0; i < playerCount; i++)
//            {
//                Players[i] = new Player();

//            }
                
//        }

//        //DP:Sets the players Resources Turn Number, Preffered Name, and the color for their tokens (this is selected used there turn number and the color array above)
//        //This can be looped through as many times as needed to cover the desired player number. Will need a script to get this info Player Turn and Name. Should only be 
//        //processed at the start of the game. 
//        public void PlayerSetUp(int playerTurn, string playerName)
//        {
//            Players[playerTurn].TurnNumber = playerTurn;
//            Players[playerTurn].PlayerName = playerName;
//            Players[playerTurn].PlayerThemeColor = playerColorArray[playerTurn];
//            Players[playerTurn].ShippableCode = 0;
//            Players[playerTurn].Servers = 0;
//            Players[playerTurn].Hardware = 0;
//            Players[playerTurn].Investors = 0;
//            Players[playerTurn].Coffee = 0;
//            Players[playerTurn].TokenCount = 0;

//        }
       
        
//        //DP:Will return a player for display on the tile. Will have to work out the script when I get a free second. 
//        public Player Display(int player)
//        {
//            return Players[player];
//        }



//    }
//}
