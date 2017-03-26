using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

namespace MyAgarIO
{
	public class EnemyController : ObjectGenerator
	{

		[SerializeField]
		private Vector2 generatePositionsRange;

		[SerializeField]
		private GameObject target;

		protected void Start()
		{
			base.Start();
			Assert.IsFalse(target.GetType() is ITarget);
		}


		protected override void SetObjToStartPos(GameObject obj)
		{
			obj.transform.position = Utils.GenerateRandomPos(generatePositionsRange);
		}

		protected override void OnCreateCallback(GameObject obj)
		{
			obj.GetComponent<IDied>().SetCreator(this);
			obj.GetComponent<Enemy>().Target = target.GetComponent<ITarget>();
		}
	}
}
