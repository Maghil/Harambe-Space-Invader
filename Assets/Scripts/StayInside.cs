using UnityEngine;

public class StayInside : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -1.8f, 1.8f), Mathf.Clamp(transform.position.y, -3.5f, -3.5f));
    }
}
