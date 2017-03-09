using System.Diagnostics.CodeAnalysis;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TestFramework;
using JetBrains.TestFramework.Application.Zones;
using NUnit.Framework;

[assembly: RequiresSTA]


[ZoneDefinition]
public interface IMyTestZone : ITestsZone, IRequire<PsiFeatureTestZone>
{
}

[SetUpFixture]
[SuppressMessage("ReSharper", "CheckNamespace", Justification = "Must be in the global namespace.")]
public sealed class TestEnvironmentAssembly : ExtensionTestEnvironmentAssembly<IMyTestZone>
{
}
