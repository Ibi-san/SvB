using UnityEngine;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    public Game Game;
    

    public void Restart()
    {
        Game.ReloadLevel();
    }
}
