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

    [SerializeField] private PlayerPurse playerPurse;
    [SerializeField] private PlayerCargo cargo;

    [SerializeField] private float moveSpeed = 3;

    private void Start()
    {
        transform.position = currentNode.transform.position;
    }

    private void Update()
    {
       MoveToTarget();
    }

    public PlayerPurse GetPlayerPurse() => playerPurse;
    public PlayerCargo GetPlayerCargo() => cargo;

    public void SetTargetNode(Node target)
    {
        if (isMoving)
        {
            return; 
        }

        if (targetNode != target)
        {
            isMoving = true; 
        }

        targetNode = target; 
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
        if (Vector3.Distance(transform.position, currentNode.transform.position) <= 0.01f)
        {
            currentNode = BFS.PathChart[currentNode];
        }

        // Move
        transform.position = Vector3.MoveTowards(transform.position, currentNode.transform.position, moveSpeed * Time.deltaTime); 
        
        // Check if you've hit your goal
        if (Vector3.Distance(transform.position, targetNode.transform.position) <= 0.01f)
        {
            isMoving = false;
            BFS.PathChart.Clear();
        }

    }

    //handle clicking of node in its own function here
    //whwenever node is clickeed, do BFS.BFS

}
