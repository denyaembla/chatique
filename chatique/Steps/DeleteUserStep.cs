using chatique.Pages.AppPages;
using OpenQA.Selenium;

namespace chatique.Steps;

public class DeleteUserStep : BaseStep
{
    public DeleteUserStep(IWebDriver driver) : base(driver)
    {
    }

    public IndexPage DeleteUser(string password)
    {
        _mainPage.ProfileButton.Click();
        _profilePage.ExpandDeletionMenu.Click();
        _profilePage.DeleteCodeConfirmationField.SendKeys(password);
        _profilePage.SubmitDeletion.Click();

        return _indexPage;
    }
}
