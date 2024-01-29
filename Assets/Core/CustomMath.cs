using UnityEngine;


namespace MiniJam150
{
	public class CustomMath
	{
		public static Vector3 PickRandomPointWithinCubeVolume(Vector3 center, Vector3 extents)
			=> new Vector3
			(
				x: center.x + Random.Range(-extents.x, extents.x),
				y: center.y + Random.Range(-extents.y, extents.y),
				z: center.z + Random.Range(-extents.z, extents.z)
			);

		public static Vector3 PickRandomPointWithinCircleArea(Vector3 center, float radius)
			=> new Vector3
			(
				x: center.x + Random.Range(-radius, radius),
				y: center.y + 0f,
				z: center.z + Random.Range(-radius, radius)
			);

		public static Vector3 PickRandomPointWithinSphereVolume(Vector3 center, float radius)
			=> new Vector3
			(
				x: center.x + Random.Range(-radius, radius),
				y: center.y + Random.Range(-radius, radius),
				z: center.z + Random.Range(-radius, radius)
			);
	}
}