using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsharpQuizLibrary.Models;
using CsharpQuizLibrary.Models.Exceptions.QuizExceptions;
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
 
        [HttpGet("random/{number}")]
        public IActionResult GetQuizzes(int number) {
            return Ok(service.GetRandomQuizzes(number));
        }

        // GET api/<QuizController>/5
        [HttpGet("{id}")]
        public IActionResult GetQuiz(int id)
        {

            try
            {
                return Ok(service.GetQuizById(id));
            }
            catch (QuizNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception e) {
                return Problem(e.Message);
            }
            
        }

        // POST api/<QuizController>
        [HttpPost]
        public IActionResult AddQuiz([FromBody] Quiz newQuiz)
        {
            try
            {
                return Created("QuizService",service.AddQuiz(newQuiz));
            }
            catch (DuplicateQuizException ex) {
                return Conflict(ex.Message);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }  
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
