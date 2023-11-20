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
        // Initialize the isDrops array with the length of the items array
        isDrops = new bool[item.Length];

        // Store the initial positions of items
        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any update logic here if needed
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
        // Check if all items are dropped
        foreach (bool isDrop in isDrops)
        {
            if (!isDrop)
            {
                // If any puzzle is not placed, exit the function
                return;
            }
        }

        // If all puzzles are placed, trigger the win
        panelWin.SetActive(true);
    }

    // Function to check if all items are dropped
    bool AreAllItemsDropped()
    {
        foreach (bool isDrop in isDrops)
        {
            if (!isDrop)
            {
                // If any puzzle is not placed, return false
                return false;
            }
        }

        // If all puzzles are placed, return true
        return true;
    }

    public void LoadToScene(string sceneName)
    {
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
