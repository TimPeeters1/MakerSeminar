using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CodeLocksTransition : MonoBehaviour
{
	public static Action<bool> unlock2Event;

	private int keyCode1, keyCode2, keyCode3;
	[SerializeField] private int key1, key2, key3;

	[SerializeField] private Text counterText1, counterText2, counterText3;
	[SerializeField] private Text finishedText;
	[SerializeField] private Image background;


	[SerializeField] int lockNumber;
	private void Start()
	{
		finishedText.enabled = false;
		background.enabled = false;
	}

	private void Update()
	{
		keyCode1 = int.Parse(counterText1.text);
		keyCode2 = int.Parse(counterText2.text);
		keyCode3 = int.Parse(counterText3.text);

		if (keyCode1 == key1 && keyCode2 == key2 && keyCode3 == key3)
		{
			counterText1.color = Color.green;
			counterText2.color = Color.green;
			counterText3.color = Color.green;

			StartCoroutine(OtherStuff());

			if (lockNumber == 1)
			{
				GameManager.instance.lock1 = true;
			}
			if (lockNumber == 2)
			{
				GameManager.instance.lock2 = true;
			}
			if(lockNumber == 3)
			{
				GameManager.instance.lock3 = true;
			}
		}
	}

	private IEnumerator OtherStuff()
	{
		yield return new WaitForSeconds(1);
		finishedText.enabled = true;
		background.enabled = true;

		yield return new WaitForSeconds(3);
		SceneManager.LoadScene(1);
	}
}