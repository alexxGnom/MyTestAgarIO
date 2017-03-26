using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public class Food : BaseUnit
	{
		[SerializeField]
		private int weight;

		void Start()
		{
			this.Weight = weight;
		}

		public override void Die()
		{
			if (Creator != null)
				Creator.RemoveObject(this.gameObject);

			Destroy(this.gameObject);
		}


	}
}
