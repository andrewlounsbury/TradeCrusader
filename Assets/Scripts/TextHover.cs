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
    public Image panel;
    private Color changedColor;
    private string originalText;
    private float originalFontSize; 

    public string HoverText = "hovertext";
    public float HoverFontSize = 100f;
    public Color hoverColor = Color.white;

    void Start()
    {
        textMeshProText = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        panel = GetComponent<Image>();
        originalText = textMeshProText.text;
        originalFontSize = textMeshProText.fontSize;
        changedColor = panel.color;
    }

    private void OnMouseEnter()
    {
        textMeshProText.text = HoverText;
        textMeshProText.fontSize = HoverFontSize;
        panel.color = hoverColor;
    }

    private void OnMouseExit()
    {
        textMeshProText.text = originalText;
        textMeshProText.fontSize = originalFontSize;
        panel.color = changedColor;
    }

    private void OnMouseDown()
    {
        button.onClick.Invoke();
    }
}