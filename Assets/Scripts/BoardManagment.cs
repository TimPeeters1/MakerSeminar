using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoardManagment : MonoBehaviour
{
	public static Action<bool> unlock1Event;

	[SerializeField] private Text virusCompletedText;
	private int maxCounter = 5;
	private int counter;
	
	private void Start()
	{
		virusCompletedText.text = counter + "/" + maxCounter;
	}

	private void Update()
	{
		if(counter >= 5)
		{
			if (unlock1Event != null)
			{
				unlock1Event(true);
			}
		}
	}

	private void CountUp(int _count)
	{
		counter = _count;
		virusCompletedText.text = counter + "/" + maxCounter;
	}

	private void OnEnable()
	{
		VirusDing.virusDeadEvent += CountUp;
	}

	private void OnDisable()
	{
		VirusDing.virusDeadEvent -= CountUp;
	}
}