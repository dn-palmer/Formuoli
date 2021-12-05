using System.Collections.Generic;
using UnityEngine;
using SiliconAgeLibrary;
using UnityEngine.UI;
using System;


public class CivilizationCards : MonoBehaviour
{
   
    private TurnManager TurnManager;
    private List<Card> CivCards;
    private List<Effect> Effects;
    private Card[] AvailableCards { get; set; }
    private GameObject CardOne;
    private GameObject CardTwo;
    private GameObject CardThree;



    void Start()
    {
        TurnManager = GameObject.Find("ConfirmBtn").GetComponent<TurnManager>();
        CardOne = GameObject.Find("CivCard1");
        CardTwo = GameObject.Find("CivCard2");
        CardThree = GameObject.Find("CivCard3");
        AvailableCards = new Card[3];
        GetEffects();
        CreateCards();
        AvailableCards[0] = CivCards[0];
        AvailableCards[1] = CivCards[1];
        AvailableCards[2] = CivCards[2];
    }

    public void CardOneOnClick()
    {
        var pickedCard = AvailableCards[0];
        TakeCard(pickedCard);
        CivCards.Remove(pickedCard);
        Array.Clear(AvailableCards,0,3);
        GetNewAvailableCards("one");
        
    }
    public void CardTwoOnClick()
    {
       
        var pickedCard = AvailableCards[1];
        TakeCard(pickedCard);
        CivCards.Remove(pickedCard);
        Array.Clear(AvailableCards, 0, 3);
        GetNewAvailableCards("two");
    }
    public void CardThreeOnClick()
    {
        
        var pickedCard = AvailableCards[2];
        TakeCard(pickedCard);
        CivCards.Remove(pickedCard);
        Array.Clear(AvailableCards, 0, 3);
        GetNewAvailableCards("three");
    }

    /// <summary>
    /// gets the new array after a card has been taken
    /// </summary>
    /// <param name="button"></param>
    void GetNewAvailableCards(string button)
    {
        switch (CivCards.Count)
        {
            
            case 2:
                AvailableCards[0] = CivCards[0];
                AvailableCards[1] = CivCards[1];
                CardThree.SetActive(false);
                AvailableCards[0].ReduceCost();
                AvailableCards[1].ReduceCost();
                break;
            case 1:
                AvailableCards[0] = CivCards[0];
                CardTwo.SetActive(false);
                AvailableCards[0].ReduceCost();
                break;
            case 0:
                CardOne.SetActive(false);
                break;
            default:
                AvailableCards[0] = CivCards[0];
                AvailableCards[1] = CivCards[1];
                AvailableCards[2] = CivCards[2];
                if (button == "one")
                {
                    AvailableCards[1].ReduceCost();
                    AvailableCards[2].ReduceCost();

                }
                else if (button == "two")
                {
                    AvailableCards[0].ReduceCost();
                    AvailableCards[2].ReduceCost();
                }
                else
                {
                    AvailableCards[0].ReduceCost();
                    AvailableCards[1].ReduceCost();
                }
                break;
        }
    }
    
    /// <summary>
    /// Get the shuffled list of effects that the cards have
    /// </summary>
    void GetEffects()
    {
        var card = new Card();
        card.SetEffects();
        card.ShuffleEffects();
        Effects = card.Effects;
    }

    /// <summary>
    /// create all 36 cards this currently behaves weird and gives the same random values for all cards
    /// </summary>
    void CreateCards()
    {
        CivCards = new List<Card>(36);
        foreach (var item in Effects)
        {
            var card = new Card
            {
                Effect = item
            };
            CivCards.Add(card);

        }
        
    }
    /// <summary>
    /// take the card and execute the card effect
    /// </summary>
    /// <param name="selectedCard"></param>
    void TakeCard(Card selectedCard)
    {
        var player = TurnManager.tm.players[TurnManager.tm.currentTurn];

        switch (selectedCard.Effect)
        {
            case Effect.Food:
                selectedCard.FoodEffect(player);
                break;
            case Effect.AllPlayers:
                selectedCard.AllPlayersEffect(player);
                break;
            case Effect.Resources:
                selectedCard.ResourcesEffect(player);
                break;
            case Effect.Points:
                selectedCard.PointsEffect(player);
                break;
            case Effect.ProduceResources:
                selectedCard.ProduceResources(player);
                break;
            case Effect.Tool:
                selectedCard.ToolEffect(player);
                break;
            case Effect.SrDev:
                selectedCard.SrDevEffect(player);
                break;
            case Effect.Card:
                var nextCard = CivCards[3];
                selectedCard.CardEfffect(player, nextCard);
                CivCards.Remove(nextCard);
                
                break;
            case Effect.TakeTwo:
                selectedCard.PickTwoEffect(player);
                break;
            

        }


    }

    
    
    
    
}
