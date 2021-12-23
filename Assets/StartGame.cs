using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject StartCanvas;
    public Game Game;
    public TailMovement Player;

    public void StartGameButton()
    {
        StartCanvas.SetActive(false);
        Time.timeScale = 1;
        Player.enabled = true;
        Game.ReloadLevel();
        PlayerPrefs.SetInt("gameStarted", 1);
        PlayerPrefs.Save();
    }
}
