using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionnaire.RequestModel;
using Questionnaire.Service;
using System;
using System.Collections.Generic;

namespace Questionnaire.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class QuestionController : ControllerBase
	{
		private readonly IQuestionService _questionService;
		private readonly ILogger<QuestionController> _logger;
		public QuestionController(IQuestionService questionService, ILogger<QuestionController> logger) 
		{
			_questionService = questionService;
			_logger = logger;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			try
			{
				var questions = _questionService.GetQuestions();
				return Ok(questions);
			}
			catch (Exception ex) 
			{
				_logger.LogError(ex.Message, ex);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public IActionResult CreateAnswer([FromBody] List<RequestAnswer> request) 
		{
			try
			{
				var answers = _questionService.CreateAnswer(request);
				return Ok(answers);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				return BadRequest(ex.Message);
			}
		}
	}
}
