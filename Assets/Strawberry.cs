using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    [SerializeField]
    private Item StrawberryItem;

    public Item GetItem()
    {
        return StrawberryItem;
    }

}
