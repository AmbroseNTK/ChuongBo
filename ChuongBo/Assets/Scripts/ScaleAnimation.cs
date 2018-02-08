using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimation : MonoBehaviour {

    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
    public void Open()
    {
        animator.SetBool("isOpen", true);
    }
    public void Close()
    {
        animator.SetBool("isOpen", false);
    }
    public void Toggle()
    {
        animator.SetBool("isOpen", !animator.GetBool("isOpen"));
    }
}
