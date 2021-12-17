using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour
{
    private float Speed;
    public Vector3 tailTarget;
    public GameObject tailTargetObj;
    public Player2 player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player2>();
        Speed = player.Speed*2;
        tailTargetObj = player.tailObjects[player.tailObjects.Count - 2];
    }

    private void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * Speed);
    }
}
