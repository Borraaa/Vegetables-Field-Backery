using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageAnimations(Vector3 move)
    {
        if (move.magnitude > 0)
        {
            PlayRunAnimation();
            playerAC.transform.forward = move.normalized;
        }
        else
        {
            PlayIdleAnimation();
        }
    }
    private void PlayRunAnimation()
    {
        playerAC.Play("RUN");
    }
    private void PlayIdleAnimation()
    {
        playerAC.Play("IDLE");
    }
}
