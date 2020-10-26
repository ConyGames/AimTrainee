using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [Header("Animators")]
        [SerializeField] private Animator GunAnimation;
        [SerializeField] private Animator CameraAnimation;

    public void PlayerRun(bool Run){
        GunAnimation.SetBool("Running", Run);
        CameraAnimation.SetBool("Running", Run);
    }

    public void PlayerJump(bool jump){
        GunAnimation.SetBool("Jump", jump);
    }

    public void PlayerWalk(bool walk){
        CameraAnimation.SetBool("Walking", walk);
    }

    public void PlayerEndJump(bool endjump){
        GunAnimation.SetBool("JumpEnd", endjump);
        CameraAnimation.SetBool("JumpEnd", endjump);
    }
    
}
