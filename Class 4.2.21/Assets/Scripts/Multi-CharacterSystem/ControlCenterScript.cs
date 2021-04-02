using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCenterScript : MonoBehaviour {


    public GameObject[] PlayersLineup;

    [SerializeField]
    GameObject CurrentPlayer;

    void Start()
    {
        for (int i = 1; i < PlayersLineup.Length; i++)
        {
            PlayersLineup[i].GetComponent<PlayerMovement>().enabled = false;
        }

        CurrentPlayer = PlayersLineup[0];
    }


   public void ChangePlayer(GameObject player)
    {
        CurrentPlayer.GetComponent<PlayerMovement>().enabled = false;
        CurrentPlayer = player;
    }
}
