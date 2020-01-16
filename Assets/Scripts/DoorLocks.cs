using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DoorLocks : MonoBehaviour
{
	GameManager mgr;

	public Text lock1Text, lock2Text, lock3Text, doorText;

	bool hasUnlocked;
			
	public GameObject doorObject;
	public GameObject endScreen;

	private void Awake()
    {
		endScreen.SetActive(false);

		mgr = GameManager.instance;
    }

    private void Update()
    {
        if(mgr.lock1 == true)
		{
			lock1Text.color = Color.green;
			lock1Text.text = ">Lock 1: Unlocked";
		}
		if (mgr.lock2 == true)
		{
			lock2Text.color = Color.green;
			lock2Text.text = ">Lock 2: Unlocked";
		}
		if (mgr.lock3 == true)
		{
			lock3Text.color = Color.green;
			lock3Text.text = ">Lock 3: Unlocked";
		}

		if(mgr.lock1 && mgr.lock2 && mgr.lock3 && !hasUnlocked)
		{
			hasUnlocked = true;
			UnlockDoor();
		}
	}

	private void UnlockDoor()
	{
		doorText.color = Color.green;
		doorText.text = ">Door Status: UNLOCKED";
		mgr.doorLock = true;
		endScreen.SetActive(true);
		//GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.winSound);

		doorObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
	}

}