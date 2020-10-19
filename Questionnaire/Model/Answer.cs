namespace Questionnaire.Model
{
	public class Answer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Question Question { get; set; }
	}
}
