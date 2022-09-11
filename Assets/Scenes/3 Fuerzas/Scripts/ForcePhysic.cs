using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ForcePhysic : MonoBehaviour
{
    [SerializeField] private MyVector Wind;
    [SerializeField] private float mass = 1f; 
    
    [Header("Extras")]
    [Range(0,1)][SerializeField] private float Gravity = -9.8f; 
    [Range(0,1)][SerializeField] private float dampingFactor = 1;

    [SerializeField] private float frictionCoefficient = 0.5f;
    private MyVector aceleration;
    private MyVector velocity;
    private MyVector position;
    
         
    private void Start()
    {
     
        position = transform.position;
        //Time.maximumDeltaTime=(1f/60f);
    }

    private void FixedUpdate()
    {
        aceleration *= 0f;
        float weigthScalar = mass * Gravity;
        MyVector weigth = new MyVector(0,weigthScalar);
        float N = -mass * Gravity;
        MyVector friction = velocity.normalized *  -1;
        
        Debug.Log(velocity.normalized);
        friction.Draw(position,Color.blue);
        ApplyForce(weigth);
        ApplyForce(friction);
        Move();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug Vectors
        position.Draw(Color.white);
        aceleration.Draw(position, Color.blue);
        velocity.Draw(position, Color.green);
        
     
    }

    public void Move()
    {
        // transform.position = position;
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position = position + velocity* Time.fixedDeltaTime;

        if (position.x < -5 || position.x > 5) 
        {
            position.x = Mathf.Sign(position.x)*5;
            velocity.x = -velocity.x;
            velocity *= dampingFactor;
        }
        if (position.y < -5 || position.y > 5) 
        {
            position.y = Mathf.Sign(position.y)*5;
            velocity.y = -velocity.y;
            velocity *= dampingFactor;
            
        }

       // Rigidbody rb = GetComponent<Rigidbody>();
       // rb.AddForce(Vector3.up, ForceMode.VelocityChange);
        
        transform.position = position;
    }

    void ApplyForce(MyVector force)
    {
        aceleration += force * (1f / mass);
    }
}
  