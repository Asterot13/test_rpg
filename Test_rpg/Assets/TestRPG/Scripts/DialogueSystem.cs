using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

	public static DialogueSystem instance { get; set; }
    public List<string> DialogueLines = new List<string>();
    public GameObject DialoguePanel;
    public string npcName;

    Button continueButton;
    Text DialogueText, nameText;
    int dialogueIndex;

    void Awake()
    {
        continueButton = DialoguePanel.transform.Find("Continue").GetComponent<Button>();
        DialogueText = DialoguePanel.transform.Find("DialogText").GetComponent<Text>();
        nameText = DialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();

        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });

        DialoguePanel.SetActive(false);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void AddNewDialogue(string[] lines, string name)
    {
        dialogueIndex = 0;
        DialogueLines = new List<string>(lines.Length);
        DialogueLines.AddRange(lines);
        this.npcName = name;
        CreateDialogue();
    }

    public void CreateDialogue()
    {
        DialogueText.text = DialogueLines[dialogueIndex];
        nameText.text = npcName;
        DialoguePanel.SetActive(true);
    }

    public void ContinueDialogue()
    {
        if (dialogueIndex < DialogueLines.Count - 1)
        {
            dialogueIndex++;
            DialogueText.text = DialogueLines[dialogueIndex];
        }
        else
        {
            DialoguePanel.SetActive(false);
        }
    }
}
