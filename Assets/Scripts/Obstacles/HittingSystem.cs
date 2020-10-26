using UnityEngine;

public class HittingSystem : MonoBehaviour
{   

    public GameObject BlastSound;
    public GameObject Blast;
    public void Destroy(){
        Instantiate(BlastSound, transform.position, transform.rotation);
        BlastSimulation();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other){
        if ( other.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }
    }

    private void BlastSimulation(){
        Instantiate(Blast, transform.position, Quaternion.identity);
    }
}
