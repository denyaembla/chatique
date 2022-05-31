using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class IndexPage : BasePage
{
    private static By LoginButtonLocator = By.XPath("//*[@routerlink='login']");
    private static By RegisterButtonLocator = By.XPath("//*[@routerlink='registration']");
    public IWebElement LoginButton => WaitService.WaitUntilElementExists(LoginButtonLocator);
    public IWebElement RegisterButton => WaitService.WaitUntilElementExists(RegisterButtonLocator);


    public IndexPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return RegisterButtonLocator;
    }
}