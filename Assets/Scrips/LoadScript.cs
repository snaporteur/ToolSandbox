using UnityEngine;
using SFB;

public class LoadScript : MonoBehaviour
{

    public LoadSandbox loadSandbox;

    [ContextMenu("Open File Picker")]
    private string ScriptPicker()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Select Script", "", "lua", false);
        if (paths.Length == 1) 
        {
            return paths[0];
        }
        else
        {
            return "null";
        }
    }

    public void Load()
    {
        string path = ScriptPicker();
        if (path == "null") return;

        loadSandbox.Load(path);
    }
}
