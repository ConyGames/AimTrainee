using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollitionDetection : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [Header("Scripts")]
        [SerializeField] private PlayerAnimation playerAnimation;

    void Start()
    {
        playerMovement = GameObject.Find("LocalPlayer").GetComponent<PlayerMovement>();
        playerAnimation = gameObject.GetComponent<PlayerAnimation>();
    }  
    
    void OnCollisionStay(Collision collitionInfo)
    {
        if ( !playerMovement.CanJump )
            playerMovement.CanJump = true;
    }

    
    private void OnCollisionExit(Collision other)
    {
        playerMovement.CanJump = false;
        switch(other.collider.tag){
            case "Ground" :
            case "Floor" :
                playerAnimation.PlayerEndJump(false);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter(Collision other){
        playerAnimation.PlayerJump(false);
        switch(other.collider.tag){
            case "Ground" :
            case "Floor" :
                playerAnimation.PlayerEndJump(true);
                if (playerMovement.SlowOnJump)
                    playerMovement.mainMusic.pitch = Time.timeScale = 1f;
                break;
            default:
                break;
        }
    }

}
