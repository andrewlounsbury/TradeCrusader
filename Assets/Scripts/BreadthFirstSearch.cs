using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadthFirstSearch : MonoBehaviour
{
    public Dictionary<Node, Node> PathChart = new();

    public void BFS(Node startTransform)
    {
        if (PathChart == null)
        {
            return;
        }

        PathChart.Clear();

        Node currentNode = startTransform;

        Queue<Node> frontier = new Queue<Node>();

        frontier.Enqueue(currentNode);

        PathChart.Add(currentNode, null);

        while (frontier.Count > 0)
        {
            currentNode = frontier.Dequeue();

            foreach (Node child in currentNode.Neighbors)
            {
                if (PathChart.ContainsKey(child))
                {
                    continue;
                }

                frontier.Enqueue(child);
                PathChart.Add(child, currentNode);
            }
        }
    }

}

//belike hey whats the currwnrt node im at 
//which node did you come from to get to the goal 
//set is moving bool and in Update if moving = true, run while loop 
//while(currentNode != goalNode)
// {
//      currentNode = pathMap[currentNode] 

//      while (transform.position != currentNode.position) 
           //transform.position += (currentNode position - transform.position).normalized * moveSpeed * Time.DeltaTime
           //
//}

//gotten by getting the path chart and feeding in players currrent node 
//new script on player 
// 