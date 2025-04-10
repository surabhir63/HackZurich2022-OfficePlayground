using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.ComponentModel;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public int score = 10;

    Vector2 direction;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    Animator animator;
    List<RaycastHit2D> collisions = new List<RaycastHit2D>();

    private GameObject[] fires;
    private float fireTimer = 0f;
    private GameObject fireAlarm; 
    private bool safe = true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fireAlarm = GameObject.FindGameObjectsWithTag("Fire Alarm")[0];
    }

    private void FixedUpdate() {
        if(direction != Vector2.zero){
            bool canMove = CanMove(direction);
            if(!canMove) {
                canMove = CanMove(new Vector2(direction.x, 0));
            }
            if(!canMove) {
                canMove = CanMove(new Vector2(0, direction.y));
            }
            animator.SetBool("isMoving", canMove);
        } else {
            animator.SetBool("isMoving", false);
        }

        if(direction.x < 0) {
            spriteRenderer.flipX = true;
        } else if (direction.x > 0) {
            spriteRenderer.flipX = false;
        }

        HandleFire();
    }

    private bool CanMove(Vector2 vector2) {
        if(vector2 == Vector2.zero) {
            return false;
        }
        int count = rigidBody.Cast(vector2, movementFilter, collisions, speed * Time.fixedDeltaTime + collisionOffset);
        if(count == 0){
            rigidBody.MovePosition(rigidBody.position + vector2 * speed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
        
    }

    private void HandleFire(){
        fires = GameObject.FindGameObjectsWithTag("Fire");
        if(fires.Length > 0) {
            // print(this.GetComponent<Transform>().position);
            safe = inSafeZone();
            fireTimer += Time.deltaTime;
            FireAlarmStart(fireTimer);
        }
        else {
            fireTimer = 0;
            FireAlarmStop();
            safe = true;
        }
        if(fireTimer > 30 && !safe) {
            score -= 15;
            // print(score);
        }
    }

    private void FireAlarmStart(float timer){
        if(Math.Floor(timer)%2 == 1) {
            fireAlarm.SetActive(true);
        }
        else {
            fireAlarm.SetActive(false);
        }
    }

    private bool inSafeZone(){
        if(Math.Abs(this.GetComponent<Transform>().position.x) > 2 && Math.Abs(this.GetComponent<Transform>().position.y) > 1) {
            // print("SAFE");
            return true;
        }
        else {
            return false;
        }
    }

    private void FireAlarmStop(){
        fireAlarm.SetActive(false);
    }

    void OnMove(InputValue input) {
        direction = input.Get<Vector2>();
    }
}
