using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_door : MonoBehaviour
{
    public string scene_name;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.LoadLevel(scene_name);
    }
}
