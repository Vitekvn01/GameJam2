using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : SingletonBase<SceneHelper> 
{
    public void LoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
