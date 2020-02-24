using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyFields : MonoBehaviour
{
    public static GameObject InstanceOfObject;

    public void Awake()
    {
        if (InstanceOfObject != null)
        {
            Destroy(gameObject);
            return;
        }
        InstanceOfObject = gameObject;

        DontDestroyOnLoad(this);
    }

    public void CheckActiveScene(string _TargetScene)
    {
        if (_TargetScene == "Farm")
        {
            InstanceOfObject.transform.GetChild(0).gameObject.SetActive(true);
            InstanceOfObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            InstanceOfObject.transform.GetChild(0).gameObject.SetActive(false);
            InstanceOfObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
