using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnManager : MonoBehaviour
{
    public Button endTurn;
    public TextMeshProUGUI turnCountText;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI log;
    
    public int totalCount;
    //used to separate token placement phase from second phase.
    public int phase2Count;
    public int playerTurn;
    public bool phase2Flag;
    
    public Player[] players;
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public int numOfPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
        //Creates 4 new players
        numOfPlayers = PlayerManager.instance.numberOfPlayers;
        log.text = numOfPlayers.ToString();
        players = new Player[numOfPlayers];

        player1 = new Player();
        player1.playerName = PlayerManager.instance.inputFields[0].text;
        player2 = new Player();
        player2.playerName = PlayerManager.instance.inputFields[1].text;
        player3 = new Player();
        player3.playerName = PlayerManager.instance.inputFields[2].text;
        player4 = new Player();
        player4.playerName = PlayerManager.instance.inputFields[3].text;

        //starts a 4 player game
        PlayerGame4(players);

        phase2Flag = false;
        phase2Count = 0;
        playerTurn = 0;
        totalCount = 0;
        //end turn button
        Button btn = endTurn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        turnCountText.text = "Turn 0";
    }

    // Update is called once per frame
    void Update()
    {
        //i assume include drag and drop updating here but also could just use a second button to confirm drag and drop changes 
    }

    //for end turn button
    public void TaskOnClick()
    {
        
        log.text = "";
        if (phase2Flag == true)
        {
            log.text = "Phase 2";
            //feed tokens when taking back tokens from board
            players[playerTurn].feedTokens();
        }

        playerText.text = players[playerTurn].displayPlayerCard();
        playerTurn++;
        totalCount++;
        phase2Count++;
        turnCountText.text = $"Turn {totalCount}";


        if (playerTurn == players.Length)
        {
            playerTurn = 0;
            phase2Flag = true;
            if (phase2Count == players.Length * 2)
            {
                NewRound(players);
                phase2Flag = false;
                phase2Count = 0;
            }
        }


    }

    //Cycles through array to change who goes first each turn
    public void NewRound(Player[] arr)
    {
        Player temp = arr[0];
        for (int i = 0; i <= arr.Length - 2; i++)
        {
            arr[i] = arr[i + 1];
        }
        arr[arr.Length - 1] = temp;
    }

    //Different methods for different player counts
    void PlayerGame2(Player[] arr)
    {
        arr[0] = player1;
        arr[1] = player2;
    }
    
    void PlayerGame3(Player[] arr)
    {
        arr[0] = player1;
        arr[1] = player2;
        arr[2] = player3;
    }
        
    void PlayerGame4(Player[] arr)
    {
        arr[0] = player1;
        arr[1] = player2;
        arr[2] = player3;
        arr[3] = player4;
    }



}

//Starting point for a player class
public class Player
{
    public string playerName;
    public int currentTokenCount;
    public int totalTokenCount;
    public int food;
    public int resource1;
    public int resource2;
    public int resource3;
    public int resource4;


    public Player()
    {
        playerName = "Player";
        currentTokenCount = 1;
        totalTokenCount = 1;
        food = 8;
        resource1 = 15;
        resource2 = 0;
        resource3 = 0;
        resource4 = 0;
    }

    public void feedTokens()
    {
        food -= totalTokenCount;
        if (food < 0)
        {
            while (food < 0)
            {
                //need to be able to select a resource here. just used a placeholder
                resource1--;
                food++;
            }
        }
    }


    public string displayPlayerCard()
    {
        return $"{playerName}:\nTokens: {currentTokenCount} / {totalTokenCount}    Food: {food}\n" +
            $"Resource 1: {resource1}\nResource 2: {resource2}\n" +
            $"Resource 3: {resource3}\nResource 4: {resource4}";
    }
}

