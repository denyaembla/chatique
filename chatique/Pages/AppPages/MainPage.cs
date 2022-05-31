using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace chatique.Pages.AppPages;

public class MainPage : BasePage
{
    private static By ChatsLocator = By.XPath("//*[@class='list-group-item']");
    private static By UserNameLocator = By.XPath("//*[@id='helloUser']/b");
    private static By CreateNewChatButtonLocator = By.XPath("//*[@data-target='#newChatModal']");
    private static By ChatNameTextLocator = By.XPath("//app-chat-page/h3");
    private static By ProfileButtonLocator = By.XPath("//*[@routerlink='/profile']");

    public ReadOnlyCollection<IWebElement> Chats => WaitService.WaitUntilListOfElementsExists(ChatsLocator);
    public IWebElement CreateNewChatButton => WaitService.WaitUntilElementClickable(CreateNewChatButtonLocator);
    public IWebElement ChatnameText => WaitService.WaitUntilElementExists(ChatNameTextLocator);
    public IWebElement UsernameText => WaitService.WaitUntilElementExists(UserNameLocator);
    public IWebElement ProfileButton => WaitService.WaitUntilElementClickable(ProfileButtonLocator);
    public IWebElement test => WaitService.WaitUntilElementClickable(By.XPath("//*[@class='list-group-item'][2]/b"));
    public IWebElement ClickChatByChatName(string chatName)
    {
        return WaitService.WaitUntilElementClickable(
            By.XPath($"//*[@class='list-group-item']/*[contains(text(),'{chatName}')]"));
    }
    
    public MainPage(IWebDriver driver) : base(driver)
    {
    }

    protected override By GetPageIdentifier()
    {
        return UserNameLocator;
    }
}
