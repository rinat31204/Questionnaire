using Questionnaire.Model;
using Questionnaire.RequestModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.Service
{
	public interface IQuestionService
	{
		List<Question> GetQuestions();
		Task<List<Answer>> CreateAnswer(List<RequestAnswer> requests);
	}
}
