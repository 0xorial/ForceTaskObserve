using ForceTaskObserve;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;

[assembly:
    RegisterConfigurableSeverity(TaskNotObservedHighlighting.SeverityId, null, HighlightingGroupIds.CodeInfo,
        "Returned task not observed.", "Returned task is not observe, which may result in exceptions raised on finalizer thread.",
        Severity.WARNING)]

namespace ForceTaskObserve
{
    [ConfigurableSeverityHighlighting(SeverityId, CSharpLanguage.Name)]
    public class TaskNotObservedHighlighting : IHighlighting
    {
        internal const string SeverityId = "ReturnedTaskNotObserved";

        private readonly IInvocationExpression _invocationExpression;

        public bool IsValid()
        {
            return true;
        }

        public DocumentRange CalculateRange()
        {
            return _invocationExpression.GetHighlightingRange();
        }

        public string ToolTip { get; }
        public string ErrorStripeToolTip { get; }

        public TaskNotObservedHighlighting(IInvocationExpression invocationExpression)
        {
            _invocationExpression = invocationExpression;
            var error = "Task should be observed.";
            ToolTip = error;
            ErrorStripeToolTip = error;
        }
    }
}