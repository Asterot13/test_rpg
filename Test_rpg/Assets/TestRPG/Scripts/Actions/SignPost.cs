using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem {

    public string[] dialogue;

    public override void Interact()
    {
        DialogueSystem.instance.AddNewDialogue(dialogue, "Знак");
        Debug.Log("Interacting with sign post");
    }
}