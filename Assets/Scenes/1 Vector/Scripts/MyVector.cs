using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public struct MyVector 
{
    public float x;
    public float y;

    public MyVector(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
    public void Draw(Color color)
    {
        Debug.DrawLine(
            new Vector3(0, 0, 0),
            new Vector3(x, y, 0),
            color,
            0
        );
        
    }
    public void Draw(MyVector origin,Color color)
    {
        Debug.DrawLine(new Vector3(origin.x, origin.y, 0), new Vector3(x+origin.x, y+origin.y, 0), color);
        
    }

    public float magnitude => Mathf.Sqrt(x * x + y * y);

    public MyVector normalized
    {
        get
        {
            float distance = magnitude;
            
           if (distance<= float.Epsilon)
            {
                return new MyVector(0, 0);
            }
            return  new MyVector(x / magnitude, y/magnitude);
            
        }
    }
 
    
    public static MyVector operator+(MyVector a, MyVector b)
   {
        return new MyVector(
            a.x + b.x,
            a.y + b.y
            
            );
    }

    public void Normalize()
    {
        float magnitudeCache = magnitude;
            if (magnitudeCache<float.Epsilon)
        {
            x = 0;
            y = 0;
            
        }
        else
        {
            x /= magnitudeCache;
            y /= magnitudeCache;
        }
       
    }
    public static MyVector operator-(MyVector a, MyVector b)
    {
        return new MyVector(
            a.x - b.x,
            a.y - b.y
            
        );
    }
    public static MyVector operator*(MyVector a, float b)
    {
        return new MyVector(
            a.x * b,
            a.y * b
            
        );
    }
    
    public static implicit operator Vector3(MyVector a)
    {
        return new Vector3(a.x, a.y, 0);
    }
    
    public static implicit operator MyVector(Vector3 a)
    {
        return new MyVector(a.x, a.y);
    }

    public MyVector lerp (MyVector b, float c)
    {
        return (this +(this - b)*c);
    }
    
    public override string ToString()
    {
        return $"[{x}, {y}]";
    }
}
//a.x + (a.x - b.x)*c,
//a.y + (a.y - b.y)*c