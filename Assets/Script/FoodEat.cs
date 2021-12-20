using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEat : MonoBehaviour
{
    public TailMovement Player;
    bool inTrigger = false;
    Coroutine runningCoroutine;
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
            runningCoroutine = StartCoroutine(CoroutineForDelay(other));
            //for (int i = 0; i < blockvalue; i++) Player.RemoveTail();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
        StopCoroutine(runningCoroutine);
    }

    private IEnumerator CoroutineForDelay(Collider other)
    {
        int blockvalue = other.gameObject.GetComponent<Block>().Value;
        Debug.Log("Block!!!");
        for (int i = 0; other.gameObject.GetComponent<Block>().Value > 0; i++)
        {
            other.gameObject.GetComponent<Block>().Value -= 1;
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
