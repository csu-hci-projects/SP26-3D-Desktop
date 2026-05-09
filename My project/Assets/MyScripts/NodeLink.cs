using UnityEngine;

public class NodeLink : MonoBehaviour
{
    public NodePanel nodeA;
    public NodePanel nodeB;

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (nodeA == null || nodeB == null)
        {
            Destroy(gameObject);
            return;
        }

        line.SetPosition(0, nodeA.transform.position);
        line.SetPosition(1, nodeB.transform.position);
    }
}