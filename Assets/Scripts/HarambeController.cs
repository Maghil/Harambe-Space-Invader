
using UnityEngine;

public class HarambeController : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private float direction;        //direction must be vector2 if y axis control is required
    private float nextFire=0f;

    public GameObject bullet;
    public int fireRate=1;
    public float moveSpeed = 40f;   //40 is the ideal value for level 1 as on v1
    private float yAxis, xAxis;

    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    private void Update()
    {       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);    //get first finger
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            yAxis = rb.position.y;  //postion of harambe
            xAxis = rb.position.x;
            if (touchPosition.x < xAxis + 0.5f && touchPosition.x > xAxis - 0.5f && touchPosition.y < yAxis + 0.5f && touchPosition.y > yAxis - 0.5f) //check if the player is touching the object
            {
                direction = (touchPosition.x - transform.position.x);
                rb.velocity = new Vector2(direction, transform.position.y) * moveSpeed;
                if (touchPosition.y > yAxis + 0.5f || touchPosition.y < yAxis - 0.5f || touch.phase == TouchPhase.Ended) //movement will be cancelled if player moves out of harambe
                {
                    rb.velocity = Vector2.zero;
                }
            }
            else
            {
                print("error not matching");
            }
        }
        if (Time.time >= nextFire) //check shoot time
        {
            Instantiate(bullet,new Vector2(transform.position.x,-3.1f), Quaternion.identity);   //shoot from head(hard coded)
            nextFire = Time.time + fireRate;     
        }
    }
    private void ShootBullets()
    {
        
    }
}
