using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DoorLocks : MonoBehaviour
{
	public bool lock1, lock2, lock3;
	public Text lock1Text, lock2Text, lock3Text;

    private void Awake()
    {
		lock1 = false; //virus
		lock2 = false; //lijst
		lock3 = false; //speaker
    }

    private void Update()
    {
        if(lock1 == true)
		{
			lock1Text.color = Color.green;
			lock1Text.text = "Lock 1: Unlocked";
		}
    }

	private void UnlockDoor(bool _lock1)
	{
		lock1 = _lock1;
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