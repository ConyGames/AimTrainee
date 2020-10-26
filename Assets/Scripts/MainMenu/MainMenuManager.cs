using UnityEngine;
using UnityEngine.SceneManagement;

/* 
  Script to manage main menu mainly for buttons
 */
public class MainMenuManager : MonoBehaviour
{
    public void PlayButton(){
        // load The Game;
        int BuidIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Play");
        if ( SceneManager.GetSceneByBuildIndex(BuidIndex +1) != null) {
            SceneManager.LoadScene( BuidIndex + 1);
        }else {
            Debug.Log("Scence Not Active");
        }
    }

    public void ExitButton(){
        // Exit The application
        Application.Quit();
    }
}
