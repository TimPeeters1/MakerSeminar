﻿using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTransitions : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler, IPointerClickHandler
{
	public Color32 m_NormalColor = Color.white;
	public Color32 m_HoverColor = Color.white;
	public Color32 m_DownColor = Color.white;

	private Image m_Image = null;
	
	private void Awake()
	{
		m_Image = GetComponent<Image>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		m_Image.color = m_HoverColor;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		m_Image.color = m_DownColor;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		m_Image.color = m_HoverColor;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		m_Image.color = m_NormalColor;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("up");
	}
}