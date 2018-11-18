using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {

//the camera range
    public float range = 20f;

    public Camera camera;

//can we click to read?
    public bool canRead= true;

//are we looking at a nullText?
    private bool inNull = false;

    //the 1st bag
    public GameObject bag1;

    //2nd bag
    public GameObject bag2;

    // Update is called once per frame
    void Update () {


        //if you press e, make text appear
        if (Input.GetKeyDown(KeyCode.E) && !inNull) {
            
            Interact();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && !inNull){
            canRead = true;
        }

       
    }

    //sends out a ray that will print the name of the thing you/re looking at
    void Identify () {
        RaycastHit objectInfo;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out objectInfo, range)) {
            print(objectInfo.transform.name);
        }

    }

    

    //function that calls for text to appear if you press e on a function with the 
    //textcreator script
    void Interact () {

        RaycastHit objectInfo;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out objectInfo, range)) {

            TextCreator book = objectInfo.transform.GetComponent<TextCreator>();
            nullText nullText = objectInfo.transform.GetComponent<nullText>();
            BagOne firstB = objectInfo.transform.GetComponent<BagOne>();
            BagTwo secondB = objectInfo.transform.GetComponent<BagTwo>();
            
            
            if (book != null && canRead) {
                canRead = false;
                canRead = book.CreateText(gameObject);
            }

            if(nullText != null && canRead){
                canRead = false;
                inNull = true;
                nullText.CreateText();
            }

            if(firstB != null){
                bag1.SetActive(false);
            }

             if(secondB != null && bag2.GetComponent<MeshRenderer>().enabled == false){
                bag2.GetComponent<MeshRenderer>().enabled = !bag2.GetComponent<MeshRenderer>().enabled;
            }
        }

    }
}




  



