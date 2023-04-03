using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//GAME MENU
public class MainMenu : MonoBehaviour
{
    //function for the level selection
    public void PlayLevel1()
    {
        //load the scene with index 0(menu scene)+1(level 1 scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayLevel2()
    {
        //load the scene with index 0(menu scene)+2(level 2 scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayLevel3()
    {
        //load the scene with index 0(menu scene)+3(level 3 scene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //function to close the game
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
