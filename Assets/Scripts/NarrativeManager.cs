using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueLine
{
    public string title;
    public string content;
    public float time_out;

    public DialogueLine(string _title, string _content, float _time_out)
    {
        title = _title;
        content = _content;
        time_out = _time_out;
    }
}

public class NarrativeManager : MonoBehaviour
{
    public static NarrativeManager instance;

    public GameObject background;
    public GameObject text;
    public GameObject title_text;

    private Queue<DialogueLine> dialogueLines = new Queue<DialogueLine>();

    public float time_out;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            // singleton
            instance = this;
        }
        PushLine("Tutorial", "Press WASD to move, Left mouse button to interact, right mouse button to pickup", 10f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (time_out >= 0.1f)
        {
            time_out -= Time.fixedDeltaTime;
        }
        else
        {
            if (dialogueLines.Count > 0)
            {
                DialogueLine new_line = dialogueLines.Dequeue();
                ShowNarrative(new_line.title, new_line.content, new_line.time_out);
            }
            else
            {
                HideNarrative();
            }
        }
    }

    public void PushLine(string title, string content, float time_out)
    {
        dialogueLines.Enqueue(new DialogueLine( title, content, time_out ));
    }

    public void HideNarrative()
    {
        time_out = 0f;
        title_text.GetComponent<TMP_Text>().text = "";
        text.GetComponent<TMP_Text>().text = "";
        background.SetActive(false);
        title_text.SetActive(false);
        text.SetActive(false);
    }

    public void ShowNarrative(string title, string content, float _time_out)
    {
        time_out = _time_out;
        background.SetActive(true);
        title_text.SetActive(true);
        title_text.GetComponent<TMP_Text>().text = title;
        text.SetActive(true);
        text.GetComponent<TMP_Text>().text = content;
    }
}
