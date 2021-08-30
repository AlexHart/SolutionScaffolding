using Domain.Geometry;
using Microsoft.AspNetCore.Mvc;
using Services.Geometry;

namespace ScaffoldApi.Controllers 
{
	
	[ApiController]
    [Route("[controller]")]
	public class CuboidCheckerController : Controller
	{
		private readonly ICuboidIntersectionService _cuboidIntersectionService;
		
		public CuboidCheckerController(ICuboidIntersectionService cuboidIntersectionService)
		{
			_cuboidIntersectionService = cuboidIntersectionService;
		}

		[HttpGet("cuboids-intersect")]
		public ActionResult<bool> CuboidsIntersect([FromBodyAttribute]Cuboid cuboid1, [FromBodyAttribute]Cuboid cuboid2)  => 
			_cuboidIntersectionService.CuboidsIntersect(cuboid1, cuboid2);

		[HttpGet("cuboids-intersection")]
		public ActionResult<CuboidIntersectionResult> CuboidsIntersection([FromBodyAttribute]Cuboid cuboid1, [FromBodyAttribute]Cuboid cuboid2)  => 
			_cuboidIntersectionService.CuboidIntersectionVolume(cuboid1, cuboid2);
	}

}