using SchoolH.Base;

namespace SchoolH.Features.Assignments.Models;

public class SubjectModel : Model
{
    public string Name { get; set; }
    
    public string ProfessorMail { get; set; }
    
    public List<double> Grades { get; set; }
}