using UnityEngine;

public class MinimapIcon : MonoBehaviour
{
    public Transform worldTarget;
    public Transform player;

    public float worldSize = 500f;
    public float minimapRadius = 100f;

    RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector3 offset = worldTarget.position - player.position;

        float x = (offset.x / worldSize) * minimapRadius * 2f;
        float y = (offset.z / worldSize) * minimapRadius * 2f;

        rect.anchoredPosition = new Vector2(x, y);
    }
}