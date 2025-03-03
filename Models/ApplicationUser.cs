using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser : IdentityUser
{
    public required string FullName { get; set; } 
    public DateTime DateOfBirth { get; set; }

}
