using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = -1f;
    public GameObject _tailPrefab;

    private void Start()
    {
        tailObjects.Add(gameObject);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        //if(Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * 30 * Time.deltaTime;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.left * 30 * Time.deltaTime;
        //}
    }

    public void AddTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(GameObject.Instantiate(_tailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
}
