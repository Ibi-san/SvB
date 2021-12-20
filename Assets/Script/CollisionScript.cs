using System.Collections;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public TailMovement Player;
    bool inTrigger = false;
    public Coroutine BlockCoroutine;
    public Coroutine TailCoroutine;


    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;

        if (other.gameObject.tag == "Food")
        {
            int foodvalue = other.gameObject.GetComponent<Food>().Value;
            Debug.Log("Food!!!");
            other.gameObject.SetActive(false);
            for (int i = 0; i < foodvalue; i++) Player.AddTail();
        }

        
        if (other.gameObject.tag == "Block" && inTrigger == true)
        {
            BlockCoroutine = StartCoroutine(BlockDelay(other));
            TailCoroutine = StartCoroutine(TailDelay(other));
            if (other.gameObject.GetComponent<Block>().Value == 0) StopCoroutine(TailCoroutine);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        StopCoroutine(BlockCoroutine);
        StopCoroutine(TailCoroutine);
    }

    private IEnumerator BlockDelay(Collider other)
    {
        Debug.Log("Block!!!");
        for (int i = 0; other.gameObject.GetComponent<Block>().Value > 0; i++)
        {
            other.gameObject.GetComponent<Block>().Value -= 1;
            yield return new WaitForSeconds(0.1f);
            if (other.gameObject.GetComponent<Block>().Value == 0) Destroy(other.transform.parent.gameObject);
        }

        
    }

    private IEnumerator TailDelay (Collider other)
    {
        for (int i = 0; other.gameObject.GetComponent<Block>().Value > 0; i++)
        {
            Player.RemoveTail();
            yield return new WaitForSeconds(0.09999f);
        }
    }
}
