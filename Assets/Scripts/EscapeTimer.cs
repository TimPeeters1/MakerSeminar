using UnityEngine;
using UnityEngine.UI;

public class EscapeTimer : MonoBehaviour
{
	[SerializeField] private Text timer;

	[SerializeField] private float timeLeft = 600;

	private int min;

	private int sec;

	bool hasEnded;

	private void Start()
	{
		min = Mathf.FloorToInt(timeLeft / 60);

		sec = Mathf.FloorToInt(timeLeft % 60);

		timer.text = min.ToString("00" + ":" + sec.ToString("00"));
	}


	private void Update()
	{
		TimerUpdate();
	}

	private void TimerUpdate()
	{

		if (timeLeft < 0 && !hasEnded)
		{
			hasEnded = true;
			//DO IETS, LOCK DE DEUR OFZO
			GameManager.instance.failScreen.SetActive(true);
			GameManager.instance.GetComponent<AudioSource>().PlayOneShot(GameManager.instance.failSound);

		}
		else
		{
			min = Mathf.FloorToInt(timeLeft / 60);

			sec = Mathf.FloorToInt(timeLeft % 60);

			timer.text = min.ToString("00") + ":" + sec.ToString("00");

			timeLeft -= Time.deltaTime;
		}
	}
}