﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace QLHS.Pages;

public class Index_Tests : QLHSWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
