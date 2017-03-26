using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public class MouseObserver : MonoBehaviour, ITarget
	{
		[SerializeField]
		private Vector2 maxRange;

		public Vector3 GetTargetPointForObject(GameObject obj)
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			return Utils.BoundingVector(pos, maxRange);
		}
	}
}