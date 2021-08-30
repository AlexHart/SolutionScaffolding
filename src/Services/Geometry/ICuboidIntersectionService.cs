using Domain.Geometry;

namespace Services.Geometry
{
    public interface ICuboidIntersectionService
    {
        bool CuboidsIntersect(Cuboid cube1, Cuboid cube2);
        
        CuboidIntersectionResult CuboidIntersectionVolume(Cuboid cube1, Cuboid cube2);
    }
}
