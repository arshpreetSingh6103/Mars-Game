using UnityEngine;
using UnityEngine.UI;

public class MiniMapController : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Map UI")]
    public RectTransform mapContainer;
    public RectTransform playerArrow;

    [Header("World Settings")]
    public float worldSize = 500f;

    [Header("Minimap Settings")]
    public float minimapRadius = 100f;

    void Update()
    {
        UpdateMapPosition();
        UpdatePlayerRotation();
    }

    void UpdateMapPosition()
    {
        float x = -(player.position.x / worldSize) * minimapRadius * 2f;
        float y = -(player.position.z / worldSize) * minimapRadius * 2f;

        mapContainer.anchoredPosition = new Vector2(x, y);
    }

    void UpdatePlayerRotation()
    {
        playerArrow.localEulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
    }
}