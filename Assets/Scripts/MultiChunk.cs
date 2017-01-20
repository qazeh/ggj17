﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MultiChunk : MonoBehaviour {

	[SerializeField] GameObject[] m_foodParts;

	int m_eaten = 0;
	bool m_eatingBackwards = false;
	bool m_isGrabbed = false;
	Rigidbody2D m_body;

	void Start() {
		m_body = GetComponent<Rigidbody2D>();
	}

	// returns true when done eating
	public Vector2 Eat() {
		if(m_eaten < m_foodParts.Length - 1) {
			int index = m_eatingBackwards ? m_foodParts.Length - m_eaten - 1 : m_eaten;
			m_foodParts[index].SetActive(false);
			m_eaten++;
			return m_foodParts[index].transform.position;
		} else {
			return Vector2.zero;
		}
	}

	public Rigidbody2D Grabbed(bool backwards) {
		if(!m_isGrabbed) {
			m_eatingBackwards = backwards;
			m_isGrabbed = true;
			return m_body;
		}
		return null;
	}

}
