using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableblocks;
    SceneLoader sceneLoader;
    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    public void countbreakableblocks ()
    {
        breakableblocks++;
    }
    public void blockdestroy()
    {
        breakableblocks--;
        if(breakableblocks <= 0)
        {
            sceneLoader.LoadNextScreen();
        }
    }
}
