using System;
using chatique.Services;
using chatique.Steps;
using NUnit.Framework;
using OpenQA.Selenium;

namespace chatique.Tests;

public abstract class BaseTest
{
    protected static IWebDriver _driver;
    protected LoginStep _loginStep;
    protected ChattingStep _chattingStep;
    protected CreateUserStep _createUserStep;
    protected DeleteUserStep _deleteUserStep;


    protected BaseTest()
    {
        _driver = new BrowserService().Driver;
        _loginStep = new LoginStep(_driver);
        _chattingStep = new ChattingStep(_driver);
        _createUserStep = new CreateUserStep(_driver);
        _deleteUserStep = new DeleteUserStep(_driver);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
    }

    public static IWebDriver Driver
    {
        get => _driver;
        set => _driver = value ?? throw new ArgumentNullException(nameof(value));
    }
}
