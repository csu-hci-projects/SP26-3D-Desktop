using System.Collections.Generic;
using UnityEngine;

public class LinkManager : MonoBehaviour
{
    [Header("Link Visuals")]
    public Material linkMaterial;
    public float linkWidth = 0.02f;

    private bool linkMode = false;
    private NodePanel firstNode = null;

    private List<NodeLink> links = new List<NodeLink>();

    public void StartLinkMode()
    {
        linkMode = true;
        firstNode = null;
        Debug.Log("Link mode started. Select first node.");
    }

    public void SelectNode(NodePanel node)
    {
        if (!linkMode || node == null)
            return;

        if (firstNode == null)
        {
            firstNode = node;
            Debug.Log("First node selected: " + node.name);
            return;
        }

        if (firstNode == node)
        {
            Debug.Log("Cannot link node to itself.");
            return;
        }

        CreateLink(firstNode, node);

        linkMode = false;
        firstNode = null;

        Debug.Log("Link created.");
    }

    private void CreateLink(NodePanel a, NodePanel b)
    {
        GameObject linkObj = new GameObject("NodeLink");

        LineRenderer line = linkObj.AddComponent<LineRenderer>();
        line.positionCount = 2;
        line.startWidth = linkWidth;
        line.endWidth = linkWidth;
        line.useWorldSpace = true;

        if (linkMaterial != null)
            line.material = linkMaterial;

        NodeLink link = linkObj.AddComponent<NodeLink>();
        link.nodeA = a;
        link.nodeB = b;

        links.Add(link);
    }

    public List<NodePanel> GetLinkedNodes(NodePanel node)
    {
        List<NodePanel> neighbors = new List<NodePanel>();

        foreach (NodeLink link in links)
        {
            if (link == null || link.nodeA == null || link.nodeB == null)
                continue;

            if (link.nodeA == node)
                neighbors.Add(link.nodeB);
            else if (link.nodeB == node)
                neighbors.Add(link.nodeA);
        }

        return neighbors;
    }
}