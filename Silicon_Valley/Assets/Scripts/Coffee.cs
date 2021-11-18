using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class Coffee : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button coffeeBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = coffeeBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {

        if (instance.tm.players[instance.tm.currentTurn].TokensSet == instance.tm.players[instance.tm.currentTurn].CurrentTokenCount)
        {
            instance.eventLog.text = $"No tokens left to set";
        }
        else
        {
            instance.tm.players[instance.tm.currentTurn].TokensSet++;
            instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on coffee";
            instance.tm.players[instance.tm.currentTurn].TokenEvent = "Coffee";
        }
    }
}
