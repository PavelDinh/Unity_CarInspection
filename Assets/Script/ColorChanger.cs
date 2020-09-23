using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    float r = 0;
    [SerializeField]
    float g = 0;
    [SerializeField]
    float b = 0;
    int a = 1;

    public Material colorMaterialRef = null;
    public Slider[] sliders;
    public List<Text> rGBValues;
    public Image ColorCircle = null;

    void Start()
    {
        Load();
        sliders[0].value = r;
        sliders[1].value = g;
        sliders[2].value = b;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (colorMaterialRef)
        {
            UpdateUI();
            r = sliders[0].value;
            g = sliders[1].value;
            b = sliders[2].value;
            Color color = new Color(r, g, b, a);
            colorMaterialRef.SetColor("_Color", color);
            if (ColorCircle)
            {
                ColorCircle.color = color;
            }
            Save();
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            rGBValues[i].text = (sliders[i].value * 255).ToString("F0");
        }
    }

    private void Load()
    {
        if (PlayerPrefs.HasKey("r") && PlayerPrefs.HasKey("g") && PlayerPrefs.HasKey("b"))
        {
            r = PlayerPrefs.GetFloat("r");
            g = PlayerPrefs.GetFloat("g");
            b = PlayerPrefs.GetFloat("b");
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("r", r);
        PlayerPrefs.SetFloat("g", g);
        PlayerPrefs.SetFloat("b", b);
        PlayerPrefs.Save();
    }
}
