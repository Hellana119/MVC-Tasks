using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_Register.Database.Models;

public class CustomUser : IdentityUser
{
    [Column(TypeName ="date")]
    public DateTime DateOfBirth { get; set; }
}
