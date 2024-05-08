using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

     int currentPlayer;
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayer = PlayerPrefs.GetInt("Current Player");
        GameObject player = Instantiate(players[currentPlayer], Vector3.zero, Quaternion.identity);
    }

   
}
