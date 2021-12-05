using System;

namespace SiliconAgeLibrary
{
    public class PlayerResources
    {

        //DP:Resource Properies! Yay? These guys are easy to understand.
        public double ShippableCode { get; set; }
        public double Servers { get; set; }
        public double Hardware { get; set; }
        public double Investors { get; set; }
        public double Coffee { get; set; }
        public double CurrentTokenCount { get; set; }
        public double TotalTokenCount { get; set; }
        public Tools ToolCol { get; set; }
        public int Points { get; set; }

        //DP: Adds or Subtracts resources. If a True is sent along with the the number that is being add/subtracted the number will be added but if it is
        //false the program will subtract the number.
        public void CoffeeUpdate(bool add, double coffee)
        {

            if (add)
            {
                Coffee += coffee;
            }
            else
            {
                Coffee -= coffee;
            }


        }

        public void ServersUpdate(bool add, double servers)
        {
            if (add)
            {
                Servers += servers;
            }
            else
            {
                Servers -= servers;
            }

        }
        public void HardwareUpdate(bool add, double hardware)
        {
            if (add)
            {
                Hardware += hardware;
            }
            else
            {
                Hardware -= hardware;
            }

        }
        public void CurentTokensUpdate(bool add, double tokens)
        {
            if (add)
            {
                CurrentTokenCount += tokens;
            }
            else
            {
                CurrentTokenCount -= tokens;
            }

        }
        public void TotalTokensUpdate(bool add, double tokens)
        {
            if (add)
            {
                TotalTokenCount += tokens;
            }
            else
            {
                TotalTokenCount -= tokens;
            }

        }
        public void ShippableCodeUpdate(bool add, double code)
        {
            if (add)
            {
                ShippableCode += code;
            }
            else
            {
                ShippableCode -= code;
            }

        }

        public void InvestorsUpdate(bool add, double investors)
        {
            if (add)
            {
                Investors += investors;
            }
            else
            {
                Investors -= investors;
            }

        }

        public void PointsUpdate(bool add, double points)
        {
            if (add)
            {
                Points += Points;
            }
            else
            {
                Points -= Points;
            }
        }



        //DP:Still need to implement something for those dang cards.


    }


    public class Tool{
        public int Value { get; set; }
        public bool Active { get; set; }

        public Tool(int value, bool active)
        {
            Value = value;
            Active = active;
        }
     }

    public class Tools
    {
        public int ToolCount { get; set; }
        public int CurrentValue { get; set; }
        public Tool[] ToolArr { get; set; }
        public Tools()
        {
            ToolArr = new Tool[3];
            CurrentValue = 1;
            ToolCount = 0;
            for (int i = 0; i < 3; i++)
            {
                ToolArr[i] = new Tool(0, true);
            }
        }

        public int getMax()
        {
            int max = 0;
            foreach (Tool t in ToolArr)
            {
                if (t.Value > max)
                {
                    max = t.Value;
                }
            }
            return max;
        }
    }
}
