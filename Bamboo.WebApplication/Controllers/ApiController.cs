using Bamboo.WebApplication.Filters.Exception;
using Microsoft.AspNetCore.Mvc;

namespace Bamboo.WebApplication.Controllers
{
    [ServiceFilter(typeof(ApiExceptionFilter))]
    public class ApiController : Controller
    {
        public const string AreaName = "api";
    }
}