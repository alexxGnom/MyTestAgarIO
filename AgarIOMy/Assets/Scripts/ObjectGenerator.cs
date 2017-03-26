using UnityEngine;
using System.Collections.Generic;
namespace MyAgarIO
{
	public class ObjectGenerator : MonoBehaviour
	{

		[SerializeField]
		private GameObject prefab;

		[SerializeField]
		private int needCountObjects;

		[SerializeField]
		private float timeUpdate;

		private List<GameObject> objects = new List<GameObject>();

		public int Count
		{
			get { return objects.Count; }
		}

		protected void Start()
		{
			InvokeRepeating("CheckObjects", 0, timeUpdate);
		}

		private void CheckObjects()
		{
			if (objects.Count < needCountObjects)
			{
				GameObject obj = Instantiate(prefab) as GameObject;
				SetObjToStartPos(obj);
				objects.Add(obj);
				OnCreateCallback(obj);
			}
		}

		public virtual void RemoveObject(GameObject obj)
		{
			Debug.Log(obj.name);
			objects.Remove(obj);
		}

		protected virtual void SetObjToStartPos(GameObject obj)
		{
			obj.transform.position = Vector3.zero;
		}

		protected virtual void OnCreateCallback(GameObject obj) { }
	}
}
