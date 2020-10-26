using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour
{
    public float BulletSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += BulletSpeed * transform.forward;
    }
}
