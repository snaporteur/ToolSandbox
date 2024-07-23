using TMPro;
using UnityEngine;

public class LUAEcho
{

    private static TextMeshProUGUI getText()
    {
        GameObject echoTextObject = GameObject.FindGameObjectWithTag("EchoText");
        return echoTextObject.GetComponent<TextMeshProUGUI>();
    }

    public static void Echo(string message)
    {
        TextMeshProUGUI text = getText();
        text.color = new Color(255, 255, 255, 255);
        text.SetText(message);
    }

    public static void EchoErr(string message)
    {
        TextMeshProUGUI text = getText();
        text.color = new Color(255, 0, 0, 255);
        text.SetText(message);
    }

}
