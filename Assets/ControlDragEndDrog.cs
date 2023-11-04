using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDragEndDrog : MonoBehaviour
{
    public static ControlDragEndDrog Instance;

    public GameObject[] item;
    public GameObject[] itemDrop;
    public int jarak;

    public Vector2[] itemPos;
    private int[] itemDropIndex;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (item.Length != itemDrop.Length)
        {
            Debug.LogError("Array 'item' dan 'itemDrop' harus memiliki panjang yang sama.");
            return;
        }

        itemPos = new Vector2[item.Length];
        itemDropIndex = new int[item.Length];

        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
            itemDropIndex[i] = -1;
        }
    }

    public void ItemDrag(int number)
    {
        item[number].transform.position = Input.mousePosition;
    }

    public void ItemEndDrag(int number)
    {
        for (int i = 0; i < itemDrop.Length; i++)
        {
            float distance = Vector3.Distance(item[number].transform.position, itemDrop[i].transform.position);

            if (distance < jarak)
            {
                item[number].transform.position = itemDrop[i].transform.position;
                itemDropIndex[number] = i;
                return;
            }
        }

        item[number].transform.localPosition = itemPos[number];
        itemDropIndex[number] = -1;
    }

    public bool VerifyPlacement()
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (itemDropIndex[i] != i)
            {
                return false;
            }
        }
        return true;
    }
}