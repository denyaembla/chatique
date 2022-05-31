using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace chatique.Services;

public class WaitService
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _explicitWait;
    private readonly DefaultWait<IWebDriver> _fluentWait;
    private TimeSpan baseWait = TimeSpan.FromSeconds(Configurator.WaitTimeout);
    private TimeSpan baseFluentWait = TimeSpan.FromMilliseconds(250);

    public WaitService(IWebDriver driver)
    {
        _driver = driver;
        _explicitWait = new WebDriverWait(_driver, baseWait);

        _fluentWait = new DefaultWait<IWebDriver>(_driver)
        {
            Timeout = baseWait,
            PollingInterval = baseFluentWait
        };
        _fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    public IWebElement WaitUntilElementExists(By locator)
    {
        return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
    }

    public IWebElement WaitUntilElementClickable(By locator)
    {
        return _explicitWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
    }

    public ReadOnlyCollection<IWebElement> WaitUntilListOfElementsExists(By locator)
    {
        return _explicitWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
    }

    public ReadOnlyCollection<IWebElement> WaitUntilEveryElementsIsClickable(By locator)
    {
        return _explicitWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
    }

    public IWebElement WaitUntilElementClickable(IWebElement webElement)
    {
        return _explicitWait.Until(
            SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
    }
}
