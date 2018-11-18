using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class nullText : MonoBehaviour {

	 //the camera which contains audiosources
     public GameObject playerCam;
    
    //the next scene to load
	public int nextScene;
	
	
	//the audiosource attatched to the object
	AudioSource audioPlayer;

//is the audio playing?
private bool isPlaying = false;


    //blackout bar
    public GameObject blackout;
   
    //the text scheduled to appear
    public GameObject textPrefab;
     GameObject textLocal;

    //the canvas that makes text appear on top
    public GameObject canvas;

    //the player
    public GameObject player;

    //player's crosshair
    public GameObject crosshair;

    KeywordRecognizer keywordRecognizer = null;
    
    // keyword array
    public string[] Keywords_array;

    private bool canRead = false;


    
    private void Start() {
	    audioPlayer = GetComponent<AudioSource>();
    }
    
    
    
    //when this function is called, the text appears and we listen to the player to know when to get rid of it
    public bool CreateText () {

        canRead = false;
       
       // text.SetActive(true);
        textLocal = Instantiate(textPrefab, new Vector3(0, 0, 0), canvas.transform.rotation);
        textLocal.transform.SetParent(canvas.transform, false);

        //stops player from moving
        player.GetComponent<FirstPersonController>().enabled = false;
        crosshair.SetActive(false);

        

         ListenToPlayer( player);


        return canRead;
    }

    //starts to listen for player voice input
    void ListenToPlayer (GameObject player) {

        // instantiate keyword recognizer, pass keyword array in the constructor
        keywordRecognizer = new KeywordRecognizer(Keywords_array);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        // start keyword recognizer
        keywordRecognizer.Start();
        
        
        
        

    }

    //when the keywords are heard, make the text dissapear
    void OnKeywordsRecognized (PhraseRecognizedEventArgs args) {
        Debug.Log("Keyword: " + args.text + "; Confidence: " + args.confidence + "; Start Time: " + args.phraseStartTime + "; Duration: " + args.phraseDuration);

       // text.SetActive(false);
        Destroy(textLocal);
	  

        PlayShooting();
       
    }

    //right click to exit text
    private void Update() {
        

        if(keywordRecognizer != null){
            if(Input.GetKeyDown(KeyCode.Mouse1)){
                keywordRecognizer.Stop();
                keywordRecognizer = null;
                canRead = false;
			 
                
        // text.SetActive(false);
        Destroy(textLocal);

        PlayShooting();
            }
        }

	   if(isPlaying == true){
		   if(audioPlayer.isPlaying == false){
			   SceneManager.LoadScene(nextScene);
		   }
	   }
    }


    void PlayShooting(){
        playerCam.GetComponent<AudioSource>().enabled = false;
        blackout.SetActive(true);

	audioPlayer.Play();
	isPlaying = true;

    }

}
