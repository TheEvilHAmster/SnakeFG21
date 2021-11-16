using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    [SerializeField] private MyLinkedList<Transform> segments;
    private SpriteRenderer SR;
    public BoxCollider2D gridArea;

    public enum Foodtype
    {
        Food = 1,
        MegahFood = 2,
        SpeedFood = 3
    }
    public Foodtype foodType = Foodtype.Food;

    private void Start()
    {
        RandomizePotition();
        RandomizeFoodtype();
    }

    public Foodtype whatAmI()
    {
        return foodType;
    }
    private void RandomizeFoodtype()
    {
        int randomfood = Random.Range(1, 4);

        switch (randomfood)
        {
            case 1 : 
                foodType = Foodtype.Food;
                SR.color = Color.red;
                break;
            case 2:
                foodType = Foodtype.MegahFood;
                SR.color = Color.yellow;
                break;
            case 3:
                foodType = Foodtype.SpeedFood;
                SR.color = Color.cyan;
                break;
            default: foodType = Foodtype.Food;
                SR.color = Color.red;
                break;
        }
        
    }
    private void RandomizePotition()
    {
        
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x+1, bounds.max.x-1);
        float y = Random.Range(bounds.min.y+1, bounds.max.y-1);
        
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0f);
    }

    public void Restartfood()
    {
        RandomizeFoodtype();
        RandomizePotition();
    }


    private void Awake()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
    }
}
