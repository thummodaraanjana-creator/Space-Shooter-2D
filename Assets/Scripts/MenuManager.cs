using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    void Start()
    {

    }//start


    void Update()
    {
        
    }//update

    public void PlayGame()
    {
        SceneManager.LoadScene("Level0");

    }//play game button loads level 0 scene

    public void QuitGame()
    {
        Application.Quit();
        print("Quit Game");
    }//quit game button quits the application

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }//load main menu button loads the main menu scene

    public void RestartButton()
    {
        SceneManager.LoadScene("Level0");

    }//restart button loads level 0 scene
}//class
