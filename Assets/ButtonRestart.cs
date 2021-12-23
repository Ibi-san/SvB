using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    public Game Game;

    public void Restart()
    {
        Game.ReloadLevel();
    }
}
