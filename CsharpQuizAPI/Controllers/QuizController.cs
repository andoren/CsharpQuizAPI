using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpQuizLibrary.Models;
using CsharpQuizLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CsharpQuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        public QuizController(IQuizService service)
        {
            this.service = service;
        }
        IQuizService service;
        private static readonly Random rnd = new Random();
        // GET: api/<QuizController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("random/{number}")]
        public IActionResult GetQuizzes(int number) {
            return Ok(service.GetRandomQuizzes(number));
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuizController>
        [HttpPost]
        public IActionResult Post([FromBody] Quiz newQuiz)
        {
            return Ok(service.AddQuiz(newQuiz));
        }

        // PUT api/<QuizController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Quiz modifyQuiz)
        {
            return Ok(service.ModifyQuiz(modifyQuiz));
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = service.DeleteQuiz(id);
            return Ok(result);
        }
    }
}
