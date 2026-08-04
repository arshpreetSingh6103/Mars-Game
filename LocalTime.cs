using UnityEngine;
using TMPro;
using System;

public class LocalTimeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;

    void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm:ss");
    }
}