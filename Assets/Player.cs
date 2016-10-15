using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{

    public enum ProjectAxis { onlyX = 0, xAndY = 1 };
    public ProjectAxis projectAxis = ProjectAxis.onlyX;
    public float speed = 150;
    public float addForce = 15;
    public bool lookAtCursor;
    public KeyCode leftButton = KeyCode.A;
    public KeyCode rightButton = KeyCode.D;
    public KeyCode upButton = KeyCode.W;
    public KeyCode downButton = KeyCode.S;
    public KeyCode spaceButton = KeyCode.Space;
    public bool isFacingRight = true;
    public bool canJumpTwice = true;
    public int jumpCnt = 2;

    private int curJump;
    private Vector3 direction;
    private float vertical;
    private float horizontal;
    private Rigidbody2D body;
    private float rotationY;
    private bool canJump;
    private bool spacePressed;
    private Animator animator;
    private bool animPlaying;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        body.fixedAngle = true;
        canJump = spacePressed = animPlaying = false;
        jumpCnt--;
        curJump = 0;
        

        if (projectAxis == ProjectAxis.xAndY)
        {
            body.gravityScale = 0;
            body.drag = 10;
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 10;
            curJump = 0;
            canJump = true;
         }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.transform.tag == "Ground")
        {
            body.drag = 0;
        }
    }

    void FixedUpdate()
    {

        body.AddForce(direction * body.mass * speed);

        if (Mathf.Abs(body.velocity.x) > speed / 100f)
        {
            body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * speed / 100f, body.velocity.y);
        }

        if (projectAxis == ProjectAxis.xAndY)
        {
            if (Mathf.Abs(body.velocity.y) > speed / 100f)
            {
                body.velocity = new Vector2(body.velocity.x, Mathf.Sign(body.velocity.y) * speed / 100f);
            }
        }
        else
        {
            if(!spacePressed)
            {
                if (Input.GetKey(spaceButton))
                {
                    spacePressed = true;

                    if (canJump)
                    {
                        curJump++;
                        if (curJump == jumpCnt)
                            canJump = false;
                        body.velocity = new Vector2(0, addForce);
                    }
                }
            }
        }
    }

    void Flip()
    {
        if (projectAxis == ProjectAxis.onlyX)
        {
            isFacingRight = !isFacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void Update()
    {
        if (spacePressed)
            spacePressed = !Input.GetKeyUp(spaceButton);

        if (lookAtCursor)
        {
            Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            lookPos = lookPos - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        vertical = 0;

        if (Input.GetKey(leftButton))
            horizontal = -1;
        else if (Input.GetKey(rightButton))
            horizontal = 1;
        else
            horizontal = 0;

        direction = new Vector2(horizontal, vertical);

        if(horizontal == 0)
           animator.StartPlayback();
        else
           animator.StopPlayback();
        
        if ((horizontal > 0 && !isFacingRight) || (horizontal < 0 && isFacingRight))
            Flip();
    }
}
