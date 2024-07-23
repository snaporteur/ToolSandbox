using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSandbox : MonoBehaviour
{
    private int display_width;
    private int display_height;
    private bool display_fullscreen;

    public void Start() {
        display_width = int.Parse(SettingsSaver.GetSettings("display-width"));
        display_height = int.Parse(SettingsSaver.GetSettings("display-height"));
        if (SettingsSaver.GetSettings("display-fullscreen") == "true") 
        {
            display_fullscreen = true;
        } 
        else
        {
            display_fullscreen = false;
        }
    }

    public void Load(string pathscript) {
        PlayerPrefs.SetString("pathscript", pathscript);
        Destroy(GameObject.FindGameObjectWithTag("ContentUI"));
        Screen.SetResolution(display_width, display_height, display_fullscreen);
        SceneManager.LoadScene("Main");
    }
}
