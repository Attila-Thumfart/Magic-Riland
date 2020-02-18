using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tulpe : MonoBehaviour
{
    [SerializeField]
    private Item TulpeItem;

    public Item GetItem()
    {
        return TulpeItem;
    }
}
