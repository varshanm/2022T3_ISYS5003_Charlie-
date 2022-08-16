using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager_Nitesh : MonoBehaviour
{
    public void gotoMenuNitesh()
    {
        SceneManager.LoadScene(1);
    }
    public void gotoMainMenu(){
        SceneManager.LoadScene(0);
    }
    public void gotoGame(){
        SceneManager.LoadScene(2);
    }
    public void gotoArView(){
        SceneManager.LoadScene(3);
    }
}
