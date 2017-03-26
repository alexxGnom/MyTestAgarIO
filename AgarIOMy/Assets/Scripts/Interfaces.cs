using UnityEngine;

namespace MyAgarIO
{

	public interface ITarget
	{
		Vector3 GetTargetPointForObject(GameObject obj);
	}

	public interface IDied
	{
		void SetCreator(ObjectGenerator creator);
		void Die();
	}

}