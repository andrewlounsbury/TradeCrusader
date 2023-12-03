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
    private string originalText;
    private float originalFontSize;

    public GameObject gameObject;
    public Image panel;
    public string HoverText = "hovertext";
    public float HoverFontSize = 100f;
    public Color originalColor = Color.white;
    public Color changedColor = Color.white;

    void Start()
    {
        textMeshProText = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        panel = gameObject.GetComponent<Image>();
        panel.color = originalColor;
        originalText = textMeshProText.text;
        originalFontSize = textMeshProText.fontSize;
    }

    private void OnMouseEnter()
    {
        textMeshProText.text = HoverText;
        textMeshProText.fontSize = HoverFontSize;
        panel.color = changedColor;
    }

    private void OnMouseExit()
    {
        textMeshProText.text = originalText;
        textMeshProText.fontSize = originalFontSize;
        panel.color = originalColor;
    }

    private void OnMouseDown()
    {
        button.onClick.Invoke();
    }

}