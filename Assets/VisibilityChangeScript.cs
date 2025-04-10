using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private float timePassed = 0.0f;
    public float timePassThreshhold = 10.5f;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        foreach (Transform child in this.transform)
        {
             if (timePassed>timePassThreshhold)
             {
                 child.gameObject.SetActive(true);
             }
        }
    }
}
