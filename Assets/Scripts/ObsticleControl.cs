using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleControl : MonoBehaviour
{
    public GameObject obsticle;
    public CharacterController cc;
    public int rotationAmount = 5;
    private Vector3 moveDirection = Vector3.zero;
    public float speed = 1;
    public float forwardForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        obsticleMovement();
    }

    void obsticleMovement() {
        moveDirection = new Vector3(0.0f, 0.0f, -forwardForce);
        moveDirection *= speed;

        cc.Move(moveDirection * Time.deltaTime);

        obsticle.transform.Rotate(0, rotationAmount, 0);
    }
}
