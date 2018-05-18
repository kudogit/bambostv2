using System.Threading.Tasks;
using Bamboo.Core.Models.Carousel;
using Bamboo.Service;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [Route(Endpoint)]
    public class CarouselController : ApiController
    {
        private const string Endpoint = AreaName + "/carousel";
        private const string CreateEndpoint = "create";
        private readonly ICarouselService _carouselService;

        public CarouselController(ICarouselService carouselService)
        {
            _carouselService = carouselService;
        }
    }
}