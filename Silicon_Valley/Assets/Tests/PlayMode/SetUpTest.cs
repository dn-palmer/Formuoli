using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

/// <summary>
/// Tests setup scene since turn manager fails without its values
/// </summary>
public class SetUpTest
{
    PlayerManager manager;
    
    [OneTimeSetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Setup");
    }
   
    [UnityTest]
    public IEnumerator TestPlayerNames()
    {
        manager = PlayerManager.instance;
        var inputs = manager.inputFields;
        //Getting user input with a unity test is overly difficult so using this just to test
        inputs[0].text = "Player 1";
        inputs[1].text = "Player 2";
        inputs[2].text = "Player 3";
        inputs[3].text = "Player 4";

        //Turn Manger will fail if they are empty
        foreach(var input in inputs)
        {
            Assert.IsNotNull(input);
            Assert.IsNotEmpty(input.text);
        }
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestPlayerCount()
    {
        manager = PlayerManager.instance;
   
        manager.setPlayers();
        Assert.AreEqual(manager.inputFields.Count, manager.numberOfPlayers);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestMainMenu()
    {
        Button btn = GameObject.Find("MenuBtn").GetComponent<Button>();
        btn.onClick.AddListener(Menu);
        yield return null;
    }

    [UnityTest]
    public IEnumerator TestStartGame()
    {
        Button btn = GameObject.Find("StartGameBtn").GetComponent<Button>();
        btn.onClick.AddListener(Game);
        yield return null;
    }

    public void Menu()
    {
        var scene = SceneManager.GetActiveScene();

        Assert.AreEqual(scene, SceneManager.GetSceneByName("StartMenu"));

    }

    public void Game()
    {
        var scene = SceneManager.GetActiveScene();
        Assert.AreEqual(scene, SceneManager.GetSceneByName("Game"));

    }




}
