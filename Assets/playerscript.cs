using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] images;
    private static int ind = -1;
    private bool played = false;
    

    private void Start(){
        spriteRenderer.sprite = null;
    }
    private void OnMouseDown() {
        if(played) {
            return;
        }
        ind++;
        spriteRenderer.sprite = images[ind%2];
        played = true;
    }
    
    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
