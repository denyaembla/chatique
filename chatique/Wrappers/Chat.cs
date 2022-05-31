using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using chatique.Models;
using OpenQA.Selenium;

namespace chatique.Wrappers;

public class Chat
{
    private IWebElement _uiElement;

    public Chat(IWebDriver driver, By locator, IWebElement webElement)
    {
        _uiElement = new UIElement(driver, locator);
    }
    
    private List<string> UsersMessages(IWebElement chat, string username, By messagePath)
    {
        var messages = new List<string>();
        ReadOnlyCollection<IWebElement> elements = chat.FindElements(messagePath);
        foreach (var message in elements)
        {
            messages.Add(message.Text);
        }

        return messages;
    }

    public UserMessages GetUserMessages(IWebDriver driver, IWebElement chat, string username, By messagePath)
    {
        var messagesContainer = new UserMessages
            {
                Username = driver.FindElement(By.XPath($"//*[contains(text='{username}')]")).Text,
                Messages = UsersMessages(chat, username, messagePath)
            };

        return messagesContainer;
    }

    private static (string username, string data) SeparateMessageHeading(string head, string pattern)
    {
        (string username, string data) message = (string.Empty, string.Empty);
        
        message.username = Regex.Split(head, pattern)[0];
        message.data = Regex.Split(head, pattern)[1];
        
        return message;
    }
    
    public static List<Message> GetAllMessages(IWebElement chat)
    {
        var pattern = ": ";
        var messagesContainer = new List<Message>();
        foreach (var messageBlocks in chat.FindElements(By.XPath("//*[@class='panel panel-default']")))
        {
            var messageUsernameAndDate = messageBlocks.FindElement(By.XPath("//*[@class='panel-heading']")).Text;
            var messageText = messageBlocks.FindElement(By.XPath("//*[@class='panel-body']")).Text;
            messagesContainer.Add(new Message
            {
                Username = SeparateMessageHeading(messageUsernameAndDate, pattern).username,
                Date = SeparateMessageHeading(messageUsernameAndDate, pattern).data,
                MessageText = messageText
            });
        }
        return messagesContainer;
    }
}
