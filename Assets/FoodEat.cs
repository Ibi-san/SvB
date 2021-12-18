using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodEat : MonoBehaviour
{
    public SnakeMovement PlayerMove;
    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Food")
        {
            int foodvalue = other.gameObject.GetComponent<Food>().Value;
            Debug.Log("Food!!!");
            other.gameObject.SetActive(false);
            for (int i = 0; i < foodvalue; i++) PlayerMove.AddBodyPart();
        }
    }
}
