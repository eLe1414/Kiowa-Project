using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicophoneDetector : MonoBehaviour
{
    public static string[] devices;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start("Micrófono ((LCS) USB Audio Device)", true, 10, 44100);
        audioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
