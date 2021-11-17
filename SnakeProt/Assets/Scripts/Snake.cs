using System.Collections;
using UnityEngine;

public class Snake : MonoBehaviour
{

    private Vector2 direction= Vector2.right;

    private MyLinkedList<Transform> segments;
    public Transform SegmentPrefab;
    [Range(1,10),SerializeField]private int updaterate = 4;
    private int iterator = 2;
    private int AmountOfApples =0;
    [SerializeField] private GameObject apples;
    


    private void Start()
    {
        segments = new MyLinkedList<Transform>();
        segments.AddLast(transform);
        transform.position = new Vector3(0, 0, 0);
        Grow();
        for (int i = 0; i < AmountOfApples; i++)
        {
            Instantiate(apples);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        if (iterator % updaterate == 0)
        {
            for (int i = segments.Count() - 1; i >= 1; i--)
            {
                segments.GetNodeAtIndex(i).data.position = segments.GetNodeAtIndex(i-1).data.position;
                
            }
            transform.position += (Vector3)direction;
        }

        iterator++;

    }

    void Grow()
    {

        Transform segment = Instantiate(SegmentPrefab);
        segment.position = segments.GetNodeAtIndex(segments.Count() - 1).data.position;
        segments.AddLast(segment);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Food"))
        {
            
            
            var thing = other.GetComponent<Food>().whatAmI();
            switch (thing)
            {
                case Food.Foodtype.Food:
                    Grow();
                    ScoreScript.scoreValue +=1;
                    break;
                
                case Food.Foodtype.MegahFood:
                    Grow();
                    Grow();
                    ScoreScript.scoreValue +=2;
                    break;
                
                case Food.Foodtype.SpeedFood:
                    FastBoodst();
                    ScoreScript.scoreValue +=4;
                    break;
                default:
                    break;
            }
            other.GetComponent<Food>().Restartfood();
        }

        if (other.CompareTag("Obsticle"))
        {
            for (int i = 1; i < segments.Count(); i++)
            {
                Destroy(segments.GetNodeAtIndex(i).data.gameObject);
            }
            
            segments.Clear(); 
            segments.AddLast(transform);
            
            
            transform.position = Vector3.zero;
            Grow();
            
            ScoreScript.scoreValue =0;
        }
        
    }

    private void FastBoodst()
    {
        StartCoroutine(BoostSnakeSpeed());
    }

    private IEnumerator BoostSnakeSpeed()
    {
        int prev = updaterate;
        float countDown = 5f;
        updaterate = 2;

        while (countDown >= 0)
        {
            
            countDown -= Time.deltaTime;
            yield return null;
        }
        updaterate = 6;
    }

}
