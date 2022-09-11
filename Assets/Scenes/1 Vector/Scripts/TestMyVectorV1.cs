using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyVectorV1 : MonoBehaviour
{
    [SerializeField]
    private MyVector myFirstVector;
    
    [SerializeField]
    private MyVector mySecondVector;
    
    [SerializeField]
    private MyVector myThirdVector;

    [Range(0, 1), SerializeField] private float DistanceVectors;
    
    [SerializeField]
    private MyVector myFourthVector;
    
    void Update()
    {
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.blue);

        myThirdVector = ( myFirstVector - mySecondVector) * DistanceVectors;
        myThirdVector.Draw(mySecondVector,Color.green);

        myFourthVector = (myFirstVector + mySecondVector) * DistanceVectors;
        myFourthVector.Draw(Color.white);
    }
    
    
}
