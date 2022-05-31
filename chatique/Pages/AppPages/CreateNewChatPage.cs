using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class CreateNewChatPage : BasePage
{
    private static By Identifier = By.Id("modalLabel");

    private static By ChatTitleFieldLocator = By.Id("title");
    private static By ChatMessageFieldLocator = By.Id("message");
    private static By SubmitButtonLocator = By.Id("submitBtn");
    private static By OkButtonLocator = By.XPath("//*[@data-dismiss='modal'][@class='btn btn-block btn-primary']");

    public IWebElement ChatTitleField => WaitService.WaitUntilElementClickable(ChatTitleFieldLocator);
    public IWebElement ChatMessageField => WaitService.WaitUntilElementClickable(ChatMessageFieldLocator);
    public IWebElement SubmitButton => WaitService.WaitUntilElementClickable(SubmitButtonLocator);
    public IWebElement OkButton => WaitService.WaitUntilElementClickable(OkButtonLocator);

    public CreateNewChatPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return Identifier;
    }
}