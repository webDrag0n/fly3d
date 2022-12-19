using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadSceneAsync(1);
    }
}

