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
    bool[] isDrops;
    public GameObject panelWin;

    void Start()
    {
        isDrops = new bool[item.Length];
        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }
    }

    void Update()
    {
    }

    public void ItemDrag(int number)
    {
        if (!isDrops[number])
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
        foreach (bool isDrop in isDrops)
        {
            if (!isDrop)
            {
                return;
            }
        }

        panelWin.SetActive(true);
    }

    bool AreAllItemsDropped()
    {
        foreach (bool isDrop in isDrops)
        {
            if (!isDrop)
            {
                return false;
            }
        }

        return true;
    }

    public void LoadToScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}