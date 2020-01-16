using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerTrackPad : MonoBehaviour
{
	public SteamVR_ActionSet set;
	public SteamVR_Input_Sources inputSource;
	public float scrollSpeed = 5f;
	[SerializeField] private GameObject VRControllerImage;

	public float maxY, minY, maxX, minX;

	public GameObject scrollImage;

	private void Start()
    {
		VRControllerImage.SetActive(true);
	}

	private void Update()
    {
		Vector3 newTrans;
		newTrans = scrollImage.transform.position;

		if (SteamVR_Actions.default_TPDown.state)
		{
			newTrans += -transform.forward * scrollSpeed * Time.deltaTime;
			if(VRControllerImage.activeInHierarchy == true)
			{
				VRControllerImage.SetActive(false);
			}
		}

		if (SteamVR_Actions.default_TPUp.state)
		{
			newTrans += transform.forward * scrollSpeed * Time.deltaTime;
			if (VRControllerImage.activeInHierarchy == true)
			{
				VRControllerImage.SetActive(false);
			}
		}

		if (SteamVR_Actions.default_TPLeft.state)
		{
			newTrans += -transform.right * scrollSpeed * Time.deltaTime;
			if (VRControllerImage.activeInHierarchy == true)
			{
				VRControllerImage.SetActive(false);
			}
		}

		if (SteamVR_Actions.default_TPRight.state )
		{
			newTrans += transform.right * scrollSpeed * Time.deltaTime;
			if (VRControllerImage.activeInHierarchy == true)
			{
				VRControllerImage.SetActive(false);
			}
		}

		newTrans.x = Mathf.Clamp(newTrans.x, minX, maxX);
		newTrans.y = Mathf.Clamp(newTrans.y, minY, maxY);

		scrollImage.transform.position = newTrans;
	}
}