using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    private GameObject on;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gazeObj = CoreServices.InputSystem.GazeProvider.GazeTarget;

        if (on != gazeObj && on != null)
        {
            on.GetComponent<GlowEffect>().glower.SetActive(false);
            foreach (var obj in on.GetComponents<SingleSensorClient>())
            {
                obj.SetSensorDisplay(false);
            }
            on = null;
        }
        else if( on != gazeObj && gazeObj != null && gazeObj.tag.Equals("glow"))
        {
            on = gazeObj;
            gazeObj.GetComponent<GlowEffect>().glower.SetActive(true);            
            foreach (var obj in on.GetComponents<SingleSensorClient>())
            {
                obj.SetSensorDisplay(true);
            }
        }
    }
}
