using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CsharpQuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private static readonly Random rnd = new Random();
        // GET: api/<QuizController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("random/{number}")]
        public IEnumerable<Quiz> GetQuizzes(int number) {
            Quiz[] data = new Quiz[number];
            for (int i = 0; i < number; i++)
            {
                int id = rnd.Next(0, 500);
                data[i] = new Quiz(id, "Question"+id, "Explanation"+id, new string[4] {"Answer1","Answer2","Answer3","Answer4"},"Answer"+rnd.Next(1,4));            
            }
            return data;
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuizController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuizController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuizController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
