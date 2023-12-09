**Languages and Tools**
- C#
- Playwright.NUnit

**How to run project**
1. Download necessary tools to run a .NET project [https://dotnet.microsoft.com/en-us/download]
   - .Net projects run well in Visual Studio IDEs [https://visualstudio.microsoft.com/downloads/]
3. Download Playwright testing framework [https://playwright.dev/dotnet/docs/intro]
4. Once you have followed the steps of downloading Playwright, downloading necessary packages, and building project, you can now run the tests.
5. First, CD into the E2E folder. Then use the following commands in your commandline or powershell to run tests.
   
   Run in GUI: `$env:HEADED="1"` -> `dotnet test`

   Run in GUI debug mode: `$env:PWDEBUG=1` -> `dotnet test`

**Issue with running tests**

Unfortunately, I was only able to get my tests to pass when running them in debug mode and debugging through them slowly. I thought adding .WaitForLoadState() to the problematic methods may help but Playwright still flies through each step and does not wait for crucial components to load (i.e. datepicker calendar, error message). If provided more time, I would look into performance issues with feature code and perhaps creating my own wait for loading method that also catches timeouts.  

Also, if you run your test cases too many times I do believe the API timeouts.

**Test Strategy and Cases**

I first read through all of the Acceptance Criteria to get a better understanding of what is the feature I am being asked to test, what level of testing is needed (i.e. E2E, API) and what workflow the user is expecting. I manually played around with the website for quite a bit to try and reproduce all of the Acceptance Criteria and to see what may be showstoppers if a bug is present or to arise. I then formed my test cases. My top two cases that would not take over 3 hours to write but are critical:
1. Happy path: Search_ProvidingAllInputs_ReturnsResults()
2. Validation: Search_ProvideNoMatchingLocations_ReturnValidationErrorMessage()

If provided more time, there are several scenarios I would like to cover. See some below:

- No location provided returns results using browser location
- Can't search for past dates
- Complex date combos and invalid inputs

Additionally, I would like to refactor and remove any hardcoded values and redundancies if possible. I would also like to add tests around the search result page.

**Assumptions and Special Considerations**

- I thought I would be able to easily find a date for Check In and Check Out but working with a datepicker without an input field and no traditional DateTime formats made me think a bit more with how to select dates using DateTimes.
- I did not check security or permissions and just assumed that anyone has access to this search.
- I tried to not get too involved in the TestOps side. Normally, I would be more thoughtful with my .gitignore, I'd add a yml file, I'd set up pipelines to get tests running automatically on commits and merges.
