using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public class Player : Unit
	{
		public override void Die()
		{
			this.Weight = startWeight;
			this.transform.position = Vector3.zero;
		}
	}
}
