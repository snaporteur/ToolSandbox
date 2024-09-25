using System.Collections;
using System.Windows.Forms;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    public string languageCode = "en";
    [SerializeField]
    private bool canchange = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("languageCode"))
        {
            languageCode = PlayerPrefs.GetString("languageCode");

            if (languageCode == "en")
            {
                slider.value = 0;
                canchange = true;
            }
            else if (languageCode == "fr")
            {
                slider.value = 1;
            }
        }
        else
        {
            slider.value = 0;
            canchange = true;
        }
    }

    private IEnumerator GetLanguageData(string languageCode)
    {
        string url = $"https://raw.githubusercontent.com/snaporteur/ToolSandbox-public/language/{languageCode}";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                MessageBox.Show(webRequest.error);
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

    public void OnLanguageChanged()
    {
        if (canchange)
        {
            float sliderValue = slider.value;

            if (sliderValue == 0)
            {
                languageCode = "en";
            }
            else if (sliderValue == 1)
            {
                languageCode = "fr";
            }

            StartCoroutine(GetLanguageData(languageCode));
        }
        else
        {
            canchange = true;
        }
    }
}
