using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class LoginPage : BasePage
{
    private static By UsernameFieldLocator = By.Id("username");
    private static By PasswordFieldLocator = By.Id("password");
    private static By EnterButtonLocator = By.XPath("//*[@type='submit']");
    private static By WrongLoginHelperTextLocator = By.XPath("//*[@class='help-block']");

    public IWebElement UsernameField => WaitService.WaitUntilElementClickable(UsernameFieldLocator);
    public IWebElement PasswordField => WaitService.WaitUntilElementClickable(PasswordFieldLocator);
    public IWebElement EnterButton => WaitService.WaitUntilElementClickable(EnterButtonLocator);
    public IWebElement WrongLoginHelperText => WaitService.WaitUntilElementExists(WrongLoginHelperTextLocator);

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return PasswordFieldLocator;
    }
}