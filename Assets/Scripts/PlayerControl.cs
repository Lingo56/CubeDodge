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
    public GameObject progressBar;
    public Transform leftTelepoint;
    public Transform midTelepoint;
    public Transform rightTelepoint;

    private string axis = "Horizontal";
    private float horizontalAxisInput;

    private void Start()
    {
        playerStats.playerCurrentHealth = playerStats.playerFullHealth;
        interactablesStats.interactableSpeed = interactablesStats.defaultInteractableSpeed;
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
        interactablesStats.interactableSpeed = interactablesStats.defaultInteractableSpeed;
        spawnControl.GetComponent<SpawnControl>().spawnRate = spawnControl.GetComponent<SpawnControl>().defaultSpawnRate;
        spawnControl.GetComponent<SpawnControl>().currentSpawnDifficulty = 0;
        spawnControl.GetComponent<SpawnControl>().DestroyAllEnemies();
        spawnControl.GetComponent<SpawnControl>().DestroyAllCollectables();
        overheatControl.GetComponent<OverheatControl>().overheatEnabled = false;
    }

    void MovePlayer()
    {
        if (horizontalAxisInput > 0) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, rightTelepoint.position, playerStats.speed);
        }
        if (horizontalAxisInput < 0) {
            player.transform.position = Vector3.MoveTowards(player.transform.position, leftTelepoint.position, playerStats.speed);
        }
        if (horizontalAxisInput == 0) {
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
}
