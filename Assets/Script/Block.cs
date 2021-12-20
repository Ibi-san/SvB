using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    public TextMesh Text;

    private void Update()
    {
        Text.text = Value.ToString();
    }
}
