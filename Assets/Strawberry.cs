using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    [SerializeField]
    private Item StrawberryItem;
    
    void Start()
    {

    }

    public Item GetItem()
    {
        return StrawberryItem;
    }

}
