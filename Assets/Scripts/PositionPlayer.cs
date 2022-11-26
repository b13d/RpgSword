using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    public GameObject player;
    Transform posPlayer;


    void Update()
    {
        posPlayer = player.GetComponent<Transform>();
        transform.position = posPlayer.position;
    }
}
