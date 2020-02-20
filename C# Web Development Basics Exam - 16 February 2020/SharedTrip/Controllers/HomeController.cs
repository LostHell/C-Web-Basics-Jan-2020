namespace SharedTrip.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse IndexSLash()
        {
            return this.Index();
        }
        public HttpResponse Index()
        {
            return this.View();
        }
    }
}