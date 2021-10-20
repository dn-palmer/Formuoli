using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager1 : MonoBehaviour
{
    public int numberOfPlayers;

    private ArrayList playerNames;

    public static PlayerManager1 instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void setPlayers(int num)
    {
        numberOfPlayers = num;
    }
}
