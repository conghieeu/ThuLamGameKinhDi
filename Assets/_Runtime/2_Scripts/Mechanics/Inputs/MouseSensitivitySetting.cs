using static Unity.Mathematics;
 
public class MouseSensitivitySetting
{
    public override void ApplyValue()
    {

    }

    protected override float GetDefaultValue()
    {
        return 1f;
    }

    protected override float2 GetMinMaxValue()
    {
        return new float2(0.1f, 10f);
    }

    public SettingCategory GetSettingCategory()
    {
        return SettingCategory.Controls;
    }

    public string GetDisplayName()
    {
        return "Mouse Sensitivity";
    }
}
