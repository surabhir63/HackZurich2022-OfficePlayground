using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SideCharacterMovement : MonoBehaviour
{
    public float speed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private float time = 0.0f;
    public float randomMovementCooldownPeriod = 4.5f;
    private float[] speeds = {-0.70f,-0.5f,0.5f,0.65f};

    Vector2 direction = new Vector2(-0.5f,0);
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidBody;
    Animator animator;
    List<RaycastHit2D> collisions = new List<RaycastHit2D>();

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
        time += Time.deltaTime;
 
        if (time >= randomMovementCooldownPeriod) {
            time = 0.0f;
            int a = Random.Range(0,2), b = Random.Range(0,speeds.Length);
            if(a>=1) {
                direction = new Vector2(speeds[b],0);
            }
            else {
                direction = new Vector2(0,speeds[b]);
            }
        }
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
        
    }

    private bool CanMove(Vector2 vector2) {
        if(vector2 != Vector2.zero) {
            int count = rigidBody.Cast(vector2, movementFilter, collisions, speed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0){
                rigidBody.MovePosition(rigidBody.position + vector2 * speed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
        
    }
}
