using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

/// <summary>
/// Tests that menu works correctly 
/// </summary>
public class MenuTest
{
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
   
    [UnityTest]
    public IEnumerator TestNewGame()
    {
        Debug.Log("newgame");
        Button btn = GameObject.Find("NewGameBtn").GetComponent<Button>();
        Debug.Log(btn);
        btn.onClick.AddListener(AssertStart);
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestTutorial()
    {
        Debug.Log("tutorial");

        Button btn = GameObject.Find("TutorialBtn").GetComponent<Button>();
        btn.onClick.AddListener(AssertTutorial);
        yield return null;
    }
    [UnityTest]
    public IEnumerator TestCredits()
    {
        Debug.Log("credits");

        Button btn = GameObject.Find("CreditsBtn").GetComponent<Button>();
        btn.onClick.AddListener(AssertCredits);
        yield return null;
    }
   

    public void AssertStart()
    {
        var scene = SceneManager.GetActiveScene();
        Assert.AreEqual(scene, SceneManager.GetSceneByName("Setup"));
    }
    public void AssertTutorial()
    {
        var scene = SceneManager.GetActiveScene();
        Assert.AreEqual(scene, SceneManager.GetSceneByName("Tutorial"));
    }
    public void AssertCredits()
    {
        var scene = SceneManager.GetActiveScene();
        Assert.AreEqual(scene, SceneManager.GetSceneByName("Credits"));
    }

}
