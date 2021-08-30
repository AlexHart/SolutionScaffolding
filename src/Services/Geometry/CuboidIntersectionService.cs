using System;
using Domain.Geometry;

namespace Services.Geometry 
{
	public class CuboidIntersectionService : ICuboidIntersectionService
	{
		public bool CuboidsIntersect(Cuboid cube1, Cuboid cube2)
		{
			var intersect = 
				cube1.MaxX > cube2.MinX && 
				cube1.MinX < cube2.MaxX &&
				cube1.MaxY > cube2.MinY && 
				cube1.MinY < cube2.MaxY &&
				cube1.MaxZ > cube2.MinZ && 
				cube1.MinZ < cube2.MaxZ;

			return intersect;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cube1"></param>
		/// <param name="cube2"></param>
		/// <returns></returns>
		/// <remarks>https://stackoverflow.com/questions/5556170/finding-shared-volume-of-two-overlapping-cuboids</remarks>
		public CuboidIntersectionResult CuboidIntersectionVolume(Cuboid cube1, Cuboid cube2)
		{
			var hasIntersection = CuboidsIntersect(cube1, cube2);
			if (!hasIntersection)
			{
				return new CuboidIntersectionResult(false, 0.0);
			}
			
			// max(min(a',x')-max(a,x),0)
			// 	* max(min(b',y')-max(b,y),0)
			// 	* max(min(c',z')-max(c,z),0)

			var volume = 
				  Math.Max(Math.Min(cube1.MaxX, cube2.MaxX) - Math.Max(cube1.MinX, cube2.MinX), 0)
				* Math.Max(Math.Min(cube1.MaxY, cube2.MaxY) - Math.Max(cube1.MinY, cube2.MinY), 0)
				* Math.Max(Math.Min(cube1.MaxZ, cube2.MaxZ) - Math.Max(cube1.MinZ, cube2.MinZ), 0);

			return new CuboidIntersectionResult(true, volume);
		}
	}
}