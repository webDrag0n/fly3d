using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // singleton
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(string scene_name)
    {
        SceneManager.LoadSceneAsync(scene_name, LoadSceneMode.Additive);
    }
}
