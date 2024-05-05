using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_task2.Models;

public partial class User
{
    public decimal UserId { get; set; }
    [Required]
    public string? FirstName { get; set; }
    [Required]
    public string? LastName { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
