using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    private string[] sentences;
    bool endSent, endMsg, nextSent;
    public GameObject textBox;
    Text CharName, MessengerText;
    public Image background;
    public List<Dialogue> dialogue;
    int sentencesCount;

    // Use this for initialization
    void Start() {
    }

    public void startMessenger()
    {
        // create empty conversation chat       
        Vector3 spawnTemp = background.GetComponent<Collider2D>().bounds.max;
        Debug.Log(spawnTemp);
        GameObject myTextbox = Instantiate(textBox, spawnTemp, Quaternion.identity) as GameObject;

        myTextbox.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform, false);

        background = myTextbox.transform.GetChild(0).gameObject.GetComponent<Image>();
        CharName = myTextbox.transform.GetChild(1).gameObject.GetComponent<Text>();
        MessengerText = myTextbox.transform.GetChild(2).gameObject.GetComponent<Text>();
        
    }

    void startMessage(List<Dialogue> dialogue)
    {
        CharName.text = dialogue[sentencesCount].name;
        MessengerText.text = dialogue[sentencesCount].messages;

        // force update canvas to count the line for the text box.
        Canvas.ForceUpdateCanvases();
        Debug.Log(MessengerText.cachedTextGenerator.lineCount);

        if (dialogue[sentencesCount].right)
        {
            CharName.alignment = TextAnchor.MiddleRight;
            MessengerText.alignment = TextAnchor.MiddleRight;
        }
        else
        {
            CharName.alignment = TextAnchor.MiddleLeft;
            MessengerText.alignment = TextAnchor.MiddleRight;
        }



        textSize(MessengerText.cachedTextGenerator.lineCount, MessengerText);
        StartCoroutine(textTyping(dialogue[sentencesCount].messages));
    }

    IEnumerator textTyping(string input)
    {
        MessengerText.text = "";
        foreach (char letter in input.ToCharArray())
        {
            MessengerText.text += letter;
            endMsg = true;
            yield return null;
        }
    }

    void textSize(int line, Text input)
    {
        input.rectTransform.sizeDelta = new Vector2(input.rectTransform.sizeDelta.x, input.rectTransform.sizeDelta.y + (line * 20));
        background.rectTransform.sizeDelta = new Vector2(background.rectTransform.sizeDelta.x, background.rectTransform.sizeDelta.y + (line * 20));
        CharName.rectTransform.position = new Vector2(CharName.rectTransform.position.x, CharName.rectTransform.position.y + (line * 12));
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (sentencesCount >= dialogue.Count - 1) Debug.Log("end of conversation");
            else
            {
                sentencesCount++;
                startMessenger();
                startMessage(dialogue);
                nextSent = true;
            }
        }
        else nextSent = false;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            startMessenger();
            startMessage(dialogue);
        }
	}
}
