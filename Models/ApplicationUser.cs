using Microsoft.AspNetCore.Identity;
using System;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfilePictureUrl { get; set; }
}
