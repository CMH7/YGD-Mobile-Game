using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class NewBehaviourScript : MonoBehaviour
{
    private VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        vp = this.gameObject.GetComponent<VideoPlayer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
