using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class LuaScriptServer : MonoBehaviour
{
    public LoadSandbox loadSandbox;

    private HttpListener httpListener;
    private Thread listenerThread;
    private Queue<Action> mainThreadActions = new Queue<Action>();

    void Start()
    {
        StartServer();
    }

    void Update()
    {
        lock (mainThreadActions)
        {
            while (mainThreadActions.Count > 0)
            {
                mainThreadActions.Dequeue().Invoke();
            }
        }
    }

    void OnDestroy()
    {
        StopServer();
    }

    private void StartServer()
    {
        httpListener = new HttpListener();
        httpListener.Prefixes.Add("http://*:8080/");
        httpListener.Start();
        listenerThread = new Thread(HandleRequests);
        listenerThread.Start();
        Debug.Log("Server started on port 8080");
    }

    private void StopServer()
    {
        if (httpListener != null)
        {
            httpListener.Stop();
            httpListener.Close();
            httpListener = null;
        }

        if (listenerThread != null)
        {
            listenerThread.Join();
            listenerThread = null;
        }

        Debug.Log("Server stopped");
    }

    private void HandleRequests()
    {
        try
        {
            while (httpListener.IsListening)
            {
                var context = httpListener.GetContext();
                var request = context.Request;
                var response = context.Response;

                if (request.HttpMethod == "GET" && request.Url.AbsolutePath == "/run")
                {
                    lock (mainThreadActions)
                    {
                        mainThreadActions.Enqueue(() =>
                        {
                            System.Windows.Forms.MessageBox.Show("Le script est chargé.\nFermer cette fenètre pour le lancer");
                            loadSandbox.Load(Application.dataPath + "/ScriptStore/dscript.lua");
                        });
                    }
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }

                response.OutputStream.Close();
            }
        }
        catch (HttpListenerException ex)
        {
            Debug.LogError("HttpListenerException: " + ex.Message);
        }
        catch (Exception ex)
        {
            Debug.LogError("Exception: " + ex.Message);
        }
    }
}