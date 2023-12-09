using Campspot_Project.E2E.PageObjects;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Campspot_Project.E2E.Tests;

public class E2ETestBase : ContextTest
{
    protected IPage Page { get; private set; } = null!;
    protected HomePage HomePage { get; private set; }

    [SetUp]
    public async Task PageSetup()
    {
        Page = await Context.NewPageAsync().ConfigureAwait(false);
        HomePage = new HomePage(Page);
    }
}