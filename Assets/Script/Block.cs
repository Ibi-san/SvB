using UnityEngine;

public class Block : MonoBehaviour
{
    public int Value;
    public TextMesh Text;

    private void Start()
    {
        Value = Random.Range(1, 30);
}

    private void Update()
    {
        Text.text = Value.ToString();
    }
}
