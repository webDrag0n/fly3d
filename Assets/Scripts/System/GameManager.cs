using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float total_memory = 100f;
    public float memory_left=100f;
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

    public void OpenEntityMemory(Entity entity)
    {

    }

}
