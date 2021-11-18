using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiliconAgeLibrary;

namespace SiliconAgeLibrary
{
    public class TurnManager2
    {
        public Player[] players { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Player player3 { get; set; }
        public Player player4 { get; set; }

        public int currentTurn { get; set; }
        public int totalTurn { get; set; }
        public int Phase2Turn { get; set; }
        public int Phase2Count { get; set; }

        public bool Phase2 { get; set; }

        public TurnManager2()
        {
            totalTurn = 0;
            currentTurn = 0;
            Phase2Turn = 0;
            Phase2 = false;
            player1 = new Player("Player1");
            player2 = new Player("Player2");
            player3 = new Player("Player3");
            player4 = new Player("Player4");
            players = new Player[4];
            PlayerGame4();
        }

        public void PlayerGame4()
        {
            players[0] = player1;
            players[1] = player2;
            players[2] = player3;
            players[3] = player4;
        }


        public void NewRound(Player[] arr)
        {
            Player temp = arr[0];
            for (int i = 0; i <= arr.Length - 2; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[arr.Length - 1] = temp;
        }

        public void NextTurn()
        {
            currentTurn++;
            totalTurn++;
            if (currentTurn == players.Length)
            {
                currentTurn = 0;
            }
        }

        public bool CheckPhase(Player[] arr)
        {
            int count = 0;
            foreach (Player p in arr)
            {
                if (p.PiecesSet == true)
                {
                    count++;
                }
            }
            if (count == arr.Length)
            {
                return true;
            }
            return false;
        }

        public void ResetPieces(Player p)
        {
            p.PiecesSet = false;
            p.CurrentTokenCount = p.TotalTokenCount;
            p.EventLog = "";
            p.TokensSet = 0;
            p.EventQueue.Clear();
            p.TokenQueue.Clear();
        }
    }
}