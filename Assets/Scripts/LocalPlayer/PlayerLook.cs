using UnityEngine;


public class PlayerLook : MonoBehaviour
{
    
    private Vector2 MouseMovement = new Vector2();
    private Vector2 temp = new Vector2();
    private GameObject LocalPlayer;

    public float MouseSensitivity = 1;
    
    void Start()
    {
        LocalPlayer = GameObject.Find("LocalPlayer");
    }
    // Update is called once per frame
    void Update()
    {
        if (LocalPlayer == null)
            return;

        GetMouseMovement();
        SetLocalPlayerRotation();
    
        Camera.main.transform.eulerAngles = MouseMovement;
    }

    private void GetMouseMovement(){
        MouseMovement = Camera.main.transform.eulerAngles;
        MouseMovement.y += Input.GetAxis("Mouse X") * MouseSensitivity;
        MouseMovement.x -= Input.GetAxis("Mouse Y") * MouseSensitivity;
    }

    private void SetLocalPlayerRotation(){
        temp.Set(LocalPlayer.transform.eulerAngles.x, MouseMovement.y);
        LocalPlayer.transform.eulerAngles = temp;
    }
}
