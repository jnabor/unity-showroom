using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

public class UnityHttpServer : MonoBehaviour
{
    [SerializeField]
    public int port;

    [SerializeField]
    public string SaveFolder;

    [SerializeField]
    public bool UseStreamingAssetsPath = false;


    [SerializeField]
    public int bufferSize = 16;

    public static UnityHttpServer Instance;


    public MonoBehaviour controller;
    SimpleHttpServer myServer;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (myServer == null)
        {
            Init();
        }
    }

    void Init()
    {
        StartServer();
    }

    public void StartServer()
    {
        myServer = new SimpleHttpServer(GetSaveFolderPath, port, controller, bufferSize);
        myServer.OnJsonSerialized += (result) =>
        {
            return JsonUtility.ToJson(result);
        };
    }

    string GetSaveFolderPath
    {
        get
        {
            if (UseStreamingAssetsPath)
            {
                return Application.streamingAssetsPath;
            }
            return SaveFolder;
        }
    }

    public static string GetHttpUrl()
    {
        return $"http://{GetLocalIPAddress()}:" + Instance.myServer.Port + "/";
    }

    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }

    public void StopServer()
    {
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        myServer.Stop();
    }

}
