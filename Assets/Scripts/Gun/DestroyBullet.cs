using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        if (other.collider.tag != "Player")
            Destroy(gameObject);
    }
}
