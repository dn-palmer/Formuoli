using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiliconAgeLibrary
{
    public class Card
    {
        public int CodeCost  { get; set; }
        public int HardWareCost { get; set; }
        public int ServerCost { get; set; }
        public int InvestorCost { get; set; }
        public Effect Effect;
        public List<Effect> Effects { get; set; }
        private Random rng = new Random();


        public Card()
        {
            SetCosts();
        }

        public void SetCosts()
        {
            int[] cost = new int[4];
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                cost[i] = rnd.Next(0, 4);
            }
            CodeCost = cost[0];
            HardWareCost = cost[1];
            ServerCost = cost[2];
            InvestorCost = cost[3];

        }

        public void SetEffects()
        {
            Effects = new List<Effect>();
            for (int i = 0; i < 7; i++)//7 cards with food effect
            {
                var effect = Effect.Food;
                Effects.Add(effect);
            }
            for (int i = 0; i < 10; i++)//10 with all players get reward
            {
                var effect = Effect.AllPlayers;
                Effects.Add(effect);
            }
            for (int i = 0; i < 5; i++)//5 with resource
            {
                var effect = Effect.Resources;
                Effects.Add(effect);
            }
            for (int i = 0; i < 4; i++)// with Tool
            {
                var effect = Effect.Tool;
                Effects.Add(effect);
                
            }
            for (int i = 0; i < 3; i++)//3 with Produce resource, points, single use tool
            {
                var effect = Effect.ProduceResources;
                Effects.Add(effect);
                effect = Effect.Points;
                Effects.Add(effect);
                
            }
            for (int i = 0; i < 2; i++)// 2 with sr dev
            {
                var effect = Effect.SrDev;
                Effects.Add(effect);
            }
            for (int i = 0; i < 1; i++)//1 with tool, card,take two
            {
                var effect = Effect.Card;
                Effects.Add(effect);
                effect = Effect.TakeTwo;
                Effects.Add(effect);
            }
            

        }

       

        public void ShuffleEffects()
        {
            
            Effects = Effects.OrderBy(a => rng.Next()).ToList();
        }

        

        public void FoodEffect(Player player)//player recieves random coffee value then reset it back
        {
           var amount =  rng.Next(1, 3);
           player.CoffeeUpdate(true, amount);
          
        }
        public void AllPlayersEffect(Player player)//need to implement selection picking
        {
            
            
            
        }
        public void ResourcesEffect(Player player)//gain random amount of a resource
        {
            var randomResource = rng.Next(0, 4);
            var amount = rng.Next(1, 4);
            switch (randomResource)
            {
                case 0:
                    player.HardwareUpdate(true, amount);
                    break;
                case 1:
                    player.InvestorsUpdate(true, amount);
                    break;
                case 2:
                    player.ServersUpdate(true, amount);
                    break;
                case 3:
                    player.ShippableCodeUpdate(true, amount);
                    break;
            }

        }
        public void PointsEffect(Player player)//player recieves random amount of points we need to create a point update method
        {
            var amount = rng.Next(1, 3);
            player.PointsUpdate(true, amount);
        }

        public void ProduceResources(Player player)//get a random resource as if player is on a resource space
        {
            int amount;
            var randomResource = rng.Next(0, 4);
            var roll = rng.Next(1, 7) + rng.Next(1, 7);
            switch (randomResource)
            {
                case 0:
                    amount = roll / 5;
                    player.HardwareUpdate(true, amount);
                    break;
                case 1:
                    amount = roll / 6;
                    player.InvestorsUpdate(true, amount);
                    break;
                case 2:
                    amount = roll / 4;
                    player.ServersUpdate(true, amount);
                    break;
                case 3:
                    amount = roll / 3;
                    player.ShippableCodeUpdate(true, amount);
                    break;
            }


        }

        public void ToolEffect(Player player)//gain one tool is this the right way to use tool?
        {
            player.ToolCol.CurrentValue++;

        }

        public void SrDevEffect(Player player)//increase agriculture/srdev track by 1
        {
            player.AgCount++;
        }

        public void CardEfffect(Player player, Card nextCard)//get next Civilization card
        {
            switch (nextCard.Effect)
            {
                case Effect.Food:
                    FoodEffect(player);
                    break;
                case Effect.AllPlayers:
                    AllPlayersEffect(player);
                    break;
                case Effect.Resources:
                    ResourcesEffect(player);
                    break;
                case Effect.Points:
                    PointsEffect(player);
                    break;
                case Effect.ProduceResources:
                    ProduceResources(player);
                    break;
                case Effect.Tool:
                    ToolEffect(player);
                    break;
                case Effect.SrDev:
                    SrDevEffect(player);
                    break;
                case Effect.TakeTwo:
                    PickTwoEffect(player);
                    break;

            }
        }

        public void PickTwoEffect(Player player)//need to implement resource picking
        {

        }

        public void ReduceCost()
        {
            if (CodeCost > 0) CodeCost--;
            if (HardWareCost > 0) HardWareCost--;
            if (ServerCost > 0) ServerCost--;
            if (InvestorCost > 0) InvestorCost--;
        }





    }
}
