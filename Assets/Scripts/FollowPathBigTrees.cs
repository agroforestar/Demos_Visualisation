using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FollowPathBigTrees : MonoBehaviour
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
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 36.9f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 36.9f); 
        }

        if(tag == "Shield3")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 73.8f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 73.8f);  
        }


        if(tag == "Shield4")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 110.7f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 110.7f); 
        }

        if(tag == "Shield5")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 147.6f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 147.6f); 
        }

        if(tag == "Shield6")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 184.5f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 184.5f);
        }

        if(tag == "Shield7")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 221.4f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 221.4f); 
        }

        if(tag == "Shield8")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 258.3f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 258.3f);
        }

        if(tag == "Shield9")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 295.2f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 295.2f);
        }

        if(tag == "Shield10")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 332.1f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 332.1f);
        }

        if(tag == "Shield11")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 369.0f); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 369.0f);
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

            if(tag == "Shield4L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 135); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 135);
        }


    }
}
