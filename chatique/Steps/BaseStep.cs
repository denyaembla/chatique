using chatique.Pages.AppPages;
using chatique.Services;
using NUnit.Framework;
using OpenQA.Selenium;

namespace chatique.Steps;

public abstract class BaseStep
{
    protected static IWebDriver _driver;
    
    protected IndexPage _indexPage;
    protected LoginPage _loginPage;
    protected internal MainPage _mainPage;
    protected CreateNewChatPage _createNewChatPage;
    protected internal ChatPage _chatPage;
    protected RegisterPage _registerPage;
    protected ProfilePage _profilePage;

    protected BaseStep(IWebDriver driver)
    {
        _driver = driver;
        
        _indexPage = new IndexPage(_driver);
        _loginPage = new LoginPage(_driver);
        _mainPage = new MainPage(_driver);
        _createNewChatPage = new CreateNewChatPage(_driver);
        _chatPage = new ChatPage(_driver);
        _registerPage = new RegisterPage(_driver);
        _profilePage = new ProfilePage(_driver);
    }

    [SetUp]
    public void SetUp()
    {
        _driver = new BrowserService().Driver;
    }
}
