using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] GameObject doorPosition;
    [SerializeField] GameObject doorText;

    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] mapPositions;

    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponentInChildren<LineRenderer>().SetPosition(0, buttons[i].GetComponentInChildren<LineRenderer>().transform.position);
            buttons[i].GetComponentInChildren<LineRenderer>().SetPosition(1, mapPositions[i].transform.position);

        }

        doorText.GetComponentInChildren<LineRenderer>().SetPosition(0, doorText.GetComponentInChildren<LineRenderer>().transform.position);
        doorText.GetComponentInChildren<LineRenderer>().SetPosition(1, doorPosition.transform.position);

        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }
}
