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
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 48); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 48); 
        }

        if(tag == "Shield3")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 96); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 96);  
        }


        if(tag == "Shield4")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 144); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 144); 
        }

        if(tag == "Shield5")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 192); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 192); 
        }

        if(tag == "Shield6")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 240); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 240);
        }

        if(tag == "Shield7")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 288); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 288); 
        }

        if(tag == "Shield8")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 329); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 329);
        }

        if(tag == "Shield9")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 376); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 376);
        }

        if(tag == "Shield10")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 423); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 423);
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
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 40); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 40);
        }

           if(tag == "Shield3L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 80); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 80);
        }

            if(tag == "Shield4L")
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled + 120); 
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled + 120);
        }


    }
}
