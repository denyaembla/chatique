using chatique.Pages.AppPages;
using OpenQA.Selenium;

namespace chatique.Steps;

public class CreateUserStep : BaseStep
{
    public CreateUserStep(IWebDriver driver) : base(driver)
    {
    }

    public LoginPage CreateUser(string username, string password, string confirmationCode)
    {
        _indexPage.RegisterButton.Click();
        _registerPage.UsernameField.SendKeys(username);
        _registerPage.PasswordField.SendKeys(password);
        _registerPage.SecretCodeField.SendKeys(confirmationCode);
        _registerPage.DoneButton.Click();

        return _loginPage;
    }
}
