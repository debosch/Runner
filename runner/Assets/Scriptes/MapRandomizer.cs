using UnityEngine;

public class MapRandomizer : MonoBehaviour
{

    [SerializeField] private Transform firstPlatform;
    [SerializeField] private Transform bigPlatform;
    [SerializeField] private Transform midPlatform;
    [SerializeField] private Transform flatPlatform;
    [SerializeField] private Transform target;

    private readonly float jumpHeight = 3f;
    private readonly float minY = -4.5f;
    private readonly float maxY = 0;

    private float maxOffsetX;
    private float maxOffsetY;

    private GameObject lastPlatform;
    private Vector3 lastPlatformPos;

    private void Start()
    {
        lastPlatform = firstPlatform.gameObject;
        lastPlatformPos = firstPlatform.transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, lastPlatformPos) < 25f)
            GenerateMap();

    }

    private void GenerateMap()
    {
        for (int i = 0; i < 10; i++)
        {
            maxOffsetX = 5.5f;
            maxOffsetY = 0f;

            if (lastPlatformPos.y + 2 > 0)
                maxOffsetY = Random.Range(0, -4);
            else if (lastPlatformPos.y + 2 <= 0)
            {
                if (Random.Range(-1,1) >= 0)
                {
                    //Upper
                    maxOffsetY = Random.Range(0, maxY - lastPlatformPos.y - 2f);
                }
                else
                {
                    //Lower
                    maxOffsetY = Random.Range(0, minY - lastPlatformPos.y );
                }
            }

            var offsetX = Random.Range(3, maxOffsetX);
            var newPlatformPos = new Vector3(lastPlatformPos.x + maxOffsetX + offsetX, lastPlatformPos.y + maxOffsetY, 0);
            lastPlatformPos = newPlatformPos;

            Instantiate(GetRandomPlatform(), newPlatformPos, Quaternion.identity);

        }
    }

    private Transform GetRandomPlatform()
    {
        int randomValue = Random.Range(0, 10);

        if (randomValue < 4)
            return bigPlatform;
        else if (randomValue >= 4 && randomValue < 8)
            return flatPlatform;
        else
            return midPlatform;
    }
}
