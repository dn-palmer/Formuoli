using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class SrDev : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button toolBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = toolBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        if (instance.tm.players[instance.tm.currentTurn].TokensSet == 1)
        {
            instance.eventLog.text += $"\nNo tokens left to set";
        }
        else
        {
            instance.tm.players[instance.tm.currentTurn].TokensSet++;
            instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on Sr. Dev";
            instance.tm.players[instance.tm.currentTurn].TokenEvent = "Tool";
        }
    }
}
