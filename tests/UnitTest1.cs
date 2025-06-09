using Microsoft.AspNetCore.Components;
using portfolio_siwa.Modeles;

namespace tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(4, 2 + 2);
        DetailsProjet details = new()
        {
            Titre = "Test Project",
            Texte = new MarkupString("<p>This is a test project description.</p>"),
            CheminImage = "test-image.jpg"
        };
    }
}
