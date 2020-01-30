
using UnityEngine;

public class FadingManager : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        
    }

    public void SetFade(bool _IsNight)
    {
        animator.SetBool("IsNight", _IsNight);
    }
}
