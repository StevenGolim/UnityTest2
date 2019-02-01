using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabButtonScript : MonoBehaviour {

    private GameObject OpenDesc;

    [SerializeField] Button[] tabButton;
    GameObject[] tabItem;
    GameObject Content;

    private List<GameObject> pet_List;
    private List<GameObject> demon_List;
    // Use this for initialization
    void Start () {

        pet_List = new List<GameObject>();
        demon_List = new List<GameObject>();

        Content = GameObject.Find("Content");

        AddItemToList("Items/Pet", pet_List);
        AddItemToList("Items/Demon", demon_List);

        for (int i = 0; i < tabButton.Length; i++)
        {
            //Closureという現象
            int x = i;
            tabButton[x].onClick.AddListener(() =>
            {
                ChangeTab(x);
            });
        }
        ChangeTab(0);
    }
	
    void AddItemToList(string folderName,List<GameObject> list)
    {
        Object[] items = Resources.LoadAll(folderName, typeof(GameObject));
        foreach(GameObject item in items)
        {
            GameObject new_Item = (GameObject)Instantiate(item);
            new_Item.transform.SetParent(Content.transform, false);
            new_Item.SetActive(false);
            list.Add(new_Item);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickOpenDesc(GameObject desc)
    {
        OpenDesc = (GameObject)Instantiate(desc);
        OpenDesc.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        OpenDesc.transform.Find("Close").GetComponent<Button>().onClick.AddListener(OnClickShutDesc);
    }

    public void OnClickShutDesc()
    {
        Destroy(OpenDesc);
    }

    void ChangeTab(int tabNum)
    {
        for (int i = 0; i < tabButton.Length; i++)
        {
            if (i == tabNum)
            {
                tabButton[tabNum].GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
            }
            else
            {
                tabButton[i].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            }
        }

        switch(tabNum)
        {
            case 0:
                foreach (GameObject item in pet_List)
                {
                    item.SetActive(true);
                }
                foreach (GameObject item in demon_List)
                {
                    item.SetActive(false);
                }
                break;
            case 1:
                foreach (GameObject item in demon_List)
                {
                    item.SetActive(true);
                }
                foreach (GameObject item in pet_List)
                {
                    item.SetActive(false);
                }
                break;
            case 2:
                foreach (GameObject item in pet_List)
                {
                    item.SetActive(true);
                }
                foreach (GameObject item in demon_List)
                {
                    item.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
}
