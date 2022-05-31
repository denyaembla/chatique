using System;
using chatique.Services;
using OpenQA.Selenium;

namespace chatique.Pages;

public abstract class BasePage
{
    [ThreadStatic] private static IWebDriver Driver;
    protected static WaitService WaitService;

    public bool PageOpened => WaitService.WaitUntilElementExists(GetPageIdentifier()).Displayed;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        WaitService = new WaitService(Driver);
    }

    protected abstract By GetPageIdentifier();
}
