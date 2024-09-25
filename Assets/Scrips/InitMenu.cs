using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class InitMenu : MonoBehaviour
{
    private IEnumerator GetLanguageData(string languageCode)
    {
        string url = $"https://raw.githubusercontent.com/snaporteur/ToolSandbox-public/language/{languageCode}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                PlayerPrefs.SetString("languageCode", languageCode);

                string[] lines = webRequest.downloadHandler.text.Split('/');
                foreach (string line in lines)
                {
                    string[] keyValue = line.Split('|');
                    if (keyValue.Length == 2)
                    {
                        PlayerPrefs.SetString("language_" + keyValue[0].Trim(), keyValue[1].Trim());
                    }
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void Start()
    {
        SettingsSaver.InitSettings();
        SettingsSaver.SaveSettingsIfNotExists("language", "english");
        SettingsSaver.SaveSettingsIfNotExists("display-width", "1920");
        SettingsSaver.SaveSettingsIfNotExists("display-height", "1080");
        SettingsSaver.SaveSettingsIfNotExists("display-fullscreen", "true");

        Screen.SetResolution(854, 480, false);

        if (!PlayerPrefs.HasKey("languageCode"))
        {
            StartCoroutine(GetLanguageData("en"));
        }
    }
}
