using System.Collections.Generic;
using UnityEngine;
using SiliconAgeLibrary;
using UnityEngine.UI;
using System;
using TMPro;
using System.Collections;
using System.Threading.Tasks;

public class CivilizationCards : MonoBehaviour
{
    public TextMeshProUGUI CardOneText;
    public TextMeshProUGUI CardTwoText;
    public TextMeshProUGUI CardThreeText;




    private TurnManager TurnManager;
    private List<Card> CivCards;
    private List<Effect> Effects;
    private Card[] AvailableCards { get; set; }
    
    private GameObject CardOneShippableCodeIcon;
    private TextMeshProUGUI CardOneShippableCodeAmount;
    private GameObject CardOneServerIcon;
    private TextMeshProUGUI CardOneServerAmount;
    private GameObject CardOneHardwareIcon;
    private TextMeshProUGUI CardOneHardwareAmount;
    private GameObject CardOneMoneyIcon;
    private TextMeshProUGUI CardOneMoneyAmount;

    private GameObject CardTwoShippableCodeIcon;
    private TextMeshProUGUI CardTwoShippableCodeAmount;
    private GameObject CardTwoServerIcon;
    private TextMeshProUGUI CardTwoServerAmount;
    private GameObject CardTwoHardwareIcon;
    private TextMeshProUGUI CardTwoHardwareAmount;
    private GameObject CardTwoMoneyIcon;
    private TextMeshProUGUI CardTwoMoneyAmount;

