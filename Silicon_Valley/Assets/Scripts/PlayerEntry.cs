using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerEntry : MonoBehaviour
{
    public Button startGame;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startGame.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TaskOnClick()
    {
        PlayerManager.instance.setPlayers();
    }
}
