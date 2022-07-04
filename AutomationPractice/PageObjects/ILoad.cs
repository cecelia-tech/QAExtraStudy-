namespace AutomationPractice.PageObjects;

public interface ILoad<T>
{
    public T LoadPage();
    public bool IsPageLoaded();
}
