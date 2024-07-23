using UnityEngine;

public class LUAGet
{
    private string Position(string name)
    {
        if (name == "camera")
        {
            GameObject obj = GameObject.FindWithTag("MainCamera");
            return obj.transform.position.x.ToString() +"/"+ obj.transform.position.y.ToString() +"/"+ obj.transform.position.z.ToString();
        }
        else
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                return obj.transform.position.x.ToString() +"/"+ obj.transform.position.y.ToString() +"/"+ obj.transform.position.z.ToString();
            }
            else
            {
                return "not found";
            }
        }
    }

    public int PositionX(string name)
    {
        return int.Parse(Position(name).Split("/")[0]);
    }

    public int PositionY(string name)
    {
        return int.Parse(Position(name).Split("/")[1]);
    }

    public int PositionZ(string name)
    {
        return int.Parse(Position(name).Split("/")[2]);
    }

    private string Rotation(string name)
    {
        if (name == "camera")
        {
            GameObject obj = GameObject.FindWithTag("MainCamera");
            return obj.transform.rotation.x.ToString() +"/"+ obj.transform.rotation.y.ToString() +"/"+ obj.transform.rotation.z.ToString();
        }
        else
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                return obj.transform.rotation.x.ToString() +"/"+ obj.transform.rotation.y.ToString() +"/"+ obj.transform.rotation.z.ToString();
            }
            else
            {
                return "not found";
            }
        }
    }

    public int RotationX(string name)
    {
        return int.Parse(Rotation(name).Split("/")[0]);
    }

    public int RotationY(string name)
    {
        return int.Parse(Rotation(name).Split("/")[1]);
    }

    public int RotationZ(string name)
    {
        return int.Parse(Rotation(name).Split("/")[2]);
    }

    private string Scale(string name)
    {
        if (name == "camera")
        {
            GameObject obj = GameObject.FindWithTag("MainCamera");
            return obj.transform.localScale.x.ToString() +"/"+ obj.transform.localScale.y.ToString() +"/"+ obj.transform.localScale.z.ToString();
        }
        else
        {
            GameObject obj = GameObject.Find(name);
            if (obj != null)
            {
                return obj.transform.localScale.x.ToString() +"/"+ obj.transform.localScale.y.ToString() +"/"+ obj.transform.localScale.z.ToString();
            }
            else
            {
                return "not found";
            }
        }
    }

    public int ScaleX(string name)
    {
        return int.Parse(Scale(name).Split("/")[0]);
    }

    public int ScaleY(string name)
    {
        return int.Parse(Scale(name).Split("/")[1]);
    }

    public int ScaleZ(string name)
    {
        return int.Parse(Scale(name).Split("/")[2]);
    }
}
