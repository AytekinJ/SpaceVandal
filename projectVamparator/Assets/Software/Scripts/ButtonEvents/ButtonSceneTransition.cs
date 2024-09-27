using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTransition : MonoBehaviour
{
    public void SellScreen()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
    public void CollectArea()
    {
        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}
