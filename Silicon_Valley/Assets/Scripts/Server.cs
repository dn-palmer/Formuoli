using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class Server : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button serverBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = serverBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {

        instance.tm.players[instance.tm.currentTurn].TokensSet++; ;
        instance.eventLog.text = $"{instance.tm.players[instance.tm.currentTurn].TokensSet} token/tokens to set on server";
        instance.tm.players[instance.tm.currentTurn].TokenEvent = "Server";
    }
}
