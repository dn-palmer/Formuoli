using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashTimer : MonoBehaviour
{
    private float splashDelay = 3f, timeElapsed;

    
    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > splashDelay)
        {
            SceneManager.LoadScene("Game");
        
        }
    }
}
