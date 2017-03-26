using UnityEngine;
using System.Collections;

namespace MyAgarIO
{
	public class FoodController : ObjectGenerator
	{
		[SerializeField]
		private Vector2 generatePositionsRange;

		private Color[] colors = { Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow };

		protected override void SetObjToStartPos(GameObject obj)
		{
			obj.transform.position = Utils.GenerateRandomPos(generatePositionsRange);
		}

		protected override void OnCreateCallback(GameObject obj)
		{
			obj.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
			obj.GetComponent<IDied>().SetCreator(this);
		}
	}
}
