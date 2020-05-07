using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public Transform leftTelepoint;
    public Transform midTelepoint;
    public Transform rightTelepoint;

    private string axis = "Horizontal";
    private float horizontalAxisInput;
    public float speed = 0.01f;
    public float maxSpeed = 50;
    public float maxAcc = 10;
    public float decelerate = 10;
    public float forwardForce = 100;
    public float jumpSpeed = 100;
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
            gameManager.GetComponent<GameManager>().PlayerDeath();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.collider.tag == "Obsticle")
        {
            gameManager.GetComponent<GameManager>().PlayerDeath();
        }
    }

    void MovePlayer()
    {
        if (horizontalAxisInput > 0) {
            //SpeedControl(rightTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, rightTelepoint.position, speed);
        }
        if (horizontalAxisInput < 0) {
            //SpeedControl(leftTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, leftTelepoint.position, speed);
        }
        if (horizontalAxisInput == 0) {
            //SpeedControl(midTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, midTelepoint.position, speed);
        }
    }

    void SpeedControl(Transform targetLocation)
    {
        float deltaX = Vector3.Distance(targetLocation.position, player.transform.position);

        float distance = (float)System.Math.Sqrt(deltaX * deltaX);

        float dvx = deltaX * maxSpeed / distance; //Normalizing and multiplying by max speed
        deltaX = dvx - speed;
        float diffSize = (float)System.Math.Sqrt(deltaX * deltaX);
        float ax = maxAcc * deltaX / diffSize;

        speed += ax * Time.deltaTime; // dt is the time that passed since the last frame
    }
}
