using Domain.Geometry;
using Services.Geometry;
using Xunit;

namespace Services.Tests.Geometry
{
    public class CuboidIntersectionServiceTests
    {
        [Fact]
        public void Cubes_That_Intersect_Should_Equal_True()
        {
            // Arrange.
            var cube1 = new Cuboid(0.0, 0.0, 0.0, 2.0, 2.0, 2.0);
            var cube2 = new Cuboid(1.0, 1.0, 1.0, 2.0, 2.0, 2.0);
            var cubeIntersectionService = new CuboidIntersectionService();
            
            // Act.
            var intersectionResult = cubeIntersectionService.CuboidsIntersect(cube1, cube2);
            
            // Assert.
            Assert.True(intersectionResult);
        }
        
        [Fact]
        public void Cubes_That_Dont_Intersect_Should_Equal_False()
        {
            // Arrange.
            var cube1 = new Cuboid(0, 0, 0, 2, 2, 2);
            var cube2 = new Cuboid(3, 3, 3, 2, 2, 2);
            var cubeIntersectionService = new CuboidIntersectionService();
            
            // Act.
            var intersectionResult = cubeIntersectionService.CuboidsIntersect(cube1, cube2);
           
            // Assert.
            Assert.False(intersectionResult);
        }

        [Theory]
        [InlineData(0,0,0,3,3,3,0,0,0,3,3,3,27.0, true)]
        [InlineData(0,0,0,2,2,2,1,1,1,2,2,2,1.0, true)]
        [InlineData(1,1,1,4,4,4,1,1,1,2,2,2,8.0, true)]
        [InlineData(0,0,0,2,2,2,3,3,3,2,2,2,0.0, false)]
        [InlineData(0,0,0,1,1,1,1,1,1,1,1,1,0.0, false)]
        [InlineData(0,0,0,4,4,4,1,1,1,4,4,4,27.0, true)]
        [InlineData(10,0,0,1,1,1,0,0,0,1,1,1,0.0, false)]
        public void CuboidIntersectionVolume_Is_Correct(
            double c1x, double c1y, double c1z, double c1w, double c1h, double c1d,
            double c2x, double c2y, double c2z, double c2w, double c2h, double c2d,
            double expectedVolume, bool expectedIntersect)
        {
            // Arrange.
            var cube1 = new Cuboid(c1x, c1y, c1z, c1w, c1h, c1d);
            var cube2 = new Cuboid(c2x, c2y, c2z, c2w, c2h, c2d);
            var cuboidIntersectionService = new CuboidIntersectionService();
            
            // Act.
            var intersectionVolume = cuboidIntersectionService.CuboidIntersectionVolume(cube1, cube2);
            
            // Assert.
            Assert.Equal(expectedIntersect, intersectionVolume.HasIntersection);
            Assert.Equal(expectedVolume, intersectionVolume.Volume); 
        }
        
        [Fact]
        public void Cubes_That_Dont_Intersect_IntersectionVolume_Is_Zero()
        {
            // Arrange.
            var cube1 = new Cuboid(0, 0, 0, 2, 2, 2);
            var cube2 = new Cuboid(3, 3, 3, 2, 2, 2);
            var cubeIntersectionService = new CuboidIntersectionService();
            var expectedVolume = 0.0;
            
            // Act.
            var intersectionVolume = cubeIntersectionService.CuboidIntersectionVolume(cube1, cube2);
            
            // Assert.
            Assert.False(intersectionVolume.HasIntersection);
            Assert.Equal(expectedVolume, intersectionVolume.Volume); 
        }
    }
}
