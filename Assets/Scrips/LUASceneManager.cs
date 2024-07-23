using UnityEngine;

public class LUASceneManager
{
    public void NewCube(string name, float x, float y, float z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = new Vector3(x, y, z);
    }

    public void NewCapsule(string name, float x, float y, float z)
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsule.name = name;
        capsule.transform.position = new Vector3(x, y, z);
    }

    public void NewCylinder(string name, float x, float y, float z)
    {
        GameObject cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cylinder.name = name;
        cylinder.transform.position = new Vector3(x, y, z);
    }

    public void NewSphere(string name, float x, float y, float z)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = name;
        sphere.transform.position = new Vector3(x, y, z);
    }

    public void MoveObject(string name, float x, float y, float z)
    {
        GameObject obj = GameObject.Find(name);
        if (obj.tag == "MainCamera" && obj.tag == "UnRemovable") return;
        if (obj != null)
        {
            obj.transform.position = new Vector3(x, y, z);
        }
    }

    public void RotateObject(string name, float x, float y, float z)
    {
        GameObject obj = GameObject.Find(name);
        if (obj.tag == "MainCamera" && obj.tag == "UnRemovable") return;
        if (obj != null)
        {
            obj.transform.rotation = Quaternion.Euler(x, y, z);
        }
    }

    public void ScaleObject(string name, float x, float y, float z)
    {
        GameObject obj = GameObject.Find(name);
        if (obj.tag == "MainCamera" && obj.tag == "UnRemovable") return;
        if (obj != null)
        {
            obj.transform.localScale = new Vector3(x, y, z);
        }
    }

    public void AddComponent(string name, string type)
    {
        if ( type == "Rigidbody")
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                obj.AddComponent<Rigidbody>();
            }
        }
    }

    public void SetComponentProperty<multipletype>(string name, string component, string property, multipletype value)
    {
        GameObject obj = GameObject.Find(name);
        if (obj != null)
        {
            Component comp = obj.GetComponent(component);
            if (comp != null)
            {
                var property_v = comp.GetType().GetProperty(property);
                if (property_v != null)
                {
                    if (property_v.CanWrite)
                    {
                        property_v.SetValue(comp, value);
                    }
                    else
                    {
                        LUAEcho.EchoErr("Property is not writable");
                    }
                }
                else
                {
                    LUAEcho.EchoErr("Property is not found");
                }
            } 
            else 
            {
                LUAEcho.EchoErr("Component is not registered");
            }
        }
    }
}