using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FocusViewManager : MonoBehaviour
{
    [Header("References")]
    public Transform xrCamera;
    public LinkManager linkManager;

    [Header("Joystick Input")]
    public InputActionReference leftJoystickAction;

    [Header("Focus View Settings")]
    public float focusDistance = 2.0f;
    public Vector3 focusedScale = new Vector3(1.8f, 1.8f, 1.8f);
    public float verticalOffset = 0.0f;
    public float joystickThreshold = 0.65f;
    public float navigationCooldown = 0.35f;

    private bool waitingForNodeSelection = false;
    private bool focusViewActive = false;

    private NodePanel currentFocusedNode;
    private float lastNavigationTime = -999f;

    private void OnEnable()
    {
        if (leftJoystickAction != null)
            leftJoystickAction.action.Enable();
    }

    private void OnDisable()
    {
        if (leftJoystickAction != null)
            leftJoystickAction.action.Disable();
    }

    private void LateUpdate()
    {
        if (!focusViewActive || currentFocusedNode == null)
            return;

        KeepFocusedNodeInView();
        HandleJoystickNavigation();
    }

    public void EnterFocusView()
    {
        waitingForNodeSelection = true;
        focusViewActive = false;
        Debug.Log("Focus View: select a node.");
    }

    public void ExitFocusView()
    {
        RestoreCurrentNode();

        currentFocusedNode = null;
        waitingForNodeSelection = false;
        focusViewActive = false;

        Debug.Log("Exited Focus View.");
    }

    public void SelectNodeForFocus(NodePanel node)
    {
        if (!waitingForNodeSelection || node == null)
            return;

        FocusNode(node);

        waitingForNodeSelection = false;
        focusViewActive = true;
    }

    private void FocusNode(NodePanel node)
    {
        RestoreCurrentNode();

        currentFocusedNode = node;
        MoveNodeToFocusPosition(currentFocusedNode);

        Debug.Log("Focused node: " + node.name);
    }

    private void RestoreCurrentNode()
    {
        if (currentFocusedNode == null)
            return;

        currentFocusedNode.transform.SetParent(null);
        currentFocusedNode.RestoreGraphTransform();
    }

    private void KeepFocusedNodeInView()
    {
        MoveNodeToFocusPosition(currentFocusedNode);
    }

    private void MoveNodeToFocusPosition(NodePanel node)
    {
        if (xrCamera == null || node == null)
            return;

        node.transform.SetParent(null);

        Vector3 targetPosition =
            xrCamera.position +
            xrCamera.forward * focusDistance +
            xrCamera.up * verticalOffset;

        node.transform.position = targetPosition;

        node.transform.rotation = Quaternion.LookRotation(
            node.transform.position - xrCamera.position,
            Vector3.up
        );

        node.transform.localScale = focusedScale;
    }

    private void HandleJoystickNavigation()
    {
        if (Time.time - lastNavigationTime < navigationCooldown)
            return;

        if (leftJoystickAction == null)
            return;

        Vector2 joystick = leftJoystickAction.action.ReadValue<Vector2>();

        if (joystick.magnitude < joystickThreshold)
            return;

        NodePanel nextNode = GetBestNeighborFromJoystick(joystick);

        if (nextNode != null)
        {
            FocusNode(nextNode);
            lastNavigationTime = Time.time;
        }
    }

    private NodePanel GetBestNeighborFromJoystick(Vector2 joystick)
    {
        if (currentFocusedNode == null || linkManager == null)
            return null;

        List<NodePanel> neighbors = linkManager.GetLinkedNodes(currentFocusedNode);

        if (neighbors.Count == 0)
            return null;

        if (neighbors.Count == 1)
            return neighbors[0];

        Vector2 joystickDir = joystick.normalized;

        NodePanel bestNode = null;
        float bestDot = -999f;

        foreach (NodePanel neighbor in neighbors)
        {
            if (neighbor == null)
                continue;

            Vector3 graphDirection3D =
                neighbor.graphPosition - currentFocusedNode.graphPosition;

            Vector2 graphDirection2D =
                new Vector2(graphDirection3D.x, graphDirection3D.z).normalized;

            float dot = Vector2.Dot(joystickDir, graphDirection2D);

            if (dot > bestDot)
            {
                bestDot = dot;
                bestNode = neighbor;
            }
        }

        return bestNode;
    }
}