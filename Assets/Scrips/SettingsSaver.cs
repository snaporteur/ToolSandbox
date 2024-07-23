using System.IO;
using UnityEngine;

public class SettingsSaver : MonoBehaviour
{
    private static string GetPath(string name) {
        return Path.Combine(Application.persistentDataPath, "Settings", name + ".txt");
    }

    public static void InitSettings() 
    {
        string path = Path.Combine(Application.persistentDataPath, "Settings");

        if (!Directory.Exists(path)) 
        {
            Directory.CreateDirectory(path);
        }
    }

    public static void SaveSettings(string name, string value)
    {
        File.WriteAllText(GetPath(name), value);
    }


    public static void SaveSettingsIfNotExists(string name, string value)
    {
        if (!File.Exists(GetPath(name))) 
        {
            SaveSettings(name, value);
        }
    }

    public static string GetSettings(string name)
    {
        if (File.Exists(GetPath(name))) 
        {
            return File.ReadAllText(GetPath(name));
        } 
        else 
        {
            return "not found";
        }
    }
}
