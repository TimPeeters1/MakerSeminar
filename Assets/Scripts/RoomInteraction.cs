using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{

    [SerializeField] float speed;



    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] mapPositions;

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<LineRenderer>().SetPosition(0, buttons[i].GetComponentInChildren<LineRenderer>().transform.position);
            buttons[i].GetComponentInChildren<LineRenderer>().SetPosition(1, mapPositions[i].transform.position);

        }


        transform.RotateAround(transform.position, -transform.forward, Time.deltaTime * speed);
    }
}
