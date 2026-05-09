using UnityEngine;
using TMPro;

public class NodePanel : MonoBehaviour
{
    [Header("Node Content")]
    public string nodeTitle = "New Node";

    [TextArea(3, 5)]
    public string nodeBody = "Add note here.";

    [Header("Text References")]
    public TextMeshPro titleText;
    public TextMeshPro bodyText;

    [Header("Original Graph Transform")]
    public Vector3 graphPosition;
    public Quaternion graphRotation;
    public Vector3 graphScale;

    private void Awake()
    {
        AutoFindTextObjects();
        UpdateVisuals();
        SaveGraphTransform();
    }

    private void AutoFindTextObjects()
    {
        if (titleText == null)
        {
            Transform title = transform.Find("TitleText");
            if (title != null)
                titleText = title.GetComponent<TextMeshPro>();
        }

        if (bodyText == null)
        {
            Transform body = transform.Find("BodyText");
            if (body != null)
                bodyText = body.GetComponent<TextMeshPro>();
        }
    }

    public void UpdateVisuals()
    {
        if (titleText != null)
            titleText.text = nodeTitle;

        if (bodyText != null)
            bodyText.text = nodeBody;
    }

    public void SaveGraphTransform()
    {
        graphPosition = transform.position;
        graphRotation = transform.rotation;
        graphScale = transform.localScale;
    }

    public void RestoreGraphTransform()
    {
        transform.position = graphPosition;
        transform.rotation = graphRotation;
        transform.localScale = graphScale;
    }
}