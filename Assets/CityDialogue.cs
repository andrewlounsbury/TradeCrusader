using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityDialogue : MonoBehaviour
{
    public DialogueTree currentDialogueTree;
    [SerializeField] TMP_Text displayText;

    public void SetText()
    {

        currentDialogueTree.SetText();

    }

    public void SetDialogueTree(DialogueTree tree)
    {
        currentDialogueTree = tree;
        currentDialogueTree.textBox = displayText; 
    }

}
