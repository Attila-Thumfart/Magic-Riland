
using UnityEngine;

public class FadingManager : MonoBehaviour
{
    public Animator animator;

    public void SetFade(bool _IsNight)              //called from other scripts to fade in and fade out
    {
        animator.SetBool("IsNight", _IsNight);
    }
}
