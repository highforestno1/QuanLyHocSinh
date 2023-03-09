using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLHS.Students;
using QLHS.Web.Models;

namespace QLHS.Web.Pages.Students;

public class ViewModal : QLHSPageModel
{
    /*[HiddenInput] */
    [BindProperty(SupportsGet = true)] 
    public Guid Id { get; set; }

    [BindProperty]
    public StudentViewModel StudentViewModel { get; set; }

    public TeacherViewModel TeacherViewModel { get; set; }

    private readonly IStudentAppService _studentAppService;

    public ViewModal(IStudentAppService studentAppService)
    {
        _studentAppService = studentAppService;
    }

    public async Task OnGetAsync()
    {
        var studentDto = await _studentAppService.GetAsync(Id);
        StudentViewModel = ObjectMapper.Map<StudentDto, StudentViewModel>(studentDto);
    }
}