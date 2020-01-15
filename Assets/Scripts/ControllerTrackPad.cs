using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class ControllerTrackPad : MonoBehaviour
{
	public SteamVR_ActionSet set;
	public SteamVR_Input_Sources inputSource;
	public float scrollSpeed = 5f;
	public float maxY, minY, maxX, minX;
	public Image scrollImage;

	private float scrollImageX;
	private float scrollImageY;

	private void Start()
    {
		scrollImage = GetComponent<Image>();
		scrollImageX = scrollImage.transform.position.x;
		scrollImageY = scrollImage.transform.position.y;
	}

	private void Update()
    {
		if (SteamVR_Actions.default_TPDown.state)
		{
			scrollImageY = Mathf.Clamp(scrollImageY, minY, maxY);
			scrollImage.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPUp.state)
		{
			scrollImageY = Mathf.Clamp(scrollImageY, minY, maxY);
			scrollImage.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPLeft.state)
		{ 
			scrollImageX = Mathf.Clamp(scrollImageX, minX, maxX);
			scrollImage.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPRight.state)
		{
			scrollImageX = Mathf.Clamp(scrollImageX, minX, maxX);
			scrollImage.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
		}
	}
}