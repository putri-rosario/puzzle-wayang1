using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlDragEndDrog : MonoBehaviour
{
    public GameObject[] item;
    public GameObject[] itemDrop;

    public int jarak;

    public Vector2[] itemPos;

    public Vector2[] itemDropPos;

    bool[] isDrops = new bool[9];

    public GameObject panelWin;


    void Start()
    {
        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrag(int number)
    {
        if (isDrops[number] == false)
        {
            item[number].transform.position = Input.mousePosition;
        }

    }
    public void ItemEndDrag(int number)
    {
        float distance = Vector3.Distance(item[number].transform.localPosition, itemDrop[number].transform.localPosition);

        if (distance < jarak)
        {
            item[number].transform.localPosition = itemDrop[number].transform.localPosition;

            isDrops[number] = true;

            CheckWin();
        }
        else
        {
            item[number].transform.localPosition = itemPos[number];
        }
    }

    void CheckWin()
    {
        for (int i = 0; i < isDrops.Length; i++)
        {
            if (isDrops[i] == true)
            {
                return;
            }
            else
            {
                if (i == isDrops.Length - 1)
                {
                    panelWin.SetActive(true);
                }
            }
        }
    }

    public void LoadToScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}