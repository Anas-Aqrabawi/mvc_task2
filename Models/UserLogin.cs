using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mvc_task2.Models;

public partial class UserLogin
{
    public decimal Id { get; set; }
    [Required]
    public string? UserName { get; set; }

    public decimal? RoleId { get; set; }

    public decimal? UserId { get; set; }
    [Required]
    public string? Password { get; set; }

    public virtual Role? Role { get; set; }

    public virtual User? User { get; set; }
}
