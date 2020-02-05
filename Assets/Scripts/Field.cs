using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : Interactable
{
    Interactable CurrentField;
    GameObject CurrentItem;

    public override void Interact()
    {
        base.Interact();

        GameObject player = GameObject.Find("Player");
        PlayerActions playerActions = player.GetComponent<PlayerActions>();

        CurrentField = playerActions.focus;

        FieldAction();
    }

    void SeedField()                                    //Seeds the field and gives over the plants information
    {
        CurrentItem = GameObject.FindObjectOfType<MySamplePlant>().gameObject;

        CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
        CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        CurrentField.GetComponent<FieldManager>().SetMeshes(CurrentItem);
    }

    void HarvestField()                                 //Harvests the field the player is standing on
    {
        CurrentField.GetComponent<FieldManager>().ResetField();
    }

    void FieldAction()
    {
        if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.empty)         //if the field the player is standing on is empty
        {
            //and if there is a Plant in the scene (Later: if the first item in inventory is a seed)
            SeedField();                                                                                        //seeds the field
        }

        if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.finished)      //if the field the player is standing on has a grown up plant
        {
            HarvestField();                                                                                     //harvests the field
        }

        if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.withered)
        {
            HarvestField();
        }
    }
}
