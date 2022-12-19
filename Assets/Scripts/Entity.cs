using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //public bool grabable = false;
    //public bool interactable = true;
    public string entity_name;
    public string description;
    public string pick_up_text;
    public string thrown_away_text;
    public float memory_weight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {

    }

    public void OnPickUp()
    {
        NarrativeManager.instance.PushLine(entity_name, pick_up_text, 5f);
    }

    public void OnThrownAway()
    {
        NarrativeManager.instance.PushLine(entity_name, thrown_away_text, 5f);
        GameManager.instance.memory_left -= memory_weight;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Out_door")
        {
            OnThrownAway();
        }
    }
}
