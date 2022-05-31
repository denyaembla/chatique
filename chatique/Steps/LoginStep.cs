using chatique.Pages.AppPages;
using OpenQA.Selenium;

namespace chatique.Steps;

public class LoginStep : BaseStep
{
    public LoginStep(IWebDriver driver) : base(driver)
    {
    }

    internal LoginPage ExpandLoginBar()
    {
        _indexPage.LoginButton.Click();
        return _loginPage;
    }

    internal MainPage Success_Login(string username, string password)
    {
        _loginPage.UsernameField.SendKeys(username);
        _loginPage.PasswordField.SendKeys(password);
        _loginPage.EnterButton.Submit();
        return _mainPage;
    }

    internal LoginPage Wrong_Login(string username, string password)
    {
        _loginPage.UsernameField.SendKeys(username);
        _loginPage.PasswordField.SendKeys(password);
        _loginPage.EnterButton.Submit();
        return _loginPage;
    }
}
