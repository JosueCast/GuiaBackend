using Backend.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRamdonServices _singleton;
        private IRamdonServices _rScope;
        private IRamdonServices _rtransient;

        private IRamdonServices _singleton2;
        private IRamdonServices _rScope2;
        private IRamdonServices _rtransient2;


        public RandomController(


            [FromKeyedServices("randomSingleton")] IRamdonServices randomSingleton,
            [FromKeyedServices("randomScope")] IRamdonServices randomServiceScope,
            [FromKeyedServices("randomTrasient")] IRamdonServices randomTrasient,

            [FromKeyedServices("randomSingleton")] IRamdonServices randomSingleton2,
            [FromKeyedServices("randomScope")] IRamdonServices randomServiceScope2,
            [FromKeyedServices("randomTrasient")] IRamdonServices randomTrasient2



            ){

            _singleton = randomSingleton;
            _rScope = randomServiceScope;
            _rtransient = randomTrasient;


            _singleton2 = randomSingleton2;
            _rScope2 = randomServiceScope2;
            _rtransient2 = randomTrasient2;


        }
        [HttpGet]

        public ActionResult<Dictionary<string ,int>> Get()
        {
            var result = new Dictionary<string ,int>();
            result.Add("Singleton 1", _singleton.Value);
            result.Add("Scope 1", _rScope.Value);
            result.Add("Transient1", _rtransient.Value);

            result.Add("Singleton 2", _singleton2.Value);
            result.Add("Scope 2", _rScope2.Value);
            result.Add("Transient 2", _rtransient2.Value);

            return result;
        }


    }
}

