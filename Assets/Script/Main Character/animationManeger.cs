using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationManeger : MonoBehaviour
{
    private Animator anim;

   public bool isSlide;
    public bool isRuning;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isSlide = false;
        isRuning = GetComponentInParent<Movement>().isRuning;
    }

    // Update is called once per frame
    void Update()
    {
        isRuning = GetComponentInParent<Movement>().isRuning;
        anim.SetBool("isRuning", isRuning);
        anim.SetBool("isSlide", isSlide);
    }
    
    public void slideStart()
    {
        isSlide = true;
    }
    public void slideEnd()
    {
        isSlide = false;
    }
    public void animations(int _anim)//that paramiter from movement class
    {
        if (_anim == 1)//slide animation
        {
            anim.SetTrigger("slide");
        }
        else if (_anim == 2)//jump animation
        {
            isSlide = false;
            anim.SetTrigger("jump");
        }
        
    }
}
