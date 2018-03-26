using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour {

    public void ToScene(string nameScene)
    {
        Debug.Log("here");
        SceneManager.LoadScene(nameScene);
    }
}
