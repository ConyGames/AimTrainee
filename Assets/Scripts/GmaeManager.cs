using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GmaeManager : MonoBehaviour
{
    private AudioHighPassFilter audioHighPassFilter;
    private int PlayerScore = 0;

    [Header("Game Objects")]
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject SettignsMenu;

    [Header("Scripts")]
    [SerializeField] private PlayerLook playerLook;
    [SerializeField] private BulletFire bulletFire;
    [SerializeField] private LaunchObstacle launchObstacles;
    [SerializeField] private PlayerMovement playerMovemnt;

    [Header("Settings Variables")]
        public Slider obtacleDelaySlider;
        public Toggle SlowOnJump;

    [Header("ScoreManager")]
        public Text hitCountText;

    [Header("Manager Variables")]
        public bool GamePaused = false;
        public bool SettingsMenuOn = false;

    private void Start()
    {
        PauseMenu = GameObject.Find("PauseMenu");
        PauseMenu.SetActive(false);
        SettignsMenu.SetActive(false);
        audioHighPassFilter = gameObject.GetComponent<AudioHighPassFilter>();
        audioHighPassFilter.cutoffFrequency = 10;
        obtacleDelaySlider.SetValueWithoutNotify(0.7f);
        hitCountText.text = "0";
    }

    public void Resume(){
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GamePaused = false;
        PauseMenu.SetActive(false);
        playerLook.enabled = true;
        bulletFire.enabled = true;
        audioHighPassFilter.cutoffFrequency = 10;
    }

    // Method to launch the settings Panel
    public void Settings(){
        PauseMenu.SetActive(false);
        SettignsMenu.SetActive(true);
        SettingsMenuOn = true;
    }

    // Settings Menu back Button
    public void SettingsMenuBack(){
        PauseMenu.SetActive(true);
        SettignsMenu.SetActive(false);
        SettingsMenuOn = false;
    }

    public void Exit(){
        Application.Quit(); // quiting the application
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0); // loading first scene in build index which in main menu
    }

     public void ObstacleSpeedChange(){
        launchObstacles.launchDelay = obtacleDelaySlider.value;
    }

    public void SlowOnJumpToggle(){
        playerMovemnt.SlowOnJump = this.SlowOnJump.isOn;
    }

    private void Update()
    {
        PauseMenuFunctions();
        // ObstacleSpeedChange();
    }

   
    private void PauseMenuFunctions(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (SettingsMenuOn){
                SettingsMenuBack();
            }
            else if (GamePaused){
                Resume();
            }else {
                Pause();
            }
        }
    }

    private void Pause(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        playerLook.enabled = false;
        bulletFire.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        audioHighPassFilter.cutoffFrequency = 7000;
    }

    public void IncreaseScore(){
        PlayerScore++;
        hitCountText.text = PlayerScore.ToString();
    }
}
