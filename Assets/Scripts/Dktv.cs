using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Dktv : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject Audio;
    // Start is called before the first frame update
    void Start()
    {
        
        videoPlayer.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag.Contains("Player"))
        {
            videoPlayer.Play();
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        videoPlayer.Pause();
       
    }
}
