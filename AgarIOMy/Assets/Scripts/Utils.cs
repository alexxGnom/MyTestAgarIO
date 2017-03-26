using UnityEngine;

namespace MyAgarIO
{
	public static class Utils
	{
		public static Vector3 GenerateRandomPos(Vector2 positionRange)
		{
			return new Vector3(Random.Range(-positionRange.x, positionRange.x), Random.Range(-positionRange.y, positionRange.y), 0);
		}

		public static Vector3 BoundingVector(Vector3 orig, Vector2 boundRange)
		{
			return new Vector3(
									((Mathf.Abs(orig.x) < Mathf.Abs(boundRange.x)) ? (orig.x) : (Mathf.Sign(orig.x) * Mathf.Abs(boundRange.x))),
									((Mathf.Abs(orig.y) < Mathf.Abs(boundRange.y)) ? (orig.y) : (Mathf.Sign(orig.y) * Mathf.Abs(boundRange.y))),
									0.0f
								);
		}

	}
}
