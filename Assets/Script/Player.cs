using UnityEngine;

public class Player : MonoBehaviour
{
    public TailMovement TailMovement;
    public TextMesh Text;
    public Game Game;

    private void Update()
    {
        int Value = TailMovement.tailAmount.Count;
        Text.text = Value.ToString();
        if (Value < 1) Death();
    }

    public void Death()
    {
        Game.OnPlayerDeath();
        TailMovement._rigidbody.isKinematic = true;
    }
}
