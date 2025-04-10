using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireVisibility : MonoBehaviour
{
    public GameObject Fire;
    private bool firstFire = true;
    public float timePassFirstFireStart = 10f;
    public float timePassFireStart = 10f;
    public float timePassFireDuration = 10f;
    
    void Start()
    {
        Invoke("Hide",0f);
    }
    
    void Hide(){
        Fire.SetActive(false);
        if(firstFire){
            Invoke("Show",timePassFirstFireStart);
        }
        else {
            Invoke("Show",timePassFireStart);
        }
    }
    void Show(){
        Fire.SetActive(true);
        Invoke("Hide",timePassFireDuration);
    }
}
