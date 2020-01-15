﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DoorLocks : MonoBehaviour
{
	GameManager mgr;

	public Text lock1Text, lock2Text, lock3Text;

    private void Awake()
    {
		mgr = GameManager.instance;
		mgr.lock1 = false; //virus
		mgr.lock2 = false; //lijst
		mgr.lock3 = false; //speaker
    }

    private void Update()
    {
        if(mgr.lock1 == true)
		{
			lock1Text.color = Color.green;
			lock1Text.text = ">Lock 1: Unlocked";
		}
    }

	private void UnlockDoor(bool _lock1)
	{
		mgr.lock1 = _lock1;
	}

	private void OnEnable()
	{
		BoardManagment.unlock1Event += UnlockDoor;
	}

	private void OnDisable()
	{
		BoardManagment.unlock1Event -= UnlockDoor;
	}
}