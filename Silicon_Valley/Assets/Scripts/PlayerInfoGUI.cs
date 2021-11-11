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
        var players = instance.players;
        var currentPlayer = players[instance.playerTurn];

        playerName.SetText(currentPlayer.playerName);
        numberOfDevelopers.SetText(currentPlayer.totalTokenCount.ToString());
        numberOfDevelopers.SetText(currentPlayer.currentTokenCount.ToString());

        coffee.SetText(currentPlayer.food.ToString());
        //the resource variable names need to be changed
        hardware.SetText(currentPlayer.resource1.ToString());
        money.SetText(currentPlayer.resource1.ToString());
        shippableCode.SetText(currentPlayer.resource1.ToString());
        servers.SetText(currentPlayer.resource1.ToString());

    }
}
