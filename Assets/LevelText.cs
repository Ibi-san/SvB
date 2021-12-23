using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text Text;
    public Game Game;
    
    void FixedUpdate()
    {
        Text.text = "Level " + (Game.LevelIndex + 1).ToString();
    }
}
