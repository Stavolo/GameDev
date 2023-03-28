using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _runAnimationKey;

    void Update()
    {
        if(Input.GetButtonDown("Horizontal"))
        {
            _animator.SetBool(_runAnimationKey, true);
        }
        else if (Input.GetButtonUp("Horizontal"))
        {
            _animator.SetBool(_runAnimationKey, false);
        }
    }
}
