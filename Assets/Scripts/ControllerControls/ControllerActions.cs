using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerActions : MonoBehaviour
{
    private bool IsOnField = false;
    GameObject CurrentField;
    GameObject CurrentItem;

    PlayerControls controls; // This is where the Controls and actual Input are saved (via Unity Input System)

    private void Awake()
    {
        controls.Gameplay.Interact.performed += ctx => SeedField();
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
        if (IsOnField)
        {
            CurrentItem = FindObjectOfType<MySamplePlant>().gameObject;  //Later: first item in inventory

            CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
            CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        }
    }

    private void OnEnable() // This function enables the controls when the object becomes enabled and active
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable() // This function disables the controls when the object becomes disabled or inactive
    {
        controls.Gameplay.Disable();
    }
}
