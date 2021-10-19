using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int numberOfPlayers;

    private ArrayList playerNames;

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
