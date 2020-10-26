using UnityEngine;

public class BulletFire : MonoBehaviour
{
    [Header("Animators")]
        [SerializeField] private Animator Gun;

    [Header("Particle Systems")]
        [SerializeField] private ParticleSystem particleSystem;

    [Header("Game Objects")]
        [SerializeField] private GameObject BulletOBJ;
        [SerializeField] private Transform BulletFirePosition;

    [Header("Scripts")]
        [SerializeField] private GmaeManager gameManager;

    
    public float BulletSpeed;
    private float time;
    private int layerMask = 1 << 9; // Obstacle layer
    public float FireDelay = 0;

   
    // Update is called once per frame
    void Update()
    {   
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && time >= FireDelay){

            particleSystem.Play();
            Gun.SetTrigger("Shoot");
            time = 0;

            FireBullet();
            RaycastHit raycast;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out raycast, Mathf.Infinity) )
            {
                HittingSystem hitSystem  = raycast.transform.GetComponent<HittingSystem>();
                if (hitSystem != null && hitSystem.tag.CompareTo("Obstacle") == 0){
                    gameManager.IncreaseScore();
                    hitSystem.Destroy();
                } 
            }
        }
    }

    private void FireBullet() {
            Vector3 ForceDirection = new Vector3();
            ForceDirection = Camera.main.transform.forward;
            ForceDirection *= BulletSpeed;
            Instantiate(BulletOBJ, BulletFirePosition.transform.position, transform.rotation).GetComponent<Rigidbody>().AddForce(ForceDirection, ForceMode.VelocityChange);
    }
}
