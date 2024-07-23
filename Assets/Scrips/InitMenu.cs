using UnityEngine;

public class InitMenu : MonoBehaviour
{

    public void Awake()
    {
        SettingsSaver.InitSettings();
        SettingsSaver.SaveSettingsIfNotExists("language", "english");
        SettingsSaver.SaveSettingsIfNotExists("display-width", "1920");
        SettingsSaver.SaveSettingsIfNotExists("display-height", "1080");
        SettingsSaver.SaveSettingsIfNotExists("display-fullscreen", "true");
    }

    public void Start()
    {
        Screen.SetResolution(854, 480, false);
    }
}
