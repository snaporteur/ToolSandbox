using UnityEngine;

public class LUACamera
{
    public void Move(float x, float y, float z)
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        camera.transform.position = new Vector3(x, y, z);
    }

    public void Rotate(float x, float y, float z)
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        camera.transform.rotation = Quaternion.Euler(x, y, z);
    }

    public void Scale(float x, float y, float z)
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        camera.transform.localScale = new Vector3(x, y, z);
    }
}
