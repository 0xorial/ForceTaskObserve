using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.FeaturesTestFramework.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.TestFramework;
using NUnit.Framework;

namespace ForceTaskObserve.Tests
{
    [TestNetFramework45]
    [TestFixture]
    public class TaskShouldBeObservedAnalyzerTests : CSharpHighlightingTestBase
    {
        protected override string RelativeTestDataPath => @"UnobservedTasks";

        protected override bool HighlightingPredicate(IHighlighting highlighting, IPsiSourceFile sourceFile)
            => highlighting is TaskNotObservedHighlighting;

        [Test]
        public void TestUnobservedTask() => DoNamedTest2();
    }
}