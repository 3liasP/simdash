using UnityEngine;

public class FoxPath : MonoBehaviour
{
    public Transform[] points;
    public float speed = 2f;

    int index = 0;

    void Update()
    {
        Transform target = points[index];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

      
        Vector3 dir = (target.position - transform.position).normalized;
        if (dir.magnitude > 0.1f)
            transform.forward = dir;

        
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            index++;
            if (index >= points.Length)
                index = 0;  
        }
    }
}
