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

    private int lastTabNum;
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
            foreach (Transform child in new_Item.transform)
            {
                if (child.name == "Name") new_Item.name = child.GetComponent<Text>().text;
            }
            new_Item.GetComponent<Button>().onClick.AddListener(() =>
            {
                OnClickOpenDesc(new_Item.name + "Desc");
            });
            new_Item.SetActive(false);
            list.Add(new_Item);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickOpenDesc(string desc)
    {
        OpenDesc = (GameObject)Instantiate(Resources.Load("ItemDesc/"+desc));
        OpenDesc.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        OpenDesc.transform.Find("Close").GetComponent<Button>().onClick.AddListener(OnClickShutDesc);
    }

    public void OnClickShutDesc()
    {
        Destroy(OpenDesc);
    }


    void ActiveItem(int tabNum,bool enable)
    {
        switch (tabNum)
        {
            case 0:
                foreach (GameObject item in pet_List)
                {
                    item.SetActive(enable);
                }
                break;
            case 1:
                foreach (GameObject item in demon_List)
                {
                    item.SetActive(enable);
                }
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    void ChangeTab(int tabNum)
    {
        tabButton[lastTabNum].GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        tabButton[tabNum].GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
        ActiveItem(lastTabNum,false);
        ActiveItem(tabNum,true);
        lastTabNum = tabNum;     
    }
}
