using System.ComponentModel.DataAnnotations;

namespace SchoolH.Features.Assignments.Views;

public class TestRequest
{
    [Required] public string Subject { get; set; }
    
    [Required] public DateTime TestDate { get; set; }
}