using chatique.Services;
using NUnit.Framework;

namespace chatique.Tests.AppTests;

public class LoginTest : BaseTest
{
    private (string username, string password) _goodCreds = ("embla", "embla1");
    private (string username, string password) _goodLogin_BadPw = ("embla", "zhizapts");
    private (string username, string password) _badLogin_GoodPw = ("test", "embla1");
    private (string username, string password) _badCreds = ("xcgsdfnkgdsfgdsfg", "sfsdgsdfghfdg");

    

    private int amountOfChats = 4;

    [Test]
    [Category("Positive")]
    [Category("Login")]
    public void Login_Positive()
    {
        _driver.Navigate().GoToUrl(Configurator.Url);
        _loginStep.ExpandLoginBar();
        var mainPage = _loginStep.Success_Login(_goodCreds.username, _goodCreds.password);
        Assert.AreEqual(amountOfChats, mainPage.Chats.Count, "Amount of chat is not valid");
    }

    [Test]
    [Category("Negative")]
    [Category("Login")]
    public void Login_Negative_BadPw()
    {
        _driver.Navigate().GoToUrl(Configurator.Url);
        _loginStep.ExpandLoginBar();
        var _loginPage = _loginStep.Wrong_Login(_badLogin_GoodPw.username, _goodLogin_BadPw.password);
        Assert.AreEqual("You have entered wrong credentials, please try again",
            _loginPage.WrongLoginHelperText.Text, "Wrong login test went WRONG");
    }

    [Test]
    [Category("Negative")]
    [Category("Login")]
    public void Login_Negative_GoodPw()
    {
        _driver.Navigate().GoToUrl(Configurator.Url);
        _loginStep.ExpandLoginBar();
        var _loginPage = _loginStep.Wrong_Login(_badLogin_GoodPw.username, _badLogin_GoodPw.password);
        Assert.AreEqual("You have entered wrong credentials, please try again",
            _loginPage.WrongLoginHelperText.Text, "Wrong login test went WRONG");
    }

    [Test]
    [Category("Negative")]
    [Category("Login")]
    public void Login_Negative_BadCreds()
    {
        _driver.Navigate().GoToUrl(Configurator.Url);
        _loginStep.ExpandLoginBar();
        var _loginPage = _loginStep.Wrong_Login(_badCreds.username, _badCreds.password);
        Assert.AreEqual("You have entered wrong credentials, please try again",
            _loginPage.WrongLoginHelperText.Text, "Wrong login test went WRONG");
    }
    //logging ^
        
    
}
