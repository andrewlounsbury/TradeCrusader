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
    private Coroutine colorTransitionCoroutine;
    private bool isTransitioning;

    //public GameObject gameObject;
    public Image panel;
    public AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public string HoverText = "hovertext";
    public float HoverFontSize = 100f;
    public float delayBetweenTransitions = 0.2f;
    public Color originalColor = Color.white;
    public Color changedColor = Color.white;

    void Start()
    {
        textMeshProText = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        panel = panel.GetComponent<Image>();
        panel.color = originalColor;
        originalText = textMeshProText.text;
        originalFontSize = textMeshProText.fontSize;
        audioSource = GetComponent<AudioSource>(); 
    }

    public void OnMouseEnter()
    {
        textMeshProText.text = HoverText;
        textMeshProText.fontSize = HoverFontSize;

        if (colorTransitionCoroutine != null)
        {
            StopCoroutine(colorTransitionCoroutine);
        }

        colorTransitionCoroutine = StartCoroutine(ChangeColor(changedColor));
        audioSource.PlayOneShot(hoverSound);
    }

    public void OnMouseExit()
    {
        textMeshProText.text = originalText;
        textMeshProText.fontSize = originalFontSize;

        if (colorTransitionCoroutine != null)
        {
            StopCoroutine(colorTransitionCoroutine);
        }

        colorTransitionCoroutine = StartCoroutine(ChangeColor(originalColor));
    }

    private IEnumerator WaitAndStartNewTransition(Color target)
    {
        yield return new WaitForSeconds(delayBetweenTransitions);

        colorTransitionCoroutine = StartCoroutine(ChangeColor(target));
    }

    private IEnumerator ChangeColor(Color target)
    {
        float elapsedTime = 0f;
        Color startColor = panel.color;

        while (elapsedTime < 1f)
        {
            panel.color = Color.Lerp(startColor, target, elapsedTime);
            elapsedTime += Time.deltaTime * 2;
            yield return null;
        }

        panel.color = target;
    }

    /*private void Update()
    {
        changedColor = Color.Lerp(originalColor, changedColor, 0.5f);
    }

    private void OnMouseEnter()
    {
        textMeshProText.text = HoverText;
        textMeshProText.fontSize = HoverFontSize;
        panel.color = changedColor;
        audioSource.PlayOneShot(hoverSound);
    }

    private void OnMouseExit()
    {
        textMeshProText.text = originalText;
        textMeshProText.fontSize = originalFontSize;
        panel.color = originalColor;
    }*/

    private void OnMouseDown()
    {
        audioSource.PlayOneShot(clickSound);
        button.onClick.Invoke();
    }

}