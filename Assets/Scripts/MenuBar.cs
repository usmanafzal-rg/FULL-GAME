using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuBar : MonoBehaviour
{

    public void HomeButton()
    {
        if (GameController.instance)
        {
            if (GameController.instance.sceneName == "GamePlay")
            {
                SceneManager.LoadScene("Main Menu");
            }
            
        }
    }
    
    public void RestartButton()
    {
        if (GameController.instance)
        {
            if (GameController.instance.sceneName == "GamePlay")
            {
                SceneManager.LoadScene("GamePlay");
            }
            
        }
    }
}
