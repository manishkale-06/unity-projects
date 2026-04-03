using System.Xml.Serialization;
using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[System.Serializable]
public class Haptic
{
    [Range(0,1)]
    public float intensity;
    public float duration;
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs)
    {
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    // Update is called once per frame
    public void TriggerHaptic(XRBaseController controller)
    {
        if(intensity > 0)
        {
            controller.SendHapticImpulse(intensity,duration);
        }
    }
}
public class HapticFeedback : MonoBehaviour
{
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExited;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(hapticHoverEntered.TriggerHaptic);
        interactable.hoverExited.AddListener(hapticHoverExited.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticSelectEntered.TriggerHaptic);
        interactable.selectExited.AddListener(hapticSelectExited.TriggerHaptic);
        
    }

    
}
