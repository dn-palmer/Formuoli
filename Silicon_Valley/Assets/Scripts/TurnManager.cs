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
    public TextMeshProUGUI eventLog;
    bool phase2Flag;
    public int numOfPlayers;
    public TurnManager2 tm;
    public GameEvents gm;

    // Start is called before the first frame update
    void Start()
    {
        //numOfPlayers = PlayerManager.instance.numberOfPlayers;
        eventLog.text = "Press end turn to begin game";
        tm = new TurnManager2();
        gm = new GameEvents();
        //end turn button
        //Button confirm = confirmBtn.GetComponent<Button>();
        Button btn = endTurn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        confirmBtn.onClick.AddListener(TaskOnClickConfirm);
        //turnCountText.text = "Turn 0";
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    //For confirm button
    void TaskOnClickConfirm()
    {
        //Subtract tokens from player
        if (tm.players[tm.currentTurn].CurrentTokenCount == 0 && tm.Phase2 == false)
        {
            eventLog.text = "No tokens to place. Go to next turn";
        }
        else if (tm.Phase2 == false)
        {
            //tm.players[tm.currentTurn].CurrentTokenCount -= 5;
            //tm.players[tm.currentTurn].PiecesSet = true;
            //tm.Phase2 = tm.CheckPhase(tm.players);
            //if (tm.Phase2 == true)
            //{
            //    tm.currentTurn = tm.Phase2Turn;
            //}
            tm.players[tm.currentTurn].EventQueue.Enqueue(tm.players[tm.currentTurn].TokenEvent);
            tm.players[tm.currentTurn].TokenQueue.Enqueue(tm.players[tm.currentTurn].TokensSet);
            tm.players[tm.currentTurn].CurrentTokenCount -= tm.players[tm.currentTurn].TokensSet;
            tm.players[tm.currentTurn].TokensSet = 0;
            tm.players[tm.currentTurn].TokenEvent = "";
            if (tm.players[tm.currentTurn].CurrentTokenCount == 0)
            {
                tm.players[tm.currentTurn].PiecesSet = true;
            }
            tm.Phase2 = tm.CheckPhase(tm.players);
            if (tm.Phase2 == true)
            {
                tm.currentTurn = tm.Phase2Turn;
            }
        }
        else
        {
            gm.RunEvents(tm.players[tm.currentTurn]);
            eventLog.text = $"{tm.players[tm.currentTurn].EventLog}";
            gm.FeedTokens(tm.players[tm.currentTurn]);
            tm.ResetPieces(tm.players[tm.currentTurn]);

        }


    }

    //for end turn button
    void TaskOnClick()
    {
        if (tm.totalTurn != 0)
        {
            tm.NextTurn();
            eventLog.text = "";
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
            eventLog.text = "";
            //playerText.text = tm.players[tm.currentTurn].DisplayResourceCard();
            tm.totalTurn++;
        }




    }
}