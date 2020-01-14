using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RGBGame : MonoBehaviour
{
    [SerializeField] bool isImage;

    [SerializeField] private Text textComponent;

    [SerializeField] private Image imageComponent;

    [SerializeField] private Vector2 red;

    [SerializeField] private Vector2 blue;
    
    [SerializeField] private Vector2 green;

    [SerializeField] private Vector2 alpha;

    [SerializeField] private Transform origin;
    private Renderer ren;

    private void Start()
    {
        ren = GetComponent<Renderer>();
    }

    private void Update()
    {

        red.x = Mathf.Abs((origin.transform.position - transform.position).x) / red.y;

        green.x = Mathf.Abs((origin.transform.position - transform.position).y) / green.y;

        blue.x = Mathf.Abs((origin.transform.position - transform.position).z) / blue.y;

        alpha.x = Vector3.Distance(origin.transform.position, transform.position) / alpha.y;

        if (isImage)
        {
            imageComponent.color = new Color(Mathf.Clamp(red.x, 0, 1), Mathf.Clamp(green.x, 0, 1), Mathf.Clamp(blue.x, 0, 1));
        }
        else
        {
            

            textComponent.color  = new Color(Mathf.Clamp(red.x, 0, 1), Mathf.Clamp(green.x, 0, 1), Mathf.Clamp(blue.x, 0, 1), Mathf.Clamp(alpha.x, 0, 1));
        }


    }
}
