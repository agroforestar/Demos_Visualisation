using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPathTracteur : MonoBehaviour
{

    
    public PathCreator pathCreator;
    public float speed = 1.0f;
    public float distanceTravelled;

    // Update is called once per frame
    void Update()
    {        
        if(tag == "Shield1")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled); 
        }

        if(tag == "Shield2")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 1.6f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 1.6f); 
        }

        if(tag == "Shield3")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 3.2f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 3.2f);  
        }


        if(tag == "Shield4")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 4.8f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 4.8f); 
        }

        if(tag == "Shield5")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 6.4f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 6.4f); 
        }

        if(tag == "Shield6")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 8f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 8f);
        }

        if(tag == "Shield7")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 9.6f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 9.6f); 
        }

        if(tag == "Shield8")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 11.2f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 11.2f);
        }

           if(tag == "Shield9")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 12.8f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 12.8f);
        }


        // Pour la petite zone avec les 3 boucliers :

        if(tag == "Shield1L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled); 
        }

        if(tag == "Shield2L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 4); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 4);
        }

           if(tag == "Shield3L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 8); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 8);
        }


    }
}
