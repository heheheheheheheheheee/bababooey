using UnityEngine;
using System.Collections.Generic;

public class ChairBuyingManager : MonoBehaviour
{
    private List<GameObject> chairList = new List<GameObject>();

    public GameObject chairs;

    private int childCount;

    void Start()
    {
        childCount = chairs.transform.childCount;
        GetChairs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetChairs()
    {
        for (int i = 0; i < childCount; i++)
        {
            Transform chairToAdd = chairs.transform.GetChild(i);
            chairList.Add(chairToAdd.gameObject);
        }
    }
}
