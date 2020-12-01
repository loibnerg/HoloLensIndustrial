using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class SingleSensorClient : MonoBehaviour
{
    private const float API_CHECK_MAXTIME = 1.0f; // 1 second
    private float apiCheckCountdown = API_CHECK_MAXTIME;
    private bool active = false;
    public GameObject go;
    public TextMesh text;
    public string url;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            apiCheckCountdown -= Time.deltaTime;
            if (apiCheckCountdown <= 0)
            {
                UpdateTextOnResult();
                
                apiCheckCountdown = API_CHECK_MAXTIME;
            }
        }
    }

    public void SetSensorDisplay(bool active)
    {
        this.active = active;
        go.SetActive(active);
    }

    public async void UpdateTextOnResult()
    {
        string result = await Read(url);
        text.text = result;
    }
    

    public async Task<string> Read(string url)
    {
        string completeUrl = string.Format("http://localhost:3000/{0}", url);
        //Debug.Log(completeUrl);
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(completeUrl);
        HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync());
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        //Debug.Log(jsonResponse);
        return jsonResponse;        

    }
}
