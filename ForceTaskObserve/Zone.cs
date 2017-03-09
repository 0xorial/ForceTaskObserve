using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.Application.Environment;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.Xaml;
using ReCommendedExtension;

namespace ReCommendedExtension
{
    [ZoneDefinition]
    [ZoneDefinitionConfigurableFeature(
        ZoneMarker.ExtensionName, ZoneMarker.ExtensionDescription, false /* true -> in "Products", false -> in "Features" */)]
    public interface IForceTaskObserveZone : IZone, IRequire<ILanguageCSharpZone>, IRequire<ILanguageXamlZone> { }

    [ZoneMarker]
    public sealed class ZoneMarker : IRequire<IForceTaskObserveZone>
    {
        internal const string ExtensionName = "TaskObserve Extension for ReSharper";
        internal const string ExtensionDescription = "Code analysis improvements and context actions.";
    }
}

namespace ExtensionActivator
{
    [ZoneActivator]
    [ZoneMarker]
    public sealed class ForceTaskObserveExtensionActivator : IActivate<IForceTaskObserveZone>
    {
        public bool ActivatorEnabled() => true;
    }
}