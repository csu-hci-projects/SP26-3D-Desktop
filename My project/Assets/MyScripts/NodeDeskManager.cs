using UnityEngine;

public class NodeDeskManager : MonoBehaviour
{
    [Header("References")]
    public GameObject nodePrefab;
    public Transform xrCamera;
    public LinkManager linkManager;
    public FocusViewManager focusViewManager;

    [Header("Node Colors")]
    public float minHue = 0f;
    public float maxHue = 1f;
    public float saturation = 0.65f;
    public float value = 0.35f; // lower = darker, better for white text

    private int nodeCount = 1;

    public void CreateNode()
    {
        if (nodePrefab == null || xrCamera == null)
        {
            Debug.LogWarning("NodeDeskManager is missing nodePrefab or xrCamera.");
            return;
        }

        Vector3 spawnPos = xrCamera.position + xrCamera.forward * 2f;
        spawnPos.y = xrCamera.position.y;

        Quaternion spawnRot = Quaternion.LookRotation(spawnPos - xrCamera.position);
        spawnRot.x = 0f;
        spawnRot.z = 0f;

        GameObject obj = Instantiate(nodePrefab, spawnPos, spawnRot);

        NodePanel panel = obj.GetComponent<NodePanel>();
        if (panel != null)
        {
            panel.nodeTitle = "New Node " + nodeCount;
            panel.nodeBody = "Add note here.";
            panel.UpdateVisuals();
            panel.SaveGraphTransform();
        }

        ApplyRandomDarkColor(obj);

        NodeSelectable selectable = obj.GetComponent<NodeSelectable>();
        if (selectable != null)
        {
            selectable.linkManager = linkManager;
            selectable.focusViewManager = focusViewManager;
        }

        nodeCount++;
    }

    private void ApplyRandomDarkColor(GameObject nodeObj)
    {
        Color randomDarkColor = Random.ColorHSV(
            minHue,
            maxHue,
            saturation,
            saturation,
            value,
            value
        );

        Renderer[] renderers = nodeObj.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            // Avoid coloring TextMeshPro renderers
            if (renderer.GetComponent<TMPro.TextMeshPro>() != null)
                continue;

            renderer.material.color = randomDarkColor;
        }
    }
}