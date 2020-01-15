using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VR_Button : MonoBehaviour
{
    [SerializeField]private int sceneIndex;

    private Image image;
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.white;

    private ControllerPointer pointer;

    private void Awake()
    {
        pointer = FindObjectOfType<ControllerPointer>();
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if(pointer.hit.collider == this.gameObject.GetComponent<Collider>())
        {
            image.color = m_HoverColor;
        }
        else if(image.color != m_NormalColor)
        {
            Debug.Log("Reset");
            image.color = m_NormalColor;
        }
    }

    public void TriggerButton()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}