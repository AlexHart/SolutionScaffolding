using System;
namespace Domain.Geometry
{
    public struct CuboidDimensions
    {
        private const string TooLowError = " can't be less or equal to 0";
        
        public readonly double Width;
        public readonly double Height;
        public readonly double Depth;
        
        public CuboidDimensions(double width, double height, double depth)
        {
            if (width <= 0) throw new ArgumentOutOfRangeException(string.Concat(nameof(width), TooLowError));
            if (height <= 0) throw new ArgumentOutOfRangeException(string.Concat(nameof(height), TooLowError));
            if (depth <= 0) throw new ArgumentOutOfRangeException(string.Concat(nameof(depth), TooLowError));
 
            Width = width;
            Height = height;
            Depth = depth;
        }
    }
    
}
