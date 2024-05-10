using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour, IInteractable
{
    public string scenename;

    public void start()
    {
        
    }
 
 public void Interact() 
 {
        SceneManager.LoadScene("level 1");
 }
}
