using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] bullet;
    public int probability =5;     //works ok for lvl1
    public int fireRate = 5;       //works well for lvl1

    private float nextFire = 0f;
    private bool flag;
    private void Update()
    {
        CheckIfEnemyBelow(); 
        if (ProbGenerator() && ProbGenerator() && Time.time >= nextFire && !flag)
        {

            for (int i = 0; i < bullet.Length; i++)
            {
                Instantiate(bullet[i], transform.position, Quaternion.identity);
            }
            nextFire = Time.time + fireRate;
        }

    }
    private void FixedUpdate()
    {
        
    }


    private void CheckIfEnemyBelow() {
        RaycastHit2D hit=Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y-0.5f), Vector2.down);
        
        if (hit.transform!=null && hit.transform.CompareTag("enemy")) 
        {
            flag=true;
        }
        else
        {
            flag = false ;            
        }    
    }

    private bool ProbGenerator() => Random.Range(1, 101) <= probability ? true : false;
}