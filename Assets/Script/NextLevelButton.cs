using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    public Game Game;
    public GameObject WinCanvas;
    public Text text1;

    private void Update()
    {
        if (Game.LevelIndex == 3)
        {
            text1.text = "YOU WON! \nTHANKS FOR PLAYING! \nRESTART GAME?";
        }
    }

    public void NexLevel()
    {
        if (Game.LevelIndex == 1) Game.LoadLevel2();

        if (Game.LevelIndex == 2) Game.LoadLevel3();

        if (Game.LevelIndex == 3)
        {
            Game.ReloadLevel();
        }
        WinCanvas.SetActive(false);
    }
}
