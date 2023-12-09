using Microsoft.Playwright;

namespace Campspot_Project.E2E.PageObjects;

public sealed class HomePage
{
    private readonly IPage _page;
    private readonly string _pageUrl;

    public HomePage(IPage page)
    {
        _page = page;
        _pageUrl = "https://development-9-prototype.campspot.com/";
    }

    public async Task LoadPage()
    {
        await _page.GotoAsync(_pageUrl);
    }

    public ILocator GetLocationInput()
    {
        var location = _page.Locator(".location-search-input");
        _page.WaitForLoadStateAsync();
        return location;
    }

    public ILocator GetLocationInputErrorMessage()
    {
        var message = _page.Locator(".home-hero-search-form-location .home-hero-search-form-error-message");
        _page.WaitForLoadStateAsync();
        return message;
    }

    public ILocator GetDatePicker(string checkInOut)
    {
        _page.GetByRole(AriaRole.Button).And(_page.GetByLabel(checkInOut)).FocusAsync();
        return _page.GetByRole(AriaRole.Button).And(_page.GetByLabel(checkInOut));
    }

    public ILocator SelectDateFromDropdown(int day)
    {
        _page.Locator(".aggredator-dropdown");
        var selectedDate = _page.GetByRole(AriaRole.Button).And(_page.GetByText(day.ToString()));
        _page.WaitForLoadStateAsync();
        return selectedDate;
    }

    public ILocator GetGuestsPicker()
    {
        return _page.Locator(".guests-picker");
    }

    public ILocator SelectGuests(string guestType)
    {
        _page.Locator(".guests-picker-menu-category-label-name").GetByText(guestType);
        return _page.GetByRole(AriaRole.Button, new() { Name = "Increase" }).First;
    }

    public ILocator GetSearchButton()
    {
        return _page.Locator(".home-hero-search-form-submit-button");
    }
}