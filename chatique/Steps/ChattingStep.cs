using chatique.Pages.AppPages;
using OpenQA.Selenium;

namespace chatique.Steps;

public class ChattingStep : BaseStep
{
    public ChattingStep(IWebDriver driver) : base(driver)
    {
    }

    public MainPage CreateNewChat(string chatName, string chatMessage)
    {
        _mainPage.CreateNewChatButton.Click();
        _createNewChatPage.ChatTitleField.SendKeys(chatName);
        _createNewChatPage.ChatMessageField.SendKeys(chatMessage);
        _createNewChatPage.SubmitButton.Click();
        _createNewChatPage.OkButton.Click();
        return _mainPage;
    }

    public ChatPage GoToChat(string chatName)
    {
        _mainPage.ClickChatByChatName(chatName).Click();

        return _chatPage;
    }
    
    public ChatPage WriteMessageInChat(string message)
    {
        _chatPage.ChattingField.SendKeys(message);
        _chatPage.ChattingField.SendKeys(Keys.Enter);
    
        return _chatPage;
    }
}
