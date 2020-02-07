
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

    private void Start()
    {
        //ThisGameObject = this.gameObject;
        GM = GameManager.GMInstance;                                    //finds the GM
        Player = GameObject.FindGameObjectWithTag("Player");            //finds the Player
    }
}
