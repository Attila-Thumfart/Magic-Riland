
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 1.55f;
    public Transform interactionTransform;

    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public Interactable currentFocus;

    GameObject ThisGameObject;

    private void Start()
    {
        ThisGameObject = this.gameObject;
    }

    public GameObject GetGameObject()
    {
        return ThisGameObject;
    }

    public virtual void Interact()
    {
        // This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }



    public void OnFocused(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        Interact();
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    public Interactable GetCurrentFocus(Interactable targetFocus)
    {
        currentFocus = targetFocus;
        return currentFocus;
    }

    private void OnDrawGizmosSelected()
    {
        if(interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
