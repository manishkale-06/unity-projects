using System.Data.Common;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ActivateTeleportationRay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject leftTeleportation;
    public GameObject rightTeleportation;
    // Update is called once per frame
    public InputActionProperty leftActivate;
    public InputActionProperty rightActivate;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 && leftActivate.action.ReadValue<float>() > 0.1f);
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightPos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 && rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
