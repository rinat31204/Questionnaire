using Questionnaire.Data.Repository;
using Questionnaire.Model;
using Questionnaire.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.Service
{
	public class QuestionService : IQuestionService
	{
		private IUnitOfWork _db;
		public QuestionService(IUnitOfWork db) 
		{
			_db = db;
		}
		public async Task<List<Answer>> CreateAnswer(List<RequestAnswer> requests)
		{
			if (requests.Count == 0)
				throw new Exception("Не указан ответ");

			var list = new List<Answer>();
			foreach (var request in requests) 
			{
				var question = await _db.Question.Get(request.QuestionId);

				if (question == null)
					throw new Exception("Не найден вопрос");

				var answer = new Answer
				{
					Name = request.AnswerName,
					Question = question
				};
				_db.Answer.Create(answer);
				list.Add(answer);
			}
			_db.Save();
			return list;
		}

		public List<Question> GetQuestions()
		{
			return _db.Question.GetAll().ToList();
		}
	}
}
