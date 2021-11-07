using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerInfoGUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TurnManager playerInfo;
    public Player[] players;
    public 
    void Start()
    {
        players = playerInfo.players;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
