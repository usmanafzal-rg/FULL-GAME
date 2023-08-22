using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveForce = 10f;
    public float jumpForce = 11f;
    private float movementX = 0f;
    private bool isGrounded = false;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_LABEL = "Ground";
    private string ENEMY_LABEL = "Enemy";
    private Animator anim;
    private Rigidbody2D rig;
    private SpriteRenderer sr;
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        AnimatePlayer();
        PlayerJump();
    }

    void MovePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f) * moveForce * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
        
        if (movementX > 0 || movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
        }

    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(GROUND_LABEL))
        {
            isGrounded = true;
        }
        
        if (other.gameObject.CompareTag(ENEMY_LABEL))
        {
            GameObject camera = GameObject.Find("Camera");
            camera.GetComponent<MoveCamera>().player = null;
            GameController.instance.AddToPool(gameObject);
            //GameObject.Destroy(gameObject);
            //SceneManager.LoadScene("Main Menu");
        }
    }
}
