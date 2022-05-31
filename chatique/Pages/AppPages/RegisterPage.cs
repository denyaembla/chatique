using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class RegisterPage : BasePage
{
    private static By UsernameFieldLocator = By.Id("username");
    private static By PasswordFieldLocator = By.Id("password");
    private static By SecretCodeFieldLocator = By.Id("admissionCode");
    private static By DoneButtonLocator = By.XPath("//*[@type='submit']");
    private static By SuccessLoginTextLocator = By.Id("loginSuccessMsg");

    public IWebElement UsernameField => WaitService.WaitUntilElementClickable(UsernameFieldLocator);
    public IWebElement PasswordField => WaitService.WaitUntilElementClickable(PasswordFieldLocator);
    public IWebElement SecretCodeField => WaitService.WaitUntilElementClickable(SecretCodeFieldLocator);
    public IWebElement DoneButton => WaitService.WaitUntilElementClickable(DoneButtonLocator);
    public IWebElement SuccessLoginText => WaitService.WaitUntilElementExists(SuccessLoginTextLocator);

    public RegisterPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return SecretCodeFieldLocator;
    }
}