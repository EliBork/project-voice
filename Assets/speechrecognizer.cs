
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Windows.Speech;
using System;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class speechrecognizer : MonoBehaviour
{
    public GameObject player;

    KeywordRecognizer keywordRecognizer;
    // keyword array
    public string[] Keywords_array;

    // Use this for initialization
    void Start()
    {

        
        // Change size of array for your requirement
        Keywords_array = new string[1];
        Keywords_array[0] = "New Text";
        // instantiate keyword recognizer, pass keyword array in the constructor
        keywordRecognizer = new KeywordRecognizer(Keywords_array);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        // start keyword recognizer
        keywordRecognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text + "; Confidence: " + args.confidence + "; Start Time: " + args.phraseStartTime + "; Duration: " + args.phraseDuration);

        Application.Quit();
        
        // write your own logic
    }
}