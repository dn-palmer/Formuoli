using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SiliconAgeLibrary
{
    public class Card
    {
        public int CodeCost  { get; set; }
        public int HardWareCost { get; set; }
        public int ServerCost { get; set; }
        public int InvestorCost { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public Effect Effect;
        public List<Effect> Effects { get; set; }
        public string DisplayText;
        private System.Random rng = new System.Random();


        public Card()
        {
            SetCosts();
        }

        public void SetCosts()
        {
            
            
            CodeCost = UnityEngine.Random.Range(0, 6);
            HardWareCost = UnityEngine.Random.Range(0, 6);
            ServerCost = UnityEngine.Random.Range(0, 6);
            InvestorCost = UnityEngine.Random.Range(0, 6);

        }

        /// <summary>
        /// there is a set number of cards with each effect so set them according to that count
        /// </summary>
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

       

        /// <summary>
        /// Shuffle effects around
        /// </summary>
        public void ShuffleEffects()
        {
            
            Effects = Effects.OrderBy(e => rng.Next()).ToList();
        }

        

        public void FoodEffect(Player player)//player recieves random coffee value then reset it back
        {
           var amount =  rng.Next(1, 7);
           player.CoffeeUpdate(true, amount);
          
        }
        public void AllPlayersEffect(Player player)//need to implement selection picking
        {
            
            
            
        }
        public void ResourcesEffect(Player player)//gain random amount of a resource
        {
            var randomResource = rng.Next(0, 4);
            var amount = rng.Next(1, 7);
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

        /// <summary>
        /// if the cost is greater than 1 for any resource reduce it by 1
        /// </summary>
        public void ReduceCost()
        {
            if (CodeCost > 1) CodeCost--;
            if (HardWareCost > 1) HardWareCost--;
            if (ServerCost > 1) ServerCost--;
            if (InvestorCost > 1) InvestorCost--;
        }





    }
}
