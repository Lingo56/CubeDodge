using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAnimation : MonoBehaviour
{
    Animator collectableAnim;

    // Start is called before the first frame update
    void Start()
    {
        collectableAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Player"))
        {
            Debug.Log("Detected Player");
            collectableAnim.SetBool("isCollected", true);
        }
    }
}
