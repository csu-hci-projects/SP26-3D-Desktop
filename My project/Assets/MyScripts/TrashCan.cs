using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        NodePanel node = other.GetComponentInParent<NodePanel>();

        if (node != null)
        {
            Debug.Log("Deleted node: " + node.name);
            Destroy(node.gameObject);
        }
    }
}