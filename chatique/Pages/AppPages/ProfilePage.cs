using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class ProfilePage : BasePage
{
    private static By ChangeUsernameButtonLocator = By.Id("loggedProfileChangeUsernameBtn");
    private static By ChangeUserNameFieldLocator = By.Id("username");
    private static By ChangeUserPasswordFieldLocator = By.Id("password");

    private static By ExpandDeletionMenuLocator = By.Id("loggedProfileDeleteUserBtn");
    private static By DeleteCodeConfirmationFieldLocator = By.XPath("//*[@formcontrolname='passwordDel']");
    private static By SubmitDeletionLocator = By.Id("loggedProfileDeleteUserConfirmBtn");

    private static By BackButtonLocator = By.XPath("//*[@routerlink='/main']");

    public IWebElement ChangeUsernameButton => WaitService.WaitUntilElementClickable(ChangeUsernameButtonLocator);
    public IWebElement ChangeUserNameField => WaitService.WaitUntilElementClickable(ChangeUserNameFieldLocator);
    public IWebElement ChangeUserPasswordField => WaitService.WaitUntilElementClickable(ChangeUserPasswordFieldLocator);

    public IWebElement ExpandDeletionMenu => WaitService.WaitUntilElementClickable(ExpandDeletionMenuLocator);

    public IWebElement DeleteCodeConfirmationField =>
        WaitService.WaitUntilElementClickable(DeleteCodeConfirmationFieldLocator);

    public IWebElement SubmitDeletion => WaitService.WaitUntilElementClickable(SubmitDeletionLocator);

    public IWebElement BackButton => WaitService.WaitUntilElementClickable(BackButtonLocator);


    public ProfilePage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ChangeUsernameButtonLocator;
    }
}
