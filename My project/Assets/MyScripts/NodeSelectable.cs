using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class NodeSelectable : MonoBehaviour
{
    public LinkManager linkManager;
    public FocusViewManager focusViewManager;

    private NodePanel nodePanel;
    private XRBaseInteractable interactable;

    private void Awake()
    {
        nodePanel = GetComponent<NodePanel>();
        interactable = GetComponent<XRBaseInteractable>();
    }

    private void OnEnable()
    {
        if (interactable != null)
            interactable.selectEntered.AddListener(OnSelected);
    }

    private void OnDisable()
    {
        if (interactable != null)
            interactable.selectEntered.RemoveListener(OnSelected);
    }

    private void OnSelected(SelectEnterEventArgs args)
    {
        if (nodePanel == null)
            return;

        nodePanel.SaveGraphTransform();

        if (linkManager != null)
            linkManager.SelectNode(nodePanel);

        if (focusViewManager != null)
            focusViewManager.SelectNodeForFocus(nodePanel);
    }
}