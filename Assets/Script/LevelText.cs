using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text Text;
    public Game Game;
    
    void FixedUpdate()
    {
        Text.text = "Level " + (Game.LevelIndex + 1).ToString();
        if (Game.LevelIndex == 3) Text.text = "Level " + (Game.LevelIndex).ToString();
    }
}
