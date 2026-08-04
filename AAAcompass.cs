using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AAACompass : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public RectTransform compassContent;
    public RectTransform tickPrefab;
    public TMP_Text labelPrefab;
    public TMP_Text headingText;

    [Header("Settings")]
    [Tooltip("Pixels for every degree")]
    public float pixelsPerDegree = 6f;

    private Dictionary<int, string> directions = new Dictionary<int, string>()
    {
        {0,"N"},
        {45,"NE"},
        {90,"E"},
        {135,"SE"},
        {180,"S"},
        {225,"SW"},
        {270,"W"},
        {315,"NW"}
    };

    void Start()
    {
        GenerateCompass();
    }

    void Update()
    {
        UpdateCompass();
    }

    void GenerateCompass()
    {
        // Generate from -360° to +720° for seamless scrolling
        for (int angle = -360; angle <= 720; angle += 5)
        {
            RectTransform tick = Instantiate(tickPrefab, compassContent);

            tick.anchoredPosition = new Vector2(angle * pixelsPerDegree, 0);

            // Tick sizes
            if (angle % 45 == 0)
                tick.sizeDelta = new Vector2(2, 26);      // Long
            else if (angle % 15 == 0)
                tick.sizeDelta = new Vector2(2, 18);      // Medium
            else
                tick.sizeDelta = new Vector2(2, 10);      // Small

            int normalized = ((angle % 360) + 360) % 360;

            if (directions.ContainsKey(normalized))
            {
                TMP_Text label = Instantiate(labelPrefab, compassContent);

                label.text = directions[normalized];

                label.rectTransform.anchoredPosition =
                    new Vector2(angle * pixelsPerDegree, 28);

                if (normalized % 90 == 0)
                    label.fontSize = 24;
                else
                    label.fontSize = 18;
            }
        }
    }

    void UpdateCompass()
    {
        float heading = player.eulerAngles.y;

        compassContent.anchoredPosition =
            new Vector2(-(heading * pixelsPerDegree), 0);

        headingText.text = Mathf.RoundToInt(heading) + "°";
    }
}