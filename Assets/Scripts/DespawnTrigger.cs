using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) {
            Destroy(collision.gameObject);
    }
}
