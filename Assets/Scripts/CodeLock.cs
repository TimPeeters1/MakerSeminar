using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeLock : MonoBehaviour
{
	[SerializeField] private Text counterText;
	private int counter;

	private void Start()
	{
		counter = 0;
		counterText.text = counter.ToString();
	}

	public void Activate()
	{
		counter++;
		if(counter > 9)
		{
			counter = 0;
		}
		counterText.text = counter.ToString();
	}
}