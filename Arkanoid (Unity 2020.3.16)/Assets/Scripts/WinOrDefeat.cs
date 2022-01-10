using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinOrDefeat : MonoBehaviour
{
  public void Defeat()
  {
        SceneManager.LoadScene("StartScene");    
  }

}
