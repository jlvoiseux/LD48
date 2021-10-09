using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
    Text itemField;
    public List<int> itemNumber;
    // Start is called before the first frame update
    void Start()
    {
        itemField = GameObject.FindGameObjectWithTag("ItemNotField").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        foreach(int num in itemNumber)
        {
            if(PlayerPrefs.GetInt("Item"+num.ToString(), 0) != 1)
            {
                itemField.text += "Acquired Item " + num.ToString() + "\n";
                PlayerPrefs.SetInt("Item" + num.ToString(), 1);
            }
            
        }
        
    }
}
