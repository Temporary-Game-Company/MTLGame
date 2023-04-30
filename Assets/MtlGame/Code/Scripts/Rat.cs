using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] protected float moveSpeed = 4f;
    
    [SerializeField] protected Animator _animator;

    [SerializeField] private Rigidbody2D _rigidbody;


    protected bool hasDest = false;
    protected Vector2 destination;

    public void SetDestination(Vector2 newDestination)
    {
        destination = newDestination;
        hasDest = true;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateAnimatorParams();
    }

    void SetMovementToDestination()
    {
        if (Math.Abs(transform.position.x - destination.x) > 0.1f)
        {
            if (destination.x - transform.position.x < 0f)
            {
                if (_rigidbody)
                {
                    _rigidbody.velocity = Vector2.left * moveSpeed;
                }
            }
            else
            {
                if (_rigidbody)
                {
                    _rigidbody.velocity = Vector2.right * moveSpeed;
                }
            }
        }else if (Math.Abs(transform.position.y - destination.y) > 0.1f)
        {
            if (destination.y - transform.position.y < 0f)
            {
                if (_rigidbody)
                {
                    _rigidbody.velocity = Vector2.down * moveSpeed;
                }
            }
            else
            {
                if (_rigidbody)
                {
                    _rigidbody.velocity = Vector2.up * moveSpeed;
                }
            }
        }
        else
        {
            // we are close enough to destination, stop moving
            if (_rigidbody)
            {
                _rigidbody.velocity = Vector2.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //The rat has entered a trigger, if either for the house of the player do stuff
        if (col.tag.Equals("house"))
        {
            // Do stuff to infect the house here
            Destroy(gameObject);
        }
    }

    void UpdateAnimatorParams()
    {
        if (!_animator) return;
        if (_rigidbody)
        {
            _animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
            
            _animator.SetFloat("xSpeed", _rigidbody.velocity.x);
            
            _animator.SetFloat("ySpeed", _rigidbody.velocity.y);
        }
        
        
        _animator.SetBool("hasDest", hasDest);
    }
    
    
}
