using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class taskList : MonoBehaviour
{
    public string detectorName = "";
    private Text text;
    public string textText = "☐ Find two office pets\n ☐ Survive any danger";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        text = textGO.GetComponent<Text>();
        text.font = arial;
        text.text = textText;
        text.fontSize = 20;
        text.alignment = TextAnchor.UpperRight;

        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.sizeDelta = new Vector2(Screen.width*0.9f,Screen.height*0.9f);
    }
}
