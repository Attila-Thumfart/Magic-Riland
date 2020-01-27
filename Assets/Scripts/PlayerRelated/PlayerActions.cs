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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Field")
        {
            IsOnField = true;
            CurrentField = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Field")
        {
            IsOnField = false;
            CurrentField = null;
        }
    }

    void SeedField()
    {
        CurrentField.GetComponent<FieldManager>().SetIsSeeded(true);
        CurrentField.GetComponent<FieldManager>().SetGrowthrates(CurrentItem);
        
    }

}
