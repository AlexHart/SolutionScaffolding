using System;
namespace Domain.Geometry
{
	public class Cuboid 
	{
		public Point Position { get; }
		public CuboidDimensions Dimensions { get; }
		
		public double Volume => Dimensions.Depth * Dimensions.Width * Dimensions.Height;

		public double MinX { get; }
		public double MaxX { get; }
		public double MinY { get; }
		public double MaxY { get; }
		public double MinZ { get; }
		public double MaxZ { get; }

		public Cuboid(Point position, CuboidDimensions dimensions)
		{
			Position = position;
			Dimensions = dimensions;

			MinX = Position.X - dimensions.Width / 2.0;
			MaxX = Position.X + dimensions.Width / 2.0;
			MinY = Position.Y - dimensions.Height / 2.0;
			MaxY = Position.Y + dimensions.Height / 2.0;
			MinZ = Position.Z - dimensions.Depth / 2.0;
			MaxZ = Position.Z + dimensions.Depth / 2.0;
		}

		/// <summary>
		/// Raw constructor
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="z"></param>
		/// <param name="w"></param>
		/// <param name="h"></param>
		/// <param name="d"></param>
		public Cuboid(double x, double y, double z, double w, double h, double d) 
			: this(new Point(x, y, z), new CuboidDimensions(w, h, d))
		{
		}
	}

}