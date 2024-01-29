using UnityEngine;


namespace MiniJam150
{
	public class CustomMath
	{
		public static Vector3 PickRandomPointWithinCubeVolume(Vector3 extents)
			=> new Vector3
			(
				x: Random.Range(-extents.x, extents.x),
				y: Random.Range(-extents.y, extents.y),
				z: Random.Range(-extents.z, extents.z)
			);

		public static Vector3 PickRandomPointWithinCircleArea(float radius)
			=> new Vector3
			(
				x: Random.Range(-radius, radius),
				y: 0f,
				z: Random.Range(-radius, radius)
			);

		public static Vector3 PickRandomPointWithinSphereVolume(float radius)
			=> new Vector3
			(
				x: Random.Range(-radius, radius),
				y: Random.Range(-radius, radius),
				z: Random.Range(-radius, radius)
			);
	}
}