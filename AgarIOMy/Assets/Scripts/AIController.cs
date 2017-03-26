using UnityEngine;
using System.Collections;
using System;

namespace MyAgarIO
{
	public class AIController : MonoBehaviour, ITarget
	{
		[SerializeField]
		private float enemyFindRadius;

		[SerializeField]
		private float foodFindRadius;

		[SerializeField]
		private Vector2 randomFindRadius;


		public Vector3 GetTargetPointForObject(GameObject obj)
		{
			Unit thisUnit = obj.GetComponent<Unit>();

			Vector3 targetPos = thisUnit.GetCurrentTargetPos();
			if (!FindEnemyForUnit(thisUnit, ref targetPos))
			{
				if (!FindFoodForUnit(thisUnit, ref targetPos))
				{
					if ((obj.transform.position - targetPos).magnitude < 0.1)
					{
						targetPos = Utils.GenerateRandomPos(randomFindRadius);
					}
				}
			}

			return Utils.BoundingVector(targetPos, randomFindRadius); ;
		}


		private bool FindEnemyForUnit(BaseUnit thisUnit, ref Vector3 targetPos)
		{
			var coliders = Physics.OverlapSphere(thisUnit.transform.position, enemyFindRadius);


			ArrayList targets = new ArrayList();

			foreach (Collider col in coliders)
			{
				if (col.gameObject != thisUnit)
				{
					BaseUnit enemyUnit = col.gameObject.GetComponent<BaseUnit>();
					if ((enemyUnit != null) && (enemyUnit.Weight > thisUnit.Weight))
					{
						Vector3 thPos = thisUnit.transform.position;
						Vector3 enPos = col.gameObject.transform.position;

						targetPos = new Vector3((2 * thPos.x - enPos.x), (2 * thPos.y - enPos.y), 0.0f);
						return true;
					}
				}
			}
			return false;
		}

		private bool FindFoodForUnit(BaseUnit thisUnit, ref Vector3 targetPos)
		{
			var coliders = Physics.OverlapSphere(thisUnit.transform.position, foodFindRadius);

			ArrayList targets = new ArrayList();

			GameObject tempTarget = null;
			uint tempWeight = 0;

			foreach (Collider col in coliders)
			{
				if (col.gameObject != thisUnit)
				{
					BaseUnit foodUnit = col.gameObject.GetComponent<BaseUnit>();
					if ((foodUnit != null) && (foodUnit.Weight < thisUnit.Weight) && (foodUnit.Weight > tempWeight))
					{
						tempTarget = col.gameObject;
					}
				}
			}

			if (tempTarget != null)
			{
				targetPos = tempTarget.transform.position;
				return true;
			}

			return false;
		}
	}
}
