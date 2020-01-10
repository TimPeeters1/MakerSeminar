using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInteraction : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] LineRenderer rend;

    private void Update()
    {
        float _rotation = transform.eulerAngles.y + speed;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _rotation, transform.eulerAngles.z);
    }
}
