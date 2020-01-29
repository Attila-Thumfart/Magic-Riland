using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private bool IsOnField = false;
    private bool TouchesBed = false;
    private GameObject CurrentField;
    private GameObject CurrentItem;

    public GameObject Player;


    private void Start()
    {
        Player = this.gameObject;
    }

    private void Update()
    {
        FieldAction();
        EndDay();
    }

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded
        }

        else if (other.name == "Bed")
        {
            TouchesBed = true;
        }
    }

    private void OnTriggerExit(Collider other)          //checks if the Player stops touching a field
    {
        if (other.tag == "Field")
        {
            IsOnField = false;                          //sets the bool for it to false
            CurrentField = null;                        //dereferences the current field 
        }

        else if (other.name == "Bed")
        {
            TouchesBed = false;
        }
    }

    void SeedField()                                    //Seeds the field and gives over the plants information
    {
        CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
        CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
    }

    void HarvestField()                                 //Harvests the field the player is standing on
    {
        CurrentField.GetComponent<FieldManager>().ResetField();
    }

    void FieldAction()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsOnField)
        {
            if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.empty)         //if the field the player is standing on is empty
            {
                CurrentItem = FindObjectOfType<MySamplePlant>().gameObject;                                         //and if there is a Plant in the scene (Later: if the first item in inventory is a seed)
                SeedField();                                                                                        //seeds the field
            }

            if (CurrentField.GetComponent<FieldManager>().GetFieldstate() == FieldManager.Fieldstate.finished)      //if the field the player is standing on has a grown up plant
            {
                HarvestField();                                                                                     //harvests the field
            }
        }
    }

    void EndDay()
    {
        if(TouchesBed && Input.GetKeyDown(KeyCode.E))           //if the player touches the Bed and presses "E"
        {
            GameManager.GMInstance.IncrementCalenderDay();      //end the day 
            GetComponent<PlayerMovement>().enabled = false;
        }
    }

    public void EnableMovement()
    {
        GetComponent<PlayerMovement>().enabled = true;
    }
}
