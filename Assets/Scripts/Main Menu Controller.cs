using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenuController : MonoBehaviour
{
    public void PlayGames(int index)
    {
    }

    public void PlayGame()
    {
        int buttonIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        GameController.instance.currentIndex = buttonIndex;
        SceneManager.LoadScene("GamePlay");
    }
    
}
