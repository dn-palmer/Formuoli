using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;
public class Field : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button fieldBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = fieldBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        instance.tm.players[instance.tm.currentTurn].TokensSet++; ;
        instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on field";
        instance.tm.players[instance.tm.currentTurn].TokenEvent = "Field";
    }
}
