using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDragEndDrog : MonoBehaviour
{
    public GameObject[] item;
    public GameObject[] itemDrop;

    public int jarak;

    public Vector2[] itemPos;

    public int[] randomIndexs;

    public Vector2[] itemDropPos;

    bool[] isDrops = new bool[9];

    void Start()
    {
        for (int i = 0; i < itemPos.Length; i++)
        {
            itemPos[i] = item[i].transform.localPosition;
        }

        RandomIndex();

        for (int i = 0; i < itemDropPos.Length; i++)
        {
            itemDrop[i] = itemDropPos.transform.localPosition;
        }

        for (int i = 0; i < itemDrop.Length; i++)
        {
            itemDropPos[i].transform.localPosition = itemDrop[randomIndexs[i]];
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemDrag(int number)
    {
        item[number].transform.position = Input.mousePosition;
    }

    public void ItemEndDrag(int number)
    {
        float distance = Vector3.Distance(item[number].transform.localPosition, itemDrop[number].transform.localPosition);

        if (distance < jarak)
        {
            item[number].transform.localPosition = itemDrop[number].transform.localPosition;
        }
        else
        {
            item[number].transform.localPosition = itemPos[number];
        }
    }

    public void RandomIndex()
    {
        for (int i = 0; i < randomIndexs.Length; i++)
        {
            int a = randomIndexs[i];
            int result = Random Range(0, randomIndexs.Length);
            randomIndexs[i] = randomIndexs[result];
            randomIndexs[result] = a;
        }
    }
}