using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class ControllerPointer : MonoBehaviour
{
    public SteamVR_ActionSet set;
    public SteamVR_Action_Boolean trigger;

    public SteamVR_Input_Sources inputSource;

    private LineRenderer m_lineRenderer = null;
    // Update is called once per frame

    public RaycastHit hit;

    private void Awake()
    {
        set.Activate(SteamVR_Input_Sources.Any, 0, true);
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 1000f, Color.red);
        Physics.Raycast(transform.position, transform.forward * 1000f, out hit);
    
        if (trigger.stateDown)
        {
            if(hit.collider.GetComponent<VR_Button>())
                hit.collider.GetComponent<VR_Button>().TriggerButton();

            if (hit.collider.GetComponent<VirusDing>())
                hit.collider.GetComponent<VirusDing>().Eliminate();

        }

        m_lineRenderer.SetPosition(0, transform.position);

        if (hit.collider != null)
        {
            m_lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            m_lineRenderer.SetPosition(1, transform.forward * 1000f);
        }

       

    }
}
