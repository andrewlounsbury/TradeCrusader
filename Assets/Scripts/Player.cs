using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Node currentNode;
    [SerializeField] private Node targetNode;

    [SerializeField] private BreadthFirstSearch BFS;
    private bool isMoving = false;

    private void Start()
    {
        transform.position = currentNode.transform.position;
    }

    private void Update()
    {
       MoveToTarget();
    }

    private void MoveToTarget()
    {
        // Return if not moving
        if (!isMoving) return;

        // Create chart if needed
        if (BFS.PathChart.Count == 0 && targetNode)
        {
            BFS.BFS(targetNode);
        }

        // Check if you need to set next node
        if (transform.position == currentNode.transform.position)
        {
            currentNode = BFS.PathChart[currentNode];
        }

        // Move
        transform.position += (currentNode.transform.position - transform.position).normalized * Time.deltaTime;
        
        // Check if you've hit your goal
        if (transform.position == targetNode.transform.position)
        {
            isMoving = false;
            BFS.PathChart.Clear();
        }

    }

    //handle clicking of node in its own function here
    //whwenever node is clickeed, do BFS.BFS

}
