using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowAI : MonoBehaviour {


    Rigidbody rigid;
    CharacterController character;
    Animator animator;
    public float waitTimeMax;
    public float eatingTimeMax;
    private float waitTime;
    private float eatingTime;
    private float runningTime;
    private float runninTimeMax;
    private Vector3 target;
    private float angle;
    private bool isRotated;
    private bool isEating;
    private Vector3 unit = new Vector3(0, 0, 1);
    private AudioSource audio;
	void Start () {
        rigid = GetComponent<Rigidbody>();

        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        generateRandom();
        
	}
	
    private void generateRandom()
    {
        waitTime = 0;
        runningTime = 0;
        eatingTime = 0;
        isRotated = false;
        isEating = false;
        waitTimeMax = Random.Range(5, 10);
        eatingTimeMax = Random.Range(60, 120);
        runninTimeMax = Random.Range(5, 10);
        target = new Vector3(Random.Range(-3,3), 0, Random.Range(-3,3));
    }
	
	void Update () {

        waitTime += Time.deltaTime;
        if (waitTime > waitTimeMax)
        {
            if (!isRotated)
            {
                //transform.Rotate(new Vector3(0, Vector3.Angle(target - transform.position, unit), 0));
                animator.SetBool("isRunning", true);
                isRotated = true;
            }
            else
            {
                runningTime += Time.deltaTime;
                
                Vector3 delta = transform.position - target;
                if((Mathf.Abs(delta.x)<0.01f && Mathf.Abs(delta.z) < 0.01f)||(runningTime>runninTimeMax))
                {
                    eatingTime += Time.deltaTime;
                    if (eatingTime < eatingTimeMax)
                    {
                        if (!isEating)
                        {
                            animator.SetBool("isRunning", false);
                            animator.SetBool("isEating", true);
                            audio.Play();
                            isEating = true;
                        }
                    }
                    else
                    {
                        animator.SetBool("isEating", false);
                        generateRandom();
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime);
                }
            }
        }
	}
}
