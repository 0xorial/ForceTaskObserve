using System.Threading.Tasks;
using JetBrains.ReSharper.Daemon.Stages.Dispatcher;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Util;

namespace ForceTaskObserve
{
    [ElementProblemAnalyzer(typeof(IInvocationExpression), HighlightingTypes = new [] {typeof(TaskNotObservedHighlighting)})]
    public class TaskShouldBeObservedAnalyzer : ElementProblemAnalyzer<IInvocationExpression>
    {
        protected override void Run(IInvocationExpression element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
        {
            var parent = element.Parent;
            var expressionStatement = parent as IExpressionStatement;
            if (expressionStatement == null)
            {
                return;
            }

            var resolve = element.InvocationExpressionReference.Resolve();
            var type = resolve.Result.DeclaredElement.Type();
            if (type.IsTask() || type.IsGenericTask())
            {
                consumer.AddHighlighting(new TaskNotObservedHighlighting(element));
            }
        }
    }
}