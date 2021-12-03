using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TurnManagerTest
{
    PlayerManager manager;
    TurnManager turnManager;
    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Game");
        
    }
    
    [UnityTest]
    public IEnumerator TestNumberOfPlayers()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();
        Assert.AreEqual(manager.numberOfPlayers, turnManager.numOfPlayers);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestPlayersCreated()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();
        Assert.AreEqual(manager.numberOfPlayers, turnManager.players.Length);
        foreach(var player in turnManager.players)
        {
            Assert.IsNotNull(player);
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestPlayersHaveName()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();
        foreach(var player in turnManager.players)
        {
            Assert.IsNotNull(player.playerName);
            Assert.IsNotEmpty(player.playerName);
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestEndTurn()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();
        for(int i = 0; i < 9; i++)
        {
            int playerTurn = turnManager.playerTurn;
            int totalCount = turnManager.totalCount;
            int phase2Count = turnManager.phase2Count;

            turnManager.TaskOnClick();
            Assert.AreNotEqual(playerTurn, turnManager.playerTurn);
            Assert.AreNotEqual(totalCount, turnManager.totalCount);
            Assert.AreNotEqual(phase2Count, turnManager.phase2Count);

            if (playerTurn == turnManager.players.Length)
            {
                Assert.AreEqual(0, turnManager.playerTurn);
                Assert.IsTrue(turnManager.phase2Flag);
            }

            if (playerTurn == turnManager.players.Length * 2)
            {
                Assert.IsFalse(turnManager.phase2Flag);
                Assert.AreEqual(0, turnManager.phase2Count);
            }
            
        }
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestNewRound()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();

        var originalPlayers = turnManager.players;
        string originalName = originalPlayers[0].playerName;

        turnManager.NewRound(originalPlayers);
        Assert.AreNotEqual(originalName, originalPlayers[0].playerName);//check that first player changed


        yield return null;
    }

    [UnityTest]
    public IEnumerator TestFeedTokens()
    {
        manager = PlayerManager.instance;
        turnManager = GameObject.Find("EndTurnBtn").GetComponent<TurnManager>();

        
        int foodTokens = turnManager.players[0].food;
        int totalTokens = turnManager.players[0].totalTokenCount;
        turnManager.players[0].feedTokens();
        Assert.AreEqual(foodTokens - totalTokens, turnManager.players[0].food);


        yield return null;
    }



}
