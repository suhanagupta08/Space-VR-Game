using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;
public class CheckTrigger : MonoBehaviour
{
    private SteamVR_Action_Boolean m_TriggerAction;
    private SteamVR_Input_Sources m_InputSource = SteamVR_Input_Sources.Any;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        m_TriggerAction = SteamVR_Actions._default.GrabPinch;
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void Update()
    {
        if (m_TriggerAction[m_InputSource].stateDown)
        {
            Debug.Log("Trigger Button Pressed");
            grabInteractable.activated.Invoke(new ActivateEventArgs());
        }
    }
}
