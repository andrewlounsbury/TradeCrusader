using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class TextHover : MonoBehaviour
{
    private TextMeshProUGUI textMeshProText;
    private Button button;
    private Color textColor;
    private string originalText;
    private float originalFontSize; 

    public string HoverText = "hovertext";
    public float HoverFontSize = 100f;
    public Color hoverColor = Color.white;

    void Start()
    {
        textMeshProText = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        originalText = textMeshProText.text;
        originalFontSize = textMeshProText.fontSize;
        textColor = textMeshProText.color;
    }

    private void OnMouseEnter()
    {
        textMeshProText.text = HoverText;
        textMeshProText.fontSize = HoverFontSize;
        textMeshProText.color = hoverColor;
    }

    private void OnMouseExit()
    {
        textMeshProText.text = originalText;
        textMeshProText.fontSize = originalFontSize;
        textMeshProText.color = textColor;
    }

    private void OnMouseDown()
    {
        button.onClick.Invoke();
    }
}