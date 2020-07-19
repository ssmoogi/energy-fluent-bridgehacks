/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {   
        // Add RemoteTransformations 
        //script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string name_value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out name_value))
        {
            // Set name
            this.gameObject.name = name_value;
        }

        string value = "";
        string x = "";
        string y = "";
        string z = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("energy_use", out value) && entry.getAdditionalData().TryGetValue("x", out x) && entry.getAdditionalData().TryGetValue("y", out y) && entry.getAdditionalData().TryGetValue("z", out z))
        {
            GameObject text = new GameObject();
            TextMesh t = text.AddComponent<TextMesh>();
            t.text = "Energy Usage: " + value;
            t.fontSize = 50;
            text.name = this.gameObject.name + " " + value;
            int x_int = int.Parse(x);
            int y_int = int.Parse(y);
            int z_int = int.Parse(z);
            if (this.gameObject.name == "Oven.glb" || this.gameObject.name == "Lightbulb"){
                y_int = y_int + 15;
            }

            if (this.gameObject.name == "Television.glb"){
                x_int = x_int + 50;
            }
            else if (this.gameObject.name == "Oven.glb")
            {
                x_int = x_int + 40;
            }
            else if (this.gameObject.name == "Microwave.glb")
            {
                x_int = x_int + 30;
                y_int = y_int + 20;
            }

            text.transform.position = new Vector3(x_int, y_int, z_int);
            // text.transform.localScale = 0.1f * Vector3.one;
            text.transform.eulerAngles = new Vector3(180, 0, 180);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}