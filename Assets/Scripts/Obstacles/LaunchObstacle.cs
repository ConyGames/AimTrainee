using UnityEngine;
using System.Collections.Generic;

public class LaunchObstacle : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject Obstacle;
    public GameObject ObjectShootTo;

    [Header("Variables")]
    public float ForceObstacleFire;
    [Range(0.01f, 1)] public float launchDelay = 0.01f;

    [Header("launch Areas")]
    public List<GameObject> Launchers = new List<GameObject>();


    private int LaunchersSize = 0;
    private float time;

    private System.Random random = new System.Random();

    private void Start()
    {
        LaunchersSize = Launchers.Count;
    }
    private void Update()
    {
        time += Time.deltaTime;

        if (time >= launchDelay){
            time = 0;
            int objectNumber = random.Next(0, LaunchersSize);
            if (Launchers[objectNumber] != null){
                GameObject tempOBJ = Launchers[objectNumber];
                tempOBJ.transform.LookAt(ObjectShootTo.transform.position, Vector3.up);
                Instantiate(Obstacle, tempOBJ.transform.position, tempOBJ.transform.rotation).GetComponent<Rigidbody>().AddForce(tempOBJ.transform.forward * ForceObstacleFire, ForceMode.VelocityChange);
            }
        }
    }
}
