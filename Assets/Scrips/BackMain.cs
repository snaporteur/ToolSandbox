using UnityEngine;
using UnityEngine.SceneManagement;

public class BackMain : MonoBehaviour
{
    public void Back() {
        SceneManager.LoadScene("Menu");
    }
}
