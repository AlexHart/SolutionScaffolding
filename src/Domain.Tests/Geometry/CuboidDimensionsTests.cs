using System;
using Domain.Geometry;
using Xunit;
namespace Domain.Tests.Geometry
{
    public class CuboidDimensionsTests
    {

        [Theory]
        [InlineData(0, 1, 1, false)]
        [InlineData(1, 0, 1, false)]
        [InlineData(1, 1, 0, false)]
        [InlineData(0, 0, 0, false)]
        [InlineData(-1, 0, 0, false)]
        [InlineData(1, 1, 1, true)]
        public void CreateCuboidDimensions_Tests(int w, int h, int d, bool isValid)
        {
            if (!isValid)
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    var dimension = new CuboidDimensions(w, h, d);
                });
            }
            else
            {
                var dimension = new CuboidDimensions(w, h, d); 
                Assert.Equal(w, dimension.Width);
                Assert.Equal(h, dimension.Height);
                Assert.Equal(d, dimension.Depth);
            }
        }
    }
}
