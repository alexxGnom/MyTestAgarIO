using UnityEngine;
using System.Collections;

namespace MyAgarIO
{
	public class Enemy : Unit
	{
		public override void Die()
		{
			if (Creator != null)
				Creator.RemoveObject(this.gameObject);

			Destroy(this.gameObject);
		}
	}
}
