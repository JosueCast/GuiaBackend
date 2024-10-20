using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("Sync")]
        //public IActionResult getSync()
        //{
        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    stopwatch.Start();

        //    Thread.Sleep(1000);
        //    Console.WriteLine("Conexion Finalizada");


        //    Thread.Sleep(1000);
        //    Console.WriteLine("Conexion Envio Finalizada");
        //    stopwatch.Stop();

        //    return Ok(stopwatch.Elapsed);
        //}

        public async Task<IActionResult> getAsync()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            var tak1 = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Finalizacion d ela tarea asincrona");
                return 8;
            });
            stopwatch.Start();
            var tak2 = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Finalizacion d ela tarea asincrona");
                return 1;
            });


            tak1.Start();
            tak2.Start();
            //Tarea que esta fuera del segmento asincron
            Console.WriteLine("Finalizacion de la tarea NoAsincrona");

            var resultado = await tak1;

            Console.WriteLine("Finalizacion de la tarea NoAsincrona Terminado");
            stopwatch.Stop();
            return Ok(resultado + " " + stopwatch.Elapsed);

        }



    }
}
