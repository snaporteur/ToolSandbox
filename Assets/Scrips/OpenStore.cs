using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class OpenStore : MonoBehaviour
{
    public void Open()
    {
        try {
            Process store = new Process();

            store.StartInfo.FileName = Path.Combine(Application.dataPath, "ScriptStore", "scriptstore.bat");
            store.StartInfo.UseShellExecute = false;
            store.StartInfo.RedirectStandardOutput = true;
            store.StartInfo.CreateNoWindow = true;

            store.Start();
        } 
        catch(Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }
    }
}
