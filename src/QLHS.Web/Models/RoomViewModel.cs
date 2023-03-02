using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLHS.Web.Models;

public class RoomViewModel
{
    public Guid Id { get; set; }

    public bool IsSelected { get; set; }

    [Required]
    [HiddenInput]
    public string Name { get; set; }
}