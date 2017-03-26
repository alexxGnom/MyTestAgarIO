using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public abstract class BaseUnit : MonoBehaviour, IDied
	{

		public int Weight
		{
			get; protected set;
		}

		protected ObjectGenerator Creator { get; private set; }

		public void SetToPoint(Vector3 point)
		{
			this.transform.position = point;
		}


		public abstract void Die();

		public void SetCreator(ObjectGenerator creator)
		{
			this.Creator = creator;
		}
	}
}
