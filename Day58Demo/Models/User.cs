using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day58Demo.Models;

[Table("Users")]
public class User
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [MaxLength(10)]
    [MinLength(10)]
    public string Pan { get; set; }
    
    [MaxLength(250)]
    public string Address { get; set; }

    public char? Gender { get; set; }

    [Phone]
    [MaxLength(50)]
    public string MobileNumber { get; set; }

    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; }

    [MaxLength(1000)]
    public string Comment { get; set; }

    public int DepartmentRefId { get; set; }
}