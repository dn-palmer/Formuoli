using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class Investor : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button investorBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = investorBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void TaskOnClick()
    {
        if (instance.tm.players[instance.tm.currentTurn].TokensSet == instance.tm.players[instance.tm.currentTurn].CurrentTokenCount)
        {
            instance.eventLog.text += $"\nNo tokens left to set";
        }
        else
        {
            instance.tm.players[instance.tm.currentTurn].TokensSet++;
            instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on investor";
            instance.tm.players[instance.tm.currentTurn].TokenEvent = "Investor";
        }
    }
}
