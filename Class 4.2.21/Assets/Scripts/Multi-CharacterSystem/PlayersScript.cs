using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersScript : MonoBehaviour
{
    public ControlCenterScript mind;

    void OnMouseDown()
    {
        mind.ChangePlayer(this.gameObject);
        GetComponent<PlayerMovement>().enabled = true;
    }
}