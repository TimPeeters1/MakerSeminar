using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusDing : MonoBehaviour
{
    public void Eliminate()
    {
        Debug.Log("Kaboem");
        Destroy(this.gameObject);
    }
}
