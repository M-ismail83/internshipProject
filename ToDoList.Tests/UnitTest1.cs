using Xunit;
using Bunit;
using ToDoList.Components.Pages;
using System.Threading.Tasks;

namespace ToDoList.Tests;

public class UnitTest1 : TestContext
{
    [Fact]
    public async Task PercentageTest()
    {
        var cut = RenderComponent<ToDo>();

        await cut.InvokeAsync(() =>
        {
            cut.Instance.todos.Add(new ToDoItem { Title = "Take out the trash" });
            cut.Instance.todos.Add(new ToDoItem { Title = "Move the furnitures" });
            cut.Instance.inProgress.Add(new ToDoItem { Title = "Finish the project" });

            var task = cut.Instance.todos[0];
            cut.Instance.AddInProgress(task);
            cut.Instance.AddDone(task);

        });

        cut.Render();

        var progressBar = cut.Find(".progress-bar");
        var widthStyle = progressBar.GetAttribute("style");

        Assert.Contains("width:33%", widthStyle);
    }

    [Fact]
    public void RenderingTest()
    {

        var cut = RenderComponent<ToDo>();

        var unorderedList = cut.FindAll("ul");

        Assert.Equal(3, unorderedList.Count);

        Assert.Contains("To Do", cut.Markup);
        Assert.Contains("In Progress", cut.Markup);
        Assert.Contains("Done", cut.Markup);

    }
}
