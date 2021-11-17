using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SiliconAgeLibrary;

public class TurnManager : MonoBehaviour
{
    public Button endTurn;
    public Button confirmBtn;
    public TextMeshProUGUI turnCountText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI log;
    bool phase2Flag;
    public int numOfPlayers;
    public TurnManager2 tm;

    // Start is called before the first frame update
    void Start()
    {
        //numOfPlayers = PlayerManager.instance.numberOfPlayers;
        log.text = "Press end turn to begin game";

        tm = new TurnManager2();

        //end turn button
        //Button confirm = confirmBtn.GetComponent<Button>();
        Button btn = endTurn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        confirmBtn.onClick.AddListener(TaskOnClickConfirm);
        turnCountText.text = "Turn 0";
    }

    // Update is called once per frame
    void Update()
    {



    }


    //For confirm button
    void TaskOnClickConfirm()
    {
        //Subtract tokens from player
        if (tm.Phase2 == false)
        {
            tm.players[tm.currentTurn].CurrentTokenCount -= 5;
            tm.players[tm.currentTurn].PiecesSet = true;
            tm.Phase2 = tm.CheckPhase(tm.players);
            if (tm.Phase2 == true)
            {
                tm.currentTurn = tm.Phase2Turn;
            }
        }
        else
        {
            tm.ResetPieces(tm.players[tm.currentTurn]);
        }

    }

    //for end turn button
    void TaskOnClick()
    {
        if (tm.totalTurn != 0)
        {
            tm.NextTurn();
            if (tm.Phase2 == true)
            {

                tm.Phase2Count++;
                if (tm.Phase2Count == 4)
                {
                    tm.Phase2 = false;
                    tm.NewRound(tm.players);
                    tm.Phase2Turn = 0;
                    tm.Phase2Count = 0;
                }
            }
        }
        else
        {

            playerText.text = tm.players[tm.currentTurn].DisplayResourceCard();
            tm.totalTurn++;
        }

        



    }
}