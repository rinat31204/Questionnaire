using Questionnaire.Model;

namespace Questionnaire.Data.Repository
{
	public class QuestionRepository : Repository<Question>, IQuestionRepository
	{
		public QuestionRepository(DatabaseContext db): base(db) { }
	}
}
