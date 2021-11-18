using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconAgeLibrary
{
    
    public class GameEvents
    {
        public GameEvents()
        {

        }

        public Random r = new Random();
        public void CoffeeReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 2;
            diceTotal += player.AgCount;
            player.EventLog += $"\nCoffee added is {diceTotal} ({player.AgCount} from field)";
            player.CoffeeUpdate(true, diceTotal);

        }

        public void RunEvents(Player player)
        {
            int j = player.EventQueue.Count();
            for (int i = 0; i < j; i++)
            {
                string gameEvent = player.EventQueue.Dequeue();
                int gameCount = player.TokenQueue.Dequeue();


                switch (gameEvent)
                {
                    case "Coffee":
                        CoffeeReturn(player, gameCount);
                        break;
                    case "Hut":
                        HutReturn(player);
                        break;
                    case "Server":
                        ServerReturn(player, gameCount);
                        break;
                    case "Hardware":
                        HardwareReturn(player, gameCount);
                        break;
                    case "Code":
                        CodeReturn(player, gameCount);
                        break;
                    case "Investor":
                        InvestorReturn(player, gameCount);
                        break;
                    case "Tool":
                        ToolReturn(player);
                        break;
                    case "Field":
                        AgReturn(player);
                        break;


                }
            }
        }

        public void HutReturn(Player player)
        {
            player.TotalTokenCount++;

            player.EventLog += $"\nPlayer total token count is now {player.TotalTokenCount}";
        }

        public void ServerReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 4;

            player.EventLog += $"\nServers added is {diceTotal}";
            player.ServersUpdate(true, diceTotal);
        }

        public void HardwareReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 5;

            player.EventLog += $"\nHardware added is {diceTotal}";
            player.HardwareUpdate(true, diceTotal);
        }

        public void CodeReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 3;

            player.EventLog += $"\nShippable Code added is {diceTotal}";
            player.ShippableCodeUpdate(true, diceTotal);
        }

        public void InvestorReturn(Player player, int tokens)
        {
            int diceTotal = 0;
            for (int i = 0; i < tokens; i++)
            {
                int dice = r.Next(1, 7);
                diceTotal += dice;
            }
            diceTotal /= 6;

            player.EventLog += $"\nInvestors added is {diceTotal}";
            player.InvestorsUpdate(true, diceTotal);
        }

        public void FeedTokens(Player p)
        {
            for (int i = 0; i < p.TotalTokenCount; i++)
            {
                if (p.Coffee > 0)
                {
                    p.CoffeeUpdate(false, 1);
                }
                else if (p.ShippableCode > 0)
                {
                    p.ShippableCodeUpdate(false, 1);
                }
                else if (p.Servers > 0)
                {
                    p.ServersUpdate(false, 1);
                }
                else if (p.Hardware > 0)
                {
                    p.HardwareUpdate(false, 1);
                }
                else if (p.Investors > 0)
                {
                    p.InvestorsUpdate(false, 1);
                }
                else
                    p.EventLog += "Not enough resources to feed";
            }

        }

        public void ToolReturn(Player p)
        {
            bool quit = false;
                int currentValue = p.ToolCol.getMax();
                for (int i = 0; i < p.ToolCol.ToolArr.Length; i++)
                {
                    if (currentValue > p.ToolCol.ToolArr[i].Value)
                    {
                        p.ToolCol.ToolArr[i].Value++;
                    p.EventLog += $"New Sr. Dev {p.ToolCol.ToolArr[i].Value} added";
                        quit = true;
                    break;
                    }
                }
            if (quit == false)
            {
                p.ToolCol.CurrentValue++;
                p.ToolCol.ToolArr[0].Value++;
                p.EventLog += $"New Sr. Dev {p.ToolCol.ToolArr[0].Value} added";
            }
        }

        public void AgReturn(Player p)
        {
            p.AgCount++;
            p.EventLog += $"Field Count is now {p.AgCount}";
        }
    }
}
