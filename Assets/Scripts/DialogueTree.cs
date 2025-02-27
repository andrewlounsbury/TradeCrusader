using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueTree : MonoBehaviour
{
    public DialogueNode root;
    public TMP_Text textBox;
    List<int> navigationList = new();
    public float textSpeed = 0.05f; // Adjust this value to change the speed of text display
    public KeyCode skipKey = KeyCode.Space; // Define the key to skip coroutine
    private Coroutine displayTextCoroutine;
    public List<DialogueButton> buttons;
    public Player player; 

    void Update()
    {
        // Check for input to skip text coroutine
        if (Input.GetKeyDown(skipKey))
        {
            SkipTextCoroutine();
        }
    }

    public void IndexAdder(int index)
    {
        navigationList.Add(index);
    }

    public void SetText()
    {
        if (displayTextCoroutine != null)
        {
            SkipTextCoroutine();
            return;
        }

        textBox.text = Search().dialogueList.GetNextString();

        if(textBox.text == "")
        {
            DialogueNode dialogueNode = Search();
            if (dialogueNode.HasGeneratedButtons()) return;

            for (int x = 0; x < dialogueNode.nodeList.Count; x++)
            {
                DialogueButton dialogueButton = null;
                if (x < buttons.Count)
                {
                    dialogueButton = buttons[x];
                }
                else
                {
                    Debug.Log("More Dialogue Options than Button Locations. Womp");
                    break;
                }

                //string str = Search().dialogueList.dialogue[x];
                dialogueButton.gameObject.SetActive(true);
                dialogueButton.SetDialogueTree(this);
                dialogueButton.SetDialogueIndex(x);
                dialogueButton.SetButtonName(dialogueNode.nodeList[x].ButtonName);
            }

            dialogueNode.SetHasGenerated();

            if(dialogueNode.nodeList.Count == 0)
            {
                DynamicPanelManager.Instance.ActiveBuySellPanel();
                ResetDialogue(); 
            }

            return;
        }
        
        DisplayTextOverTime(textBox.text); 
    }

    public void DisplayTextOverTime(string text)
    {
        if (displayTextCoroutine != null)
        {
            StopCoroutine(displayTextCoroutine);
            displayTextCoroutine = null;
        }

        displayTextCoroutine = StartCoroutine(DisplayTextCoroutine(text));
    }

    private IEnumerator DisplayTextCoroutine(string text)
    {
        textBox.text = ""; // Clear text box initially

        for (int i = 0; i < text.Length; i++)
        {
            textBox.text += text[i]; // Add one character at a time

            yield return new WaitForSeconds(textSpeed); // Wait for specified time
        }

        displayTextCoroutine = null;
    }

    public void SkipTextCoroutine()
    {
        if (displayTextCoroutine != null)
        {
            StopCoroutine(displayTextCoroutine);
            displayTextCoroutine = null; 
            textBox.text = Search().dialogueList.GetCurrentString(); // Instantly print the entire text
        }
    }

    public void ClearDialogueButtons()
    {
        foreach(DialogueButton button in buttons)
        {
            button.hasAddedDialogue = false;
            button.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame


    public void ResetDialogue()
    {
        root.SetAllHasntGenerated();
        navigationList.Clear();
    }
    public DialogueNode Search()
    {
        DialogueNode curNode = root;
        
        foreach (int index in navigationList)
        {
            curNode = curNode.nodeList[index];
        }

        return curNode;
    }
}

[Serializable]
public class DialogueNode
{
    public string ButtonName;
    public DialogueList dialogueList;
    public List<DialogueNode> nodeList;
    private bool hasGeneratedButtons = false;

    public DialogueNode(DialogueList dList)
    {
        dialogueList = dList;

        nodeList = new List<DialogueNode>();
    }
    public DialogueList GetDialogueList()
    {
        return dialogueList;
    }

    public void SetHasGenerated() => hasGeneratedButtons = true;
    public bool HasGeneratedButtons() => hasGeneratedButtons;

    public void SetAllHasntGenerated()
    {
        hasGeneratedButtons = false;
        dialogueList.Reset();
        foreach(DialogueNode child in nodeList)
        {
            if(child.hasGeneratedButtons)
                child.SetAllHasntGenerated();
        }
    }
}