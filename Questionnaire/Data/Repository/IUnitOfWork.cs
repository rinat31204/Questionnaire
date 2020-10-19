using System;

namespace Questionnaire.Data.Repository
{
	public interface IUnitOfWork : IDisposable
	{
		IQuestionRepository Question { get; }
		IAnswerRepository Answer { get; }
		void Save();
	}
}
