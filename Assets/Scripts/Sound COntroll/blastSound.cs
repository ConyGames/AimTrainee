using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blastSound : MonoBehaviour
{
    private AudioSource blast;
    // Start is called before the first frame update
    void Start()
    {
        blast = gameObject.GetComponent<AudioSource>();
        blast.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!blast.isPlaying){
            Destroy(gameObject);
        }
    }
}
