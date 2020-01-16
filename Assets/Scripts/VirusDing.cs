using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VirusDing : MonoBehaviour
{
	public static Action<int> virusDeadEvent;
    public AudioClip clip;

    public void Eliminate()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);

		if(virusDeadEvent != null)
		{
			virusDeadEvent(1);
            Debug.Log("event");
		}
        Destroy(this.gameObject);
    }
}