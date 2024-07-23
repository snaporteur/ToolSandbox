using UnityEngine;

public class InitMain : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabui;
    [SerializeField]
    private GameObject parser;

    void Start()
    {
        Instantiate(prefabui);
        Instantiate(parser);
        Destroy(gameObject);
    }
}