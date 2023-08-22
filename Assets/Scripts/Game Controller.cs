using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance = null;
    public string sceneName;
    private int _currentIndex;
    private List<GameObject> pool;
    public GameObject[] allCharacters;
    public GameObject[] characters;
        
    
    public int currentIndex
    {
        get {
            return _currentIndex;
        }
        set {
            _currentIndex = value;
        }
    }

    public void AddToPool(GameObject character)
    {
        character.SetActive(false);
        pool.Add(character);
    }

    public GameObject GetFromPool(string characterName)
    {
        foreach (GameObject g in pool)
        {
            if (g.name == characterName)
            {
                pool.Remove(g);
                g.SetActive(true);
                return g;
            }
        }

        foreach (GameObject g in allCharacters)
        {
            if (g.name == characterName)
            {
                GameObject newObject = Instantiate(g);
                newObject.name = g.name;
                return newObject;
            }
        }
        
        
        return null;
    }

    void Awake()
    {
       
        if (instance == null)
        {
            instance = this;
            pool = new List<GameObject>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        pool = new List<GameObject>();
        if (scene.name == "GamePlay")
        {
            GameController.instance.GetFromPool(characters[_currentIndex].name);
        }

		sceneName = scene.name;
    }
}
