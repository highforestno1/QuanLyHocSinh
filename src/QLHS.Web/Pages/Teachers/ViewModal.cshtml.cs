using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLHS.Teachers;
using QLHS.Web.Models;

namespace QLHS.Web.Pages.Teachers;

public class ViewModal : QLHSPageModel
{
    /*[HiddenInput] */
    [BindProperty(SupportsGet = true)] 
    public Guid Id { get; set; }

    [BindProperty]
    public TeacherViewModel TeacherViewModel { get; set; }

    private readonly ITeacherAppService _teacherAppService;

    public ViewModal(ITeacherAppService teacherAppService)
    {
        _teacherAppService = teacherAppService;
    }

    public async Task OnGetAsync()
    {
        var teacherDto = await _teacherAppService.GetAsync(Id);
        TeacherViewModel = ObjectMapper.Map<TeacherDto, TeacherViewModel>(teacherDto);
    }

    
}