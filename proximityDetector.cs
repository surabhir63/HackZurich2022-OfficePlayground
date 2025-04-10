using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class proximityDetector : MonoBehaviour
{
    public GameObject player;
    public string detectorName = "";
    public float detectionRadius = 0.74f;
    private enum UpDown { Down = -1, Start = 0, Up = 1 };
    private Text text;
    // private UpDown textChanged = UpDown.Start;
    public string textText = "";
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Vector2.Distance(player.GetComponent<Transform>().position, this.GetComponent<Transform>().position) < detectionRadius) {
            canvas.enabled = true;
        }
        else {
            canvas.enabled = false;
        }
    }


    void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = textText;
        text.fontSize = 30;
        text.alignment = TextAnchor.LowerCenter;

        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(Screen.width*0.9f,Screen.height*0.9f);
    }


}
