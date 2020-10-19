using Questionnaire.Model;

namespace Questionnaire.Data.Repository
{
	public class AnswerRepository : Repository<Answer>, IAnswerRepository
	{
		public AnswerRepository(DatabaseContext db): base(db) { }
	}
}
