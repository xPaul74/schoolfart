using System.ComponentModel.DataAnnotations;

namespace SchoolH.Features.Assignments.Views;

public class SubjectRequest
{
    [Required] public string Name { get; set; }
    
    [Required] public string ProfessorMail { get; set; }
    
    [Required] public List<double> Grades { get; set; }
}