using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TailMovement TailMovement;
    public TextMesh Text;

    private void Update()
    {
        int Value = TailMovement.tailAmount.Count;
        Text.text = Value.ToString();
    }
}
