using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public void SwitchToScene1()
    {
        SceneManager.LoadScene(0); 
    }

    
    public void SwitchToScene2()
    {
        SceneManager.LoadScene(1); 
    }

    
    public void SwitchToScene3()
    {
        SceneManager.LoadScene(2); 
    }
}
