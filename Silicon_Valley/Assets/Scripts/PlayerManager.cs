using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int numberOfPlayers;

    
    public List<InputField> inputFields; 

    public static PlayerManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void setPlayers()
    {   
        numberOfPlayers = 4;
    }

}
