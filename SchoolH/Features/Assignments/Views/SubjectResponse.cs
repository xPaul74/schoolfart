namespace SchoolH.Features.Assignments.Views;

public class SubjectResponse
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string ProfessorMail { get; set; }
    
    public List<double> Grades { get; set; }
}