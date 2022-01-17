using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float velX, speed = 3f;
    //
    public float jumpVal;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.LeftShift))
            speed = 5f;
        else
            speed = 3f;
        
        AnimationState();
        //jump
        if(CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpVal);


        transform.Translate(CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime, 0f,0f);
        velX = CrossPlatformInputManager.GetAxisRaw("Horizontal") * speed;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (velX, rb.velocity.y);
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }
    void CheckWhereToFace()
    {
        Vector3 localScale = transform.localScale;
        if(velX < 0){
            localScale.x = -1;
        }else if(velX > 0){
            localScale.x = 1;
        }

        transform.localScale = localScale;
        
    }
    void AnimationState()
    {
        if (velX == 0){
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        if(rb.velocity.y == 0){
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        //
        if (Mathf.Abs(velX) == 3 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        if (Mathf.Abs(velX) == 5 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if(rb.velocity.y > 0)
            anim.SetBool("isJumping", true);
        if(rb.velocity.y < 0){
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
