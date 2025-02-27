using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class DialogueButton : MonoBehaviour
{
    private int dialogueIndex;
    private DialogueTree dialogueTree;
    [HideInInspector]public bool hasAddedDialogue = false;
    public TMP_Text tBox; 

    public void SetDialogueIndex(int index) => dialogueIndex = index;
    public void SetDialogueTree(DialogueTree tree) => dialogueTree = tree;
    public void SetButtonName(string buttonName) => tBox.text = buttonName;

    public void AddDialogueIndex()
    {
        if (hasAddedDialogue) return;

        dialogueTree.IndexAdder(dialogueIndex);
        hasAddedDialogue = true;
        dialogueTree.SetText();

        dialogueTree.ClearDialogueButtons();
    }
}
