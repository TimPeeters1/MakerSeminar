﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;
using UnityEngine.EventSystems;

public class Pointer : MonoBehaviour
{
	[SerializeField] private float m_defaultLenght = 5.0f;
	[SerializeField] private GameObject m_dot;
	[SerializeField] private VR_InputModule m_inputModule;

	private LineRenderer m_lineRenderer = null;

	private void Awake()
    {
		m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
		UpdateLine();
    }

	private void UpdateLine()
	{
		PointerEventData data = m_inputModule.GetData();
		float _targetLength = data.pointerCurrentRaycast.distance == 0 ? m_defaultLenght : data.pointerCurrentRaycast.distance;
		RaycastHit _hit = CreateRaycast(_targetLength);
		Vector3 _endPosition = transform.position + (transform.position * _targetLength);
		if(_hit.collider != null)
		{
			_endPosition = _hit.point;
		}

		m_dot.transform.position = _endPosition;

		m_lineRenderer.SetPosition(0, transform.position);
		m_lineRenderer.SetPosition(1, _endPosition);
	}

	private RaycastHit CreateRaycast(float _length)
	{
		RaycastHit _hit;
		Ray _ray = new Ray(transform.position, transform.forward);
		Physics.Raycast(_ray, out _hit, m_defaultLenght);

		return _hit;
	}
}