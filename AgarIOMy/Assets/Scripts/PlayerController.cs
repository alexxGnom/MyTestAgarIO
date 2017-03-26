using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace MyAgarIO
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private Unit player;


		void Start()
		{
			Assert.IsFalse(target.GetType() is ITarget);
			player.Target = target.GetComponent<ITarget>();
		}

	}
}
