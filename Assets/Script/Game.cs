using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Controls Controls;
    public CollisionScript collisionScript;
    public GameObject Player;
    public TailMovement _player;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }

    private void Start()
    {
        if (LevelIndex == 0) LoadLevel1();
        if (LevelIndex == 1) LoadLevel2();
        if (LevelIndex == 2) LoadLevel3();
    }

    private void Update()
    {
        Debug.Log(LevelIndex);
        if (CurrentState == State.Loss)
        {

        }

        if (CurrentState == State.Won)
        {

        }
    }

    public void OnPlayerDeath()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        collisionScript.StopCoroutine(collisionScript.TailCoroutine);
        collisionScript.StopCoroutine(collisionScript.BlockCoroutine);
        Debug.Log("Game Over...");
        ReloadLevel();
    }

    public void OnPlayerWon()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        LevelIndex++;
        Debug.Log("You won!");
        if (LevelIndex == 1) LoadLevel2();

        if (LevelIndex == 2) LoadLevel3();

        if (LevelIndex == 3)
        {
            LevelIndex = 0;
            ReloadLevel();
        }
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadLevel1()
    {
        Level1.SetActive(true);
        Level2.SetActive(false);
        Level3.SetActive(false);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 40;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 4; i++) _player.RemoveTail();
    }

    private void LoadLevel2()
    {
        Level1.SetActive(false);
        Level2.SetActive(true);
        Level3.SetActive(false);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 50;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 1; i++) _player.RemoveTail();
    }

    private void LoadLevel3()
    {
        Level1.SetActive(false);
        Level2.SetActive(false);
        Level3.SetActive(true);
        Player.transform.position = new Vector3(0f, 0.5f, -45f);
        CurrentState = State.Playing;
        _player.speed = 60;
        Controls.enabled = true;
        for (int i = 0; _player.tailAmount.Count > 1; i++) _player.RemoveTail();
    }
}
