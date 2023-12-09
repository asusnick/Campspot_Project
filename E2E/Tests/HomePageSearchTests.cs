namespace Campspot_Project.E2E.Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class HomePageSearchTests : E2ETestBase
{
    [Test]
    public async Task Search_ProvidingAllInputs_ReturnsResults()
    {
        // Arrange
        var location = "Lodi, California";
        var checkIn = "Check In Date: Add Dates";
        var checkOut = "Check Out Date: Add Dates";
        var checkInDate = DateTime.Today.Day;
        var checkOutDate = DateTime.Today.AddDays(2).Day;
        var guestType = "Adults";
        var expectedUrlWithSearchParams =
            "https://development-9-prototype.campspot.com/search?location=Lodi,%20California&latitude=38.130197&longitude=-121.272447&checkin=2023-12-09&checkout=2023-12-10&adults=3&children=0&pets=0";

        // Act
        await HomePage.LoadPage();
        await HomePage.GetLocationInput().FillAsync(location);
        await HomePage.GetDatePicker(checkIn).ClickAsync();
        await HomePage.SelectDateFromDropdown(checkInDate).First.ClickAsync();
        await HomePage.GetDatePicker(checkOut).ClickAsync();
        await HomePage.SelectDateFromDropdown(checkOutDate).First.ClickAsync();
        await HomePage.GetGuestsPicker().FocusAsync();
        await HomePage.GetGuestsPicker().ClickAsync();
        await HomePage.SelectGuests(guestType).ClickAsync();
        await HomePage.SelectGuests(guestType).ClearAsync();
        await HomePage.GetSearchButton().FocusAsync();
        var searchPage = await Page.RunAndWaitForPopupAsync(async () =>
        {
            await HomePage.GetSearchButton().ClickAsync();
        });

        // Assert
        await Expect(searchPage).ToHaveURLAsync(expectedUrlWithSearchParams);
    }

    [Test]
    public async Task Search_ProvideNoMatchingLocations_ReturnValidationErrorMessage()
    {
        // Arrange
        var location = "123";
        var expectedErrorMessage = "*No results were found for your location search";

        // Act
        await HomePage.LoadPage();
        await HomePage.GetLocationInput().FillAsync(location);
        await HomePage.GetSearchButton().FocusAsync();
        await HomePage.GetSearchButton().ClickAsync();
        var results = HomePage.GetLocationInputErrorMessage();

        // Assert
        await Expect(results).ToContainTextAsync(expectedErrorMessage);
    }
}