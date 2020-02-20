using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(GetComponent<PlayerMovement>().GetCharacterSpeed()) * 10);
        animator.SetBool("Zaubern", GetComponent<PlayerActions>().Channeling());
    }

    public void SetAction()
    {
        animator.SetTrigger("nehmen");
    }
}
