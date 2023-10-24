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
       if (!isMoving)
        {
            isMoving = true;

            BFS.BFS(targetNode);

            while (currentNode != targetNode)
            {
                currentNode = BFS.PathChart[currentNode];

                while (transform.position != currentNode.transform.position)
                {
                    transform.position += (currentNode.transform.position - transform.position).normalized * 10f * Time.deltaTime;
                }
            }
        }
    }

    //handle clicking of node in its own function here
    //whwenever node is clickeed, do BFS.BFS

}
