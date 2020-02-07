
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject Player;
    public GameManager GM;

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    public virtual void Awake() // Override in all child classes and use base.Awake() at the top to use this first
    {
        //ThisGameObject = this.gameObject;
        GM = GameManager.GMInstance;                                    //finds the GM
        Player = GameObject.FindGameObjectWithTag("Player");            //finds the Player
    }

    public virtual void Start()
    {
        // Override in all child classes and use base.Start() at the top to use this first
    }
}
