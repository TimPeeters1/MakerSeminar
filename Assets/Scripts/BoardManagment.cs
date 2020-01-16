using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class BoardManagment : MonoBehaviour
{
    public static Action<bool> unlock1Event;

    [SerializeField] private Text virusCompletedText;
    private int maxCounter = 5;
    private int counter;

    [SerializeField] private Text finishedText;
    [SerializeField] private Image background;


    private void Start()
    {
        virusCompletedText.text = counter + "/" + maxCounter;
        finishedText.enabled = false;
        background.enabled = false;
    }

    private void Update()
    {
        if (counter >= 5)
        {
            StartCoroutine(OtherStuff());

            GameManager.instance.lock1 = true;
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

    private void CountUp(int _count)
    {
        counter += _count;
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