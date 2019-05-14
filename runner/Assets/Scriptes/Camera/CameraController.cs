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
        

        if (target != null)
        {
            transform.position = new Vector3(
                Mathf.Clamp(target.position.x, 0, Mathf.Infinity), 0, transform.position.z);
        }
    }
}
