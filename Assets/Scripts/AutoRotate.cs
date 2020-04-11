using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public GameObject rotatedObject;
    public int rotationAmount = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotatedObject.transform.Rotate(0,rotationAmount,0);
    }
}
