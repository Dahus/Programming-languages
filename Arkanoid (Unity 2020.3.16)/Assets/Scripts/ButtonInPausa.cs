using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonInPausa : MonoBehaviour
{
  public void ButtonRestart()
  {
        SceneManager.LoadScene("Game");
  }

    public void ButtonExit() 
    {
        SceneManager.LoadScene("StartScene");
    }

   
}
