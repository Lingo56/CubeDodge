using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    public PlayerStats playerStats;
    public InteractablesStats interactablesStats;
    public GameObject player;
    public GameObject scoreControl;
    public GameObject spawnControl;
    public GameObject overheatControl;
    public GameObject cooldownControl;
    public Transform leftTelepoint;
    public Transform midTelepoint;
    public Transform rightTelepoint;

    private string axis = "Horizontal";
    private float horizontalAxisInput;

    private void Start()
    {
        playerStats.playerCurrentHealth = playerStats.playerFullHealth;
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
            HealthDown();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Obsticle")
        {
            HealthDown();

        }
        if (collision.gameObject.tag == "Collectable")
        {
            playerStats.score++;
            overheatControl.GetComponent<OverheatControl>().overheatEnabled = true;
        }
    }

    public void HealthDown()
    {
        playerStats.playerCurrentHealth--;

        if (playerStats.playerCurrentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        playerStats.score = 0;
        playerStats.playerCurrentHealth = playerStats.playerFullHealth;
        spawnControl.GetComponent<SpawnControl>().DestroyAllEnemies();
        overheatControl.GetComponent<OverheatControl>().overheatEnabled = false;
    }

    void MovePlayer()
    {
        if (horizontalAxisInput > 0) {
            //SpeedControl(rightTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, rightTelepoint.position, playerStats.speed);
        }
        if (horizontalAxisInput < 0) {
            //SpeedControl(leftTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, leftTelepoint.position, playerStats.speed);
        }
        if (horizontalAxisInput == 0) {
            //SpeedControl(midTelepoint);
            player.transform.position = Vector3.MoveTowards(player.transform.position, midTelepoint.position, playerStats.speed);
        }
        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            cooldownControl.GetComponent<CooldownControl>().statsSet = false;
            cooldownControl.GetComponent<CooldownControl>().cooldownEnabled = true;
        }
        if (CrossPlatformInputManager.GetButtonUp("Jump"))
        {
            cooldownControl.GetComponent<CooldownControl>().cooldownEnabled = false;
            cooldownControl.GetComponent<CooldownControl>().ResetStats();
        }
    }

    void SpeedControl(Transform targetLocation)
    {
        float deltaX = Vector3.Distance(targetLocation.position, player.transform.position);

        float distance = (float)System.Math.Sqrt(deltaX * deltaX);

        float dvx = deltaX * playerStats.maxSpeed / distance; //Normalizing and multiplying by max speed
        deltaX = dvx - playerStats.speed;
        float diffSize = (float)System.Math.Sqrt(deltaX * deltaX);
        float ax = playerStats.maxAcc * deltaX / diffSize;

        playerStats.speed += ax * Time.deltaTime; // dt is the time that passed since the last frame
    }
}
