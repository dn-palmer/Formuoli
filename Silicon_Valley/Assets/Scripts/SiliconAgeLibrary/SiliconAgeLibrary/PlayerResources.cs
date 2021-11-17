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
        public double TotalTokenCount {get;set;}

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

       

        //DP:Still need to implement something for those dang cards.


    }

}
