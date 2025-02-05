using Volo.Abp.Settings;

namespace WTECHIN.Tutorial.Settings;

public class TutorialSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TutorialSettings.MySetting1));
    }
}
