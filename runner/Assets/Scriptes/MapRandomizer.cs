using UnityEngine;

public class MapRandomizer : MonoBehaviour
{
    //LevPlatform sizeX is 6f;

    [SerializeField] private Transform firstPlatform;
    [SerializeField] private Transform bigPlatform;
    [SerializeField] private Transform midPlatform;
    [SerializeField] private Transform flatPlatform;
    [SerializeField] private Transform target;

    private readonly float jumpHeight = 3f;

    private float maxOffsetX;
    private float minOffsetY;

    private GameObject lastPlatform;
    private Vector3 lastPlatformPos;

    private void Start()
    {
        lastPlatform = firstPlatform.gameObject;
        lastPlatformPos = firstPlatform.transform.position;
        //GenerateMap();
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, lastPlatformPos) < 25f)
            GenerateMap();

    }

    private void GenerateMap()
    {
        for (int i = 0; i < 5; i++)
        {
            maxOffsetX = 6f;

            var offsetX = Random.Range(1, maxOffsetX - 0.5f);
            var newPlatformPos = new Vector3(lastPlatformPos.x + maxOffsetX + offsetX, lastPlatformPos.y, 0);
            lastPlatformPos = newPlatformPos;

            Instantiate(bigPlatform, newPlatformPos, Quaternion.identity);

            Debug.Log(Vector3.Distance(target.position, lastPlatformPos));
            //float offsetY = Random.Range(minOffsetY, jumpHeight);
        }
    }
}