    private GameObject CardThreeShippableCodeIcon;
    private TextMeshProUGUI CardThreeShippableCodeAmount;
    private GameObject CardThreeServerIcon;
    private TextMeshProUGUI CardThreeServerAmount;
    private GameObject CardThreeHardwareIcon;
    private TextMeshProUGUI CardThreeHardwareAmount;
    private GameObject CardThreeMoneyIcon;
    private TextMeshProUGUI CardThreeMoneyAmount;

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
        InstantiateCardDisplayProperties();
        CardDisplay(AvailableCards[0], CardOneText, 1);
        CardDisplay(AvailableCards[1], CardTwoText, 2);
        CardDisplay(AvailableCards[2], CardThreeText, 3);
    }

    

    public void CardOneOnClick()
    {
       
        
            var pickedCard = AvailableCards[0];
            TakeCard(pickedCard);
            this.CivCards.Remove(pickedCard);
            Array.Clear(AvailableCards, 0, 3);
            GetNewAvailableCards("one");
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokenEvent = "CivCard1";
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet++;
            TurnManager.eventLog.text = $"{TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet} token/tokens to set on Civilization Card(s)";
        

    }
    public void CardTwoOnClick()
    {

        
        
            var pickedCard = AvailableCards[1];
            TakeCard(pickedCard);
            this.CivCards.Remove(pickedCard);
            Array.Clear(AvailableCards, 0, 3);
            GetNewAvailableCards("two");
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokenEvent = "CivCard2";
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet++;
            TurnManager.eventLog.text = $"{TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet} token/tokens to set on Civilization Card(s)";
        

    }
    public void CardThreeOnClick()
    {

        
        
            var pickedCard = AvailableCards[2];
            TakeCard(pickedCard);
            this.CivCards.Remove(pickedCard);
            Array.Clear(AvailableCards, 0, 3);
            GetNewAvailableCards("three");
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokenEvent = "CivCard3";
            TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet++;
            TurnManager.eventLog.text = $"{TurnManager.tm.players[TurnManager.tm.currentTurn].TokensSet} token/tokens to set on Civilization Card(s)";
        
        

       
    }

    /// <summary>
    /// gets the new array after a card has been taken
    /// </summary>
    /// <param name="button"></param>
    void GetNewAvailableCards(string button)
    {
        
            switch (this.CivCards.Count)
            {

                case 2:
                    AvailableCards[0] = CivCards[0];
                    AvailableCards[1] = CivCards[1];
                    CardThree.SetActive(false);
                    AvailableCards[0].ReduceCost();
                    AvailableCards[1].ReduceCost();
                    UpdateCardDisplay();
                    break;
                case 1:
                    AvailableCards[0] = CivCards[0];
                    CardTwo.SetActive(false);
                    AvailableCards[0].ReduceCost();
                    UpdateCardDisplay();
                    break;
                case 0:
                    CardOne.SetActive(false);
                    break;
                default:

                    AvailableCards[0] = CivCards[2];
                    AvailableCards[1] = CivCards[0];
                    AvailableCards[2] = CivCards[1];



                    AvailableCards[1].ReduceCost();
                    AvailableCards[2].ReduceCost();

                    UpdateCardDisplay();
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
    void  CreateCards()
    {
        CivCards = new List<Card>(36);
        foreach (var item in Effects)
        {
            var card = new Card
            {
                Effect = item
            };
             
            switch (card.Effect)
            {
                case Effect.Food:
                    card.DisplayText = "Gain Random Amount of Coffee";
                    break;
                case Effect.AllPlayers:
                    card.DisplayText = "All Players Take Reward";
                    break;
                case Effect.Resources:
                    card.DisplayText = "Random Amount of Resource";
                    break;
                case Effect.Points:
                    card.DisplayText = "Random Amount of Points ";
                    break;
                case Effect.ProduceResources:
                    card.DisplayText = "Produce Resource";
                    break;
                case Effect.Tool:
                    card.DisplayText = "Gain A Tool";
                    break;
                case Effect.SrDev:
                    card.DisplayText = "Advance One Point On Sr.Dev Track";
                    break;
                case Effect.Card:
                    card.DisplayText = "Gain A Civilization Card";
                    break;
                case Effect.TakeTwo:
                    card.DisplayText = " Gain 2 Resources of Your Choice";
                    break;
            }
            
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
                var nextCard = CivCards[CivCards.Count - 1];
                selectedCard.CardEfffect(player, nextCard);
                CivCards.Remove(nextCard);
                break;
            case Effect.TakeTwo:
                selectedCard.PickTwoEffect(player);
                break;
            

        }

    }
    void CardDisplay(Card card, TextMeshProUGUI text, int cardNum)
    {
        text.SetText(card.DisplayText);
        if (cardNum == 1)
        {
            DetermineActive(card, CardOneShippableCodeIcon, CardOneShippableCodeAmount, "code");
            DetermineActive(card, CardOneServerIcon, CardOneServerAmount, "server");
            DetermineActive(card, CardOneHardwareIcon, CardOneHardwareAmount, "hardware");
            DetermineActive(card, CardOneMoneyIcon, CardOneMoneyAmount, "money");
        }
        else if(cardNum == 2)
        {
            DetermineActive(card, CardTwoShippableCodeIcon, CardTwoShippableCodeAmount, "code");
            DetermineActive(card, CardTwoServerIcon, CardTwoServerAmount, "server");
            DetermineActive(card, CardTwoHardwareIcon, CardTwoHardwareAmount, "hardware");
            DetermineActive(card, CardTwoMoneyIcon, CardTwoMoneyAmount, "money");
        }
        else
        {
            DetermineActive(card, CardThreeShippableCodeIcon, CardThreeShippableCodeAmount, "code");
            DetermineActive(card, CardThreeServerIcon, CardThreeServerAmount, "server");
            DetermineActive(card, CardThreeHardwareIcon, CardThreeHardwareAmount, "hardware");
            DetermineActive(card, CardThreeMoneyIcon, CardThreeMoneyAmount, "money");
        }

        

        

    }
    void UpdateCardDisplay()
    {
        switch (CivCards.Count)
        {
            case 2:
                CardDisplay(AvailableCards[0], CardOneText, 1);
                CardDisplay(AvailableCards[1], CardTwoText, 2);
                break;
            case 1:
                CardDisplay(AvailableCards[0], CardOneText, 1);
                break;
            case 0:
                break;
            default:
                CardDisplay(AvailableCards[0], CardOneText, 1);
                CardDisplay(AvailableCards[1], CardTwoText, 2);
                CardDisplay(AvailableCards[2], CardThreeText, 3);
                break;
        }
    }
    /// <summary>
    /// Determines if a card should be active or not if active it sets the value of the resource text
    /// </summary>
    /// <param name="card">the civilization card</param>
    /// <param name="icon">the icon object of the resource</param>
    /// <param name="text">the display amount for the resource</param>
    void DetermineActive(Card card, GameObject icon, TextMeshProUGUI text, string prop)
    {
        text.SetText("");


         //unity is an absolute dumpster fire and doesn't allow using an inactive game object except in Coroutines and Update this is just a bypass
            //dear god i feel like i went through  my own 12 labors of hurcles to fix this 
        
            if (prop == "code")
            {
              
                    text.SetText($"{card.CodeCost}");
          
            }
            else if (prop == "server")
            {
                    text.SetText($"{card.ServerCost}");
     
            }
            else if (prop == "hardware")
            {
                
                    text.SetText($"{card.HardWareCost}");
            }
            else
            {
             
                    text.SetText($"{card.InvestorCost}");
            }
        
        
        
        InstantiateCardDisplayProperties();
        
    }

    /// <summary>
    /// gets each cards icons and text fields from unity scene 
    /// </summary>
    void InstantiateCardDisplayProperties()
    {
        try
        {
            CardOneShippableCodeIcon = GameObject.Find("CivCard1/ShippableCodeIcon");
            CardOneShippableCodeAmount = GameObject.Find("CivCard1/ShippableCode").GetComponent<TextMeshProUGUI>();
            CardOneServerIcon = GameObject.Find("CivCard1/ServerIcon");
            CardOneServerAmount = GameObject.Find("CivCard1/Servers").GetComponent<TextMeshProUGUI>();
            CardOneHardwareIcon = GameObject.Find("CivCard1/HardwareIcon");
            CardOneHardwareAmount = GameObject.Find("CivCard1/Hardware").GetComponent<TextMeshProUGUI>();
            CardOneMoneyIcon = GameObject.Find("CivCard1/MoneyIcon");
            CardOneMoneyAmount = GameObject.Find("CivCard1/Money").GetComponent<TextMeshProUGUI>();

            CardTwoShippableCodeIcon = GameObject.Find("CivCard2/ShippableCodeIcon");
            CardTwoShippableCodeAmount = GameObject.Find("CivCard2/ShippableCode").GetComponent<TextMeshProUGUI>();
            CardTwoServerIcon = GameObject.Find("CivCard2/ServerIcon");
            CardTwoServerAmount = GameObject.Find("CivCard2/Servers").GetComponent<TextMeshProUGUI>();
            CardTwoHardwareIcon = GameObject.Find("CivCard2/HardwareIcon");
            CardTwoHardwareAmount = GameObject.Find("CivCard2/Hardware").GetComponent<TextMeshProUGUI>();
            CardTwoMoneyIcon = GameObject.Find("CivCard2/MoneyIcon");
            CardTwoMoneyAmount = GameObject.Find("CivCard2/Money").GetComponent<TextMeshProUGUI>();

            CardThreeShippableCodeIcon = GameObject.Find("CivCard3/ShippableCodeIcon");
            CardThreeShippableCodeAmount = GameObject.Find("CivCard3/ShippableCode").GetComponent<TextMeshProUGUI>();
            CardThreeServerIcon = GameObject.Find("CivCard3/ServerIcon");
            CardThreeServerAmount = GameObject.Find("CivCard3/Servers").GetComponent<TextMeshProUGUI>();
            CardThreeHardwareIcon = GameObject.Find("CivCard3/HardwareIcon");
            CardThreeHardwareAmount = GameObject.Find("CivCard3/Hardware").GetComponent<TextMeshProUGUI>();
            CardThreeMoneyIcon = GameObject.Find("CivCard3/MoneyIcon");
            CardThreeMoneyAmount = GameObject.Find("CivCard3/Money").GetComponent<TextMeshProUGUI>();
        }
        catch (NullReferenceException)//card was deleted 
        {

            
        }

    }
   

}






