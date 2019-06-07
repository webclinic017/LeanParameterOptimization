﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace Jtc.Optimization.Api.Controllers
{

    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    public class DataController : Controller
    {

        [HttpGet()]
        public FileStreamResult Index()
        {
            //var builder = new StringBuilder();
            //using (var file = new StreamReader(@"C:\Source\Repos\LeanOptimization_RobotLittleJiggleRemix\Optimization\bin\Release\optimizer.txt"))
            //{
            //    var rand = new Random();
            //    string line;
            //    while ((line = file.ReadLine()) != null)
            //    {
            //        if (rand.Next(0, sampleRate) != 0)
            //        {
            //            continue;
            //        }
            //        builder.AppendLine(line);
            //    }

            //    return Content(builder.ToString(), new MediaTypeHeaderValue("text/plain"));
            //}
            var file = new StreamReader(@"C:\Source\Repos\LeanOptimization_RobotLittleJiggleRemix\Optimization\bin\Release\optimizer.txt");

            return new FileStreamResult(file.BaseStream, "text/plain");

        }
        
        [HttpGet("{sampleRate}")]
        public ContentResult Sample(int sampleRate)
        {
            var builder = new StringBuilder();
            using (var file = new StreamReader(@"C:\Source\Repos\LeanOptimization_RobotLittleJiggleRemix\Optimization\bin\Release\optimizer.txt"))
            {
                var rand = new Random();
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (sampleRate > 1 && rand.Next(0, sampleRate) != 0)
                    {
                        continue;
                    }
                    builder.AppendLine(line);
                }

                return Content(builder.ToString(), new MediaTypeHeaderValue("text/plain"));
            }
        }


    }
}
