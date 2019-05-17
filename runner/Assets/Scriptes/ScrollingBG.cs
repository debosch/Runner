using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    private readonly float backgroundSize = 34f;
    public float parallaxSpeed;

    private Transform cam;
    private Transform[] backgrounds;

    private int leftIndex;
    private int rightIndex;

    private float lastCamPosX;

    private void Start()
    {
        cam = Camera.main.transform;

        backgrounds = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            backgrounds[i] = transform.GetChild(i);

        leftIndex = 0;
        rightIndex = backgrounds.Length - 1;
    }

    private void Update()
    {

        var offset = cam.position.x - lastCamPosX;
        transform.position += Vector3.right * offset * parallaxSpeed;
        lastCamPosX = cam.position.x;
        
        if (cam.position.x > backgrounds[rightIndex].position.x)
            ScrollLeft();
    }

    private void ScrollLeft()
    {
        backgrounds[leftIndex].position = Vector3.right * (backgrounds[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == backgrounds.Length)
            leftIndex = 0;
    }
}
