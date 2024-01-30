using UnityEngine;


namespace MiniJam150
{
	public class CustomMath
	{
		public static Vector3 PickRandomPointWithinCubeVolume(Vector3 center, Vector3 extents)
			=> new Vector3
			(
				x: Random.Range(center.x - extents.x, center.x + extents.x),
				y: Random.Range(center.y - extents.y, center.y + extents.y),
				z: Random.Range(center.z - extents.z, center.z + extents.z)
			);

		public static Vector3 PickRandomPointWithinCircleArea(Vector3 center, float radius)
			=> new Vector3
			(
				x: Random.Range(center.x - radius, center.x + radius),
				y: center.y,
				z: Random.Range(center.x - radius, center.x + radius)
			);

		public static Vector3 PickRandomPointWithinSphereVolume(Vector3 center, float radius)
			=> new Vector3
			(
				x: Random.Range(center.x - radius, center.x + radius),
				y: Random.Range(center.y - radius, center.y + radius),
				z: Random.Range(center.z - radius, center.z + radius)
			);
	}
}