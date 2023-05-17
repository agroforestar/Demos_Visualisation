using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPath : MonoBehaviour
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
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 38); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 38); 
        }

        if(tag == "Shield3")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 76); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 76);  
        }


        if(tag == "Shield4")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 114); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 114); 
        }

        if(tag == "Shield5")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 152); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 152); 
        }

        if(tag == "Shield6")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 190); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 190);
        }

        if(tag == "Shield7")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 228); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 228); 
        }

        if(tag == "Shield8")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 266); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 266);
        }

           if(tag == "Shield9")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 304); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 304);
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
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 45); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 45);
        }

           if(tag == "Shield3L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 90); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 90);
        }


    }
}
