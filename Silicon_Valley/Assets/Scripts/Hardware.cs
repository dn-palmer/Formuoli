using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class Hardware : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button hardwareBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = hardwareBtn.GetComponent<Button>();
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
            instance.eventLog.text += $"\nNo tokens left to set";
        }
        else
        {
            instance.tm.players[instance.tm.currentTurn].TokensSet++;
            instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on hardware";
            instance.tm.players[instance.tm.currentTurn].TokenEvent = "Hardware";
        }
    }
}
