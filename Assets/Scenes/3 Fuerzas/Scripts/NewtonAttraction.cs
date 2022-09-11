using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NewtonAttraction : MonoBehaviour
{
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private NewtonAttraction Target;
     public float mass = 1f;
    
    private MyVector position;

    private void Start()
    {
     
        position = transform.position;
        //Time.maximumDeltaTime=(1f/60f);
    }

    private void FixedUpdate()
    {
        aceleration *= 0;
        MyVector r = Target.transform.position -transform.position;
        float rMagnitude = r.magnitude;
        MyVector f = r.normalized*(Target.mass * mass / rMagnitude * rMagnitude);
        
        ApplyForce(f);
        f.Draw(position,Color.cyan);
        Move();
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug Vectors
        position.Draw(Color.green);
        aceleration.Draw(position, Color.white);
        velocity.Draw(position, Color.blue);
        
     
    }

    public void Move()
    {
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        position=position+velocity* Time.fixedDeltaTime;
        if (velocity.magnitude>10)
        {
            velocity.Normalize();
            velocity *= 10;
        }
        transform.position = position;
    }

    void ApplyForce(MyVector force)
    {
        aceleration += force * (1f / mass);
    }
}
  