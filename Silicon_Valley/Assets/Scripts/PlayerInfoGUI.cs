using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerInfoGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject script;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI numberOfDevelopers;
    public TextMeshProUGUI numberOfDevelopersRemaining;
    public TextMeshProUGUI coffee;
    public TextMeshProUGUI hardware;
    public TextMeshProUGUI money;
    public TextMeshProUGUI shippableCode;
    public TextMeshProUGUI servers;
    public TextMeshProUGUI tools;
 


    private TurnManager instance;

    void Start()
    {

        instance = script.GetComponent<TurnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            SetGUI();
        
    }
    /// <summary>
    /// sets gui to reflect current player state
    /// </summary>
    void SetGUI()
    {
        var players = instance.tm.players;
        var currentPlayer = players[instance.tm.currentTurn];

        playerName.SetText(currentPlayer.PlayerName);
        numberOfDevelopers.SetText(currentPlayer.TotalTokenCount.ToString());
        numberOfDevelopersRemaining.SetText(currentPlayer.CurrentTokenCount.ToString());
        if (instance.tm.Phase2 == true)
        {
            instance.useToolBtn.gameObject.SetActive(true);

            instance.log.text = $"Phase2. Press confirm to run events. {currentPlayer.EventQueue.Count} events left.";
            if (currentPlayer.EventQueue.Count > 0)
            {
                instance.log.text += $"\n Next Event: {currentPlayer.EventQueue.Peek()}.";
            }
            if(currentPlayer.ToolFlag == true)
            {
                instance.log.text += $"\n\n You have a tool. Would you like to use it?";
            }
        }
        else
        {
            instance.useToolBtn.gameObject.SetActive(false);
            instance.log.text = "Phase1. Press confirm to place pieces";
        }
        coffee.SetText(currentPlayer.Coffee.ToString());
        //the resource variable names need to be changed
        hardware.SetText(currentPlayer.Hardware.ToString());
        money.SetText(currentPlayer.Investors.ToString());
        shippableCode.SetText(currentPlayer.ShippableCode.ToString());
        servers.SetText(currentPlayer.Servers.ToString());
        tools.SetText(currentPlayer.DisplayTools());

    }
}
