using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public List<Node> Neighbors = new();

    private void OnDrawGizmos()
    {
        foreach (var neighbor in Neighbors)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, neighbor.transform.position);


        }
    }
}
