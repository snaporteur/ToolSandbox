using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string Id;

    void Start()
    {
        text.SetText(PlayerPrefs.GetString("language_" + Id));
    }
}
