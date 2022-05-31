using System.Collections.ObjectModel;
using System.Drawing;
using chatique.Services;
using OpenQA.Selenium;

namespace chatique.Wrappers;

public class UIElement : IWebElement
{
    private By _locator;
    private IWebDriver _driver;
    private readonly IWebElement _webElement;
    private readonly WaitService _waitService;

    public UIElement(IWebDriver driver, By locator)
    {
        _locator = locator;
        _driver = driver;
        _waitService = new WaitService(_driver);
        _webElement = _waitService.WaitUntilElementExists(_locator);
    }
    
    public IWebElement FindElement(By @by)
    {
        return _webElement.FindElement(by);
    }

    public ReadOnlyCollection<IWebElement> FindElements(By @by)
    {
        return _webElement.FindElements(by);
    }

    public void Clear()
    {
        _webElement.Click();
    }

    public void SendKeys(string text)
    {
        _webElement.SendKeys(text);
    }

    public void Submit()
    {
        _webElement.Submit();
    }

    public void Click()
    {
        _waitService.WaitUntilElementClickable(_webElement).Click();
    }

    public string GetAttribute(string attributeName)
    {
        return _webElement.GetAttribute(attributeName);
    }

    public string GetDomAttribute(string attributeName)
    {
        return _webElement.GetDomAttribute(attributeName);
    }

    public string GetProperty(string propertyName)
    {
        return _webElement.GetProperty(propertyName);
    }

    public string GetDomProperty(string propertyName)
    {
        return _webElement.GetDomProperty(propertyName);
    }

    public string GetCssValue(string propertyName)
    {
        return _webElement.GetCssValue(propertyName);
    }

    public ISearchContext GetShadowRoot()
    {
        return _webElement.GetShadowRoot();
    }

    public string TagName { get; }
    public string Text { get; }
    public bool Enabled { get; }
    public bool Selected { get; }
    public Point Location { get; }
    public Size Size { get; }
    public bool Displayed { get; }
}
