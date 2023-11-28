using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

[CreateAssetMenu(fileName = "New Resource", menuName = "Resource")]
public class Resource : ScriptableObject
{ 
    //variables 
    public new string name;
    public float weightPerUnit;
    public float buyRate;
    public float sellRate;
    public int amount; 
    public Sprite icon;
}
