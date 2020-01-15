﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class ControllerTrackPad : MonoBehaviour
{
	public SteamVR_ActionSet set;
	public SteamVR_Input_Sources inputSource;
	public float scrollSpeed = 5f;

	public Image scrollImage;

	private void Start()
    {
		scrollImage = GetComponent<Image>();
    }

	private void Update()
    {
		if (SteamVR_Actions.default_TPDown.stateDown)
		{
			scrollImage.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPUp.stateDown)
		{
			scrollImage.transform.position += Vector3.up * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPLeft.stateDown)
		{
			scrollImage.transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
		}

		if (SteamVR_Actions.default_TPRight.stateDown)
		{
			scrollImage.transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
		}
	}
}