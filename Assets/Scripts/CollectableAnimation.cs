using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    public Animator collectableAnim;
    public Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
            collectableAnim.SetBool("isCollected", true);
            Debug.Log("Collision");
        }
    }
}
