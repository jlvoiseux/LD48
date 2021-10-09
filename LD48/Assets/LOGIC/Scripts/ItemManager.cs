using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Button Item1;
    public Button Item2;
    public Button Item3;
    public Button Item4;
    public Button Item5;
    public Button Item6;
    public Button Item7;
    public Button Item8;
    public Button Item9;
    public Button Item10;

    public List<string> hiddenItems;
    public List<string> shownItems;
    public List<GameObject> description;

    // Start is called before the first frame update
    void Start()
    {

        Item1.GetComponentInChildren<Text>().text = shownItems[0];
        
        Item2.GetComponentInChildren<Text>().text = shownItems[1];

        if (PlayerPrefs.GetInt("Item3") == 1)
        {
            Item3.GetComponentInChildren<Text>().text = shownItems[2];
        }
        else
        {
            Item3.GetComponentInChildren<Text>().text = hiddenItems[2];
            Item3.enabled = false;
            Item3.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item4") == 1)
        {
            Item4.GetComponentInChildren<Text>().text = shownItems[3];
        }
        else
        {
            Item4.GetComponentInChildren<Text>().text = hiddenItems[3];
            Item4.enabled = false;
            Item4.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item5") == 1)
        {
            Item5.GetComponentInChildren<Text>().text = shownItems[4];
        }
        else
        {
            Item5.GetComponentInChildren<Text>().text = hiddenItems[4];
            Item5.enabled = false;
            Item5.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item6") == 1)
        {
            Item6.GetComponentInChildren<Text>().text = shownItems[5];
        }
        else
        {
            Item6.GetComponentInChildren<Text>().text = hiddenItems[5];
            Item6.enabled = false;
            Item6.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item7") == 1)
        {
            Item7.GetComponentInChildren<Text>().text = shownItems[6];
        }
        else
        {
            Item7.GetComponentInChildren<Text>().text = hiddenItems[6];
            Item7.enabled = false;
            Item7.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item8") == 1)
        {
            Item8.GetComponentInChildren<Text>().text = shownItems[7];
        }
        else
        {
            Item8.GetComponentInChildren<Text>().text = hiddenItems[7];
            Item8.enabled = false;
            Item8.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item9") == 1)
        {
            Item9.GetComponentInChildren<Text>().text = shownItems[8];
        }
        else
        {
            Item9.GetComponentInChildren<Text>().text = hiddenItems[8];
            Item9.enabled = false;
            Item9.GetComponent<Image>().enabled = false;
        }

        if (PlayerPrefs.GetInt("Item10") == 1)
        {
            Item10.GetComponentInChildren<Text>().text = shownItems[9];
        }
        else
        {
            Item10.GetComponentInChildren<Text>().text = hiddenItems[9];
            Item10.enabled = false;
            Item10.GetComponent<Image>().enabled = false;
        }
    }

    public void showDesc(int item)
    {
        ResetDesc();
        description[item].SetActive(true);
    }

    void ResetDesc()
    {
        foreach(GameObject desc in description)
        {
            desc.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
