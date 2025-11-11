using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraColor : MonoBehaviour
{
    [SerializeField]
    private Color[] palette = { Color.black, Color.white };

    [SerializeField]
    [Min(0f)]
    private float changeInterval = 2f;

    private Camera targetCamera;
    private float elapsedTime;
    private int currentIndex;

    private void Awake()
    {
        targetCamera = GetComponent<Camera>();

        if (palette == null || palette.Length == 0)
        {
            palette = new[] { targetCamera.backgroundColor };
        }

        ApplyColor(0);
    }

    private void Update()
    {
        if (palette.Length <= 1 || changeInterval <= 0f)
        {
            return;
        }

        elapsedTime += Time.deltaTime;
        if (elapsedTime < changeInterval)
        {
            return;
        }

        elapsedTime = 0f;
        var nextIndex = (currentIndex + 1) % palette.Length;
        ApplyColor(nextIndex);
    }

    private void ApplyColor(int paletteIndex)
    {
        currentIndex = paletteIndex;
        targetCamera.backgroundColor = palette[currentIndex];
    }
}
