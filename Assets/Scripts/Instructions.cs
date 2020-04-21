using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    void OnMouseUp()
    {
      SceneManager.LoadScene(0);
      Debug.Log("hi");
    }
}
