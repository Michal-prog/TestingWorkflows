using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Frends.Test.TestWorkflow.Definitions;
using Frends.Test.TestWorkflow.Helpers;

namespace Frends.Test.TestWorkflow;

/// <summary>
/// Task Class for Test operations.
/// </summary>
public static class Test
{
    /// <summary>
    /// Testing
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends-Test-TestWorkflow)
    /// </summary>
    /// <param name="input">Essential parameters.</param>
    /// <param name="options">Additional parameters.</param>
    /// <param name="cancellationToken">A cancellation token provided by Frends Platform.</param>
    /// <returns>object { bool Success, string Output, object Error { string Message, Exception AdditionalInfo } }</returns>
    public static Result TestWorkflow(
        [PropertyTab] Input input,
        [PropertyTab] Options options,
        CancellationToken cancellationToken)
    {
        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (input.Repeat < 0)
                throw new Exception("Repeat count cannot be negative.");

            var output = string.Join(options.Delimiter, Enumerable.Repeat(input.Content, input.Repeat));

            return new Result
            {
                Success = true,
                Output = output,
                Error = null,
            };
        }
        catch (Exception ex)
        {
            return ErrorHandler.Handle(ex, options.ThrowErrorOnFailure, options.ErrorMessageOnFailure);
        }
    }
}
