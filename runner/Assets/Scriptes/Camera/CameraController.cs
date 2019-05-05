using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform target;
    
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        Mathf.Clamp(transform.position.x, 0, Mathf.Infinity);

        if (target != null)
        {
            transform.position = new Vector3(
                target.position.x, 0, transform.position.z);
        }
    }
}
