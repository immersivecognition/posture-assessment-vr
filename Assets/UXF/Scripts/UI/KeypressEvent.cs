﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UXF
{
	/// <summary>
	/// Script to invoke a UnityEvent when a specified key is pressed
	/// </summary>
	public class KeypressEvent : MonoBehaviour 
	{
		public KeyCode eventKey = KeyCode.F1;		

		public UnityEvent onKeypress;

		void Update () 
		{
			if (Input.GetKeyDown(eventKey))
				onKeypress.Invoke();
		}
	}
}
