using System.Threading;
using chatique.Services;
using chatique.Wrappers;
using NUnit.Framework;
using UIElement = chatique.Services.Selenium.UIElement;

namespace chatique.Tests.AppTests;

public class UsabilityTests : BaseTest
{
    private (string username, string password, string confirmation)
        _newUserCreds = ("ilovepizza2", "ilovepizza2", "666");
    
    private (string name, string title)
        _newChat = ("icecream", "another cool chat");
    
    [Test]
    [Category("User")]
    public void CreateUserTest()
    {
        Driver.Navigate().GoToUrl("https://fathomless-oasis-87358.herokuapp.com/");
        _createUserStep.CreateUser(
            _newUserCreds.username, _newUserCreds.password, _newUserCreds.confirmation);
        _loginStep.ExpandLoginBar();
        var mainPage = _loginStep.Success_Login(_newUserCreds.username, _newUserCreds.password);

        Assert.AreEqual(mainPage.UsernameText.Text, _newUserCreds.username);
    }

    [Test]
    [Category("User")]
    public void DeleteUser()
    {
        Driver.Navigate().GoToUrl("https://fathomless-oasis-87358.herokuapp.com/");
        _loginStep.ExpandLoginBar();
        _loginStep.Success_Login(_newUserCreds.username, _newUserCreds.password);
        _deleteUserStep.DeleteUser(_newUserCreds.password);
    }
    
    [Test]
    [Category("Chat")]
    public void CreateChatTest()
    {
        Driver.Navigate().GoToUrl("https://fathomless-oasis-87358.herokuapp.com/");
        _loginStep.ExpandLoginBar();
        var mainPage = _loginStep.Success_Login(_newUserCreds.username, _newUserCreds.password);
        var chatsAmount = mainPage.Chats.Count;
        
        _chattingStep.CreateNewChat(_newChat.name, _newChat.title);

        Assert.GreaterOrEqual(chatsAmount + 1, mainPage.Chats.Count);
    }
    
    [Test]
    [Category("Chat")]
    public void DeleteChatTest()
    {
    }
    
    [Test]
    [Category("Chat")]
    public void WriteInChatTest()
    {
    }

    [Test]
    public void TestingStuff()
    {
        _driver.Navigate().GoToUrl(Configurator.Url);
        _loginStep.ExpandLoginBar();
        var mainPage = _loginStep.Success_Login("embla", "embla1");
        Assert.AreEqual("text", _chattingStep._mainPage.test.Text);
        _chattingStep.GoToChat("New");
        Assert.AreEqual("Chatique", _chattingStep._chatPage.Project.Text);
        _chattingStep.WriteMessageInChat("hello dear traveller1");
        _driver.Navigate().Refresh();
        Thread.Sleep(5000);
        var chat = _chattingStep._chatPage.ChatAsUIELement;
        var messages = Chat.GetAllMessages(chat);
        Assert.AreEqual("hello dear traveller", messages[^1].MessageText);
    }
}

// public List<Messages> GetUserMessages(UIElement chat, string username){}
//на странице чата
////*[@class='panel panel-default'][=здесь_переменная_для_цикла=]/*[@class='panel-heading' or @class='panel-body'] =>
/// обращение к форме одного сообщения => записываем атрибут в объект месседжа и кладем в лист
/// //*following-sibling[@class='panel-body'][@class='panel-heading' and contains(text(),'ilovepizza2')]
