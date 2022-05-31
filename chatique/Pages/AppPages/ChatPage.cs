using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class ChatPage : BasePage
{
    private static By ProjectName = By.XPath("//h1");
    private static By ChatNameLocator = By.XPath("//*[@id='chatTitle']");
    
    private static By ChatTextFieldLocator = By.Id("inputMessage");
    private static By SendMessageByMouseButtonLocator = By.XPath("//*[@class='glyphicon glyphicon-ok']");
    
    private static By DeleteChatButtonLocator = By.Id("chatDeleteBtn");
    
    private static By ChatForUIELementLocator = By.XPath("//*[@class='messages']"); // to complete
    
    public IWebElement Project => WaitService.WaitUntilElementExists(ProjectName);
    public IWebElement ChatName => WaitService.WaitUntilElementExists(ChatNameLocator);
    public IWebElement ChattingField => WaitService.WaitUntilElementClickable(ChatTextFieldLocator);
    public IWebElement SendMessageByMouseButton => WaitService.WaitUntilElementClickable(SendMessageByMouseButtonLocator);
    
    public IWebElement DeleteChatButton => WaitService.WaitUntilElementClickable(DeleteChatButtonLocator); //if owner
    
    public IWebElement ChatAsUIELement => WaitService.WaitUntilElementClickable(ChatForUIELementLocator);
    
    public ChatPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return ChatTextFieldLocator;
    }
}
