using M2MqttUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMqttClient : M2MqttUnityClient
{
    protected override void SubscribeTopics()
    {
        Debug.Log("subscribe");
        client.Subscribe(new string[] { "mire" }, new byte[] { 0 });
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        Debug.Log("message received");
        switch (topic)
        {
            case "mire":
                string str = System.Text.Encoding.Default.GetString(message);
                GetComponent<TextMesh>().text = str;
                break;
        }
    }

    protected override void UnsubscribeTopics()
    {
        client.Unsubscribe(new string[] { "mire" });
    }
}
