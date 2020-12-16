using M2MqttUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMqttDataLogger : M2MqttUnityClient
{
    public string topic;    

    protected override void OnConnected()
    {
        Debug.Log("OnConnected");
        StartCoroutine("LoggingCoroutine");
    }


    IEnumerator LoggingCoroutine()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(.1F);
            try
            {
                string message = transform.position.x + "/" + transform.position.y + "/" + transform.position.z;

                client.Publish(topic, System.Text.Encoding.Default.GetBytes(message));
            }catch(Exception e)
            {
                Debug.LogError(e.StackTrace);
                Debug.LogError(e.Message);
            }
        }
    }
}
