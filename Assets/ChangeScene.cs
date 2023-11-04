using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour
{

    public string level;


    public void Test()
    {
        if (ControlDragEndDrog.Instance.VerifyPlacement())
        {
            Debug.Log("Benar");
            SceneManager.LoadScene(level);
        }
        else
        {
            Debug.Log("false");
        }
    }
}
