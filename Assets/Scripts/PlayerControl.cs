using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController cc;
    public GameObject player;
    public GameObject gameManager;
    public string axis;
    public float speed = 100;
    public float forwardForce = 100;
    public float jumpSpeed = 100;
    private float horizontalAxisInput;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Updates with the physics engine
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxisInput = Input.GetAxisRaw(axis);

        if (player.transform.position.y < -1)
        {
            cc.enabled = false;
            gameManager.GetComponent<GameManager>().PlayerDeath();
            cc.enabled = true;
        }
    }

    void MovePlayer()
    {
        if (cc.isGrounded)
        {
            moveDirection = new Vector3(horizontalAxisInput, 0.0f, forwardForce);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.collider.tag == "Obsticle")
        {
            cc.enabled = false;
            gameManager.GetComponent<GameManager>().PlayerDeath();
            cc.enabled = true;
        }
    }
}
