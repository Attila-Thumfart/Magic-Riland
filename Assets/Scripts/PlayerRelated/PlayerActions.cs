using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private bool IsOnField = false;
    GameObject CurrentField;
    GameObject CurrentItem;

    private void Start()
    {

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && IsOnField)
        {
            CurrentItem = FindObjectOfType<MySamplePlant>().gameObject;  //Later: first item in inventory
            SeedField();
        }
    }


  /*  private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.tag == "Field")
        {
            other.GetComponent<FieldManager>().SetIsSeeded(true);
        }
    } */

    private void OnTriggerEnter(Collider other)         //checks if the Player touches a Field
    {
        if (other.tag == "Field")
        {
            IsOnField = true;                           //sets the bool for it to true
            CurrentField = other.gameObject;            //references the current field; used for SeedField to know which field is seeded
        }
    }

    private void OnTriggerExit(Collider other)          //checks if the Player stops touching a field
    {
        if (other.tag == "Field")
        {
            IsOnField = false;                          //sets the bool for it to false
            CurrentField = null;                        //dereferences the current field
        }
    }

    void SeedField()                                    //Seeds the field and gives over the plants information
    {
        CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
        CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        
    }

}
