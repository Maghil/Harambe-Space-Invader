using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupContoller : MonoBehaviour
{
    public float distanceEachLoop =0.4f;      //yaxis multiplied by 2
    public float timeBettweenMovement=1f;

    private float startTime = 0f;
    private bool dir=false;     //start from left to right
    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime) //check shoot time
        {
            MoveGroup();
            startTime = Time.time + timeBettweenMovement;
        }

    }

    void MoveGroup()
    {
        x = Mathf.Clamp(x, -0.4f, 0.4f);
        if (x == 0.4f)
        {
            dir = true;
            transform.position = new Vector2(x, y -= distanceEachLoop * 2);
            x -= distanceEachLoop;
        }
        else if (x == -0.4f)
        {
            dir = false;           
            transform.position = new Vector2(x, y -= distanceEachLoop * 2);
            x += distanceEachLoop;
        }
        else 
        {
            if (!dir)
            {
                x += distanceEachLoop;
                transform.position = new Vector2(x, y);
                
            }
            else
            {
                x -= distanceEachLoop;
                transform.position = new Vector2(x, y);
                
            }
        }
        
    }
}
