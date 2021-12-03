using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class Hut : MonoBehaviour
{
    public GameObject script;
    private TurnManager instance;
    public Button hutBtn;
    // Start is called before the first frame update
    void Start()
    {
        instance = script.GetComponent<TurnManager>();
        Button btn = hutBtn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick()
    {
        instance.eventLog.text = "2 tokens to set on hut";
        instance.tm.players[instance.tm.currentTurn].TokensSet+= 2;
        instance.tm.players[instance.tm.currentTurn].TokenEvent = "Hut";
    }
}
