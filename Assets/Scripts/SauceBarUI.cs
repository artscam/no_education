using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SauceBarUI : MonoBehaviour
{
    public float Sauce, MaxSauce, Width, Height;
    [SerializeField] private RectTransform sauceBar;

    public void SetMaxSauce(float maxSauce)
    {
        MaxSauce = maxSauce;
    }
    public void SetSauce(float sauce)
    {
        Sauce = sauce;
        float newWidth = (Sauce / MaxSauce) * Width;

        sauceBar.sizeDelta = new Vector2(newWidth, Height);
    }
}
