using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

[Serializable]
public class DialogueList
{
    public List<string> dialogue;
    private int index = 0; 

    public string GetNextString()
    {
        index++;

        if (index > dialogue.Count)
        {
            index--;
            return "";
        }

        return dialogue[index - 1];
    }

    public void Reset() => index = 0;
    public string GetCurrentString() => dialogue[index - 1];
}
