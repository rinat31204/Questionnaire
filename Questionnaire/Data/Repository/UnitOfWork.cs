using System;

namespace Questionnaire.Data.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DatabaseContext db;
		IQuestionRepository question;
		IAnswerRepository answer;

		public UnitOfWork() 
		{
			db = new DatabaseContext();
		}

		public IQuestionRepository Question
		{ 
			get 
			{
				if (question == null)
					question = new QuestionRepository(db);
				return question;
			}
		}

		public IAnswerRepository Answer
		{
			get
			{
				if (answer == null)
					answer = new AnswerRepository(db);
				return answer;
			}
		}

		public void Dispose()
		{
			db.Dispose();
			GC.SuppressFinalize(this);
		}

		public void Save()
		{
			db.SaveChangesAsync();
		}
	}
}
