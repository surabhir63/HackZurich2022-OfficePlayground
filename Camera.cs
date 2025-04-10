using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    
    static WebCamTexture backCam;

     void Start() {
        {
            WebCamDevice[] devices = WebCamTexture.devices;

            Renderer renderer = this.GetComponentInChildren<Renderer>();

            // assuming the first available WebCam is desired
            WebCamTexture webCamTexture = new WebCamTexture(devices[0].name);
            renderer.material.mainTexture = webCamTexture;
            webCamTexture.Play();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
