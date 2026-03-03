using System.Threading;
using Frends.Test.TestWorkflow.Definitions;
using NUnit.Framework;

namespace Frends.Test.TestWorkflow.Tests;

[TestFixture]
public class FunctionalTests
{
    [Test]
    public void ShouldRepeatContentWithDelimiter()
    {
        var input = new Input
        {
            Content = "foobar",
            Repeat = 3,
        };

        var options = new Options
        {
            Delimiter = ", ",
            ThrowErrorOnFailure = true,
            ErrorMessageOnFailure = null,
        };

        var result = Test.TestWorkflow(input, options, CancellationToken.None);

        Assert.That(result.Output, Is.EqualTo("foobar, foobar, foobar"));
    }
}
