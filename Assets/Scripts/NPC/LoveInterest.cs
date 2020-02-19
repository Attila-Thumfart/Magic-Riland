using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoveInterest : Interactable
{
    [SerializeField]
    private NPC FemaleLove;

    public override void Interact()
    {
        base.Interact();
        Debug.Log("Start Conversation");
    }

}
