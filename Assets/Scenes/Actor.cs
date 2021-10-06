using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpAmount;

    CharacterController cc;
    Animator anim;
    float movement;
    Vector3 moveDirection;
    float jumpMovement;
    float lastX = -1;
    
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveDirection.y -= 9.8f * Time.deltaTime;
        
        if(cc.isGrounded)
        {
            moveDirection.y = jumpMovement;
        }

        moveDirection.x = movement;

        moveDirection.x *= speed;

        anim.SetFloat("MoveSpeed", Mathf.Abs(moveDirection.x));

        transform.rotation = Quaternion.Euler(0f, lastX * 90f, 0f);

        cc.Move(moveDirection * Time.deltaTime);

    }

    public void Move(Vector2 input)
    {
        movement = input.x;
        if(input.x != 0)
            lastX = Mathf.Sign(input.x);
    }

    public void Jump(bool start)
    {
        if(start)
        {
            jumpMovement = jumpAmount;
            anim.SetBool("jumped", true);
        }
        else
        {
            anim.SetBool("jumped", false);
            jumpMovement = 0;
        }
    }

    public void Attack(bool start)
    {
        if(start)
        {
            anim.SetBool("punched", true);
        }
    }

    public void EndAttack()
    {
        anim.SetBool("punched", false);
    }
}
