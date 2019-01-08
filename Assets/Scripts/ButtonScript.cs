using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ButtonScript : MonoBehaviour {
    GameObject new_button;
    GameObject Content;

    private static int num_red ;
    private static int num_blue;

    [SerializeField] Button red_button;
    [SerializeField] Button blue_button;
    [SerializeField] Button del_red_button;
    [SerializeField] Button del_blue_button;

    private List<GameObject> redButtonList;
    private List<GameObject> blueButtonList;

    // Use this for initialization
    void Start()  {
        num_red = 0;
        num_blue = 0;

        redButtonList = new List<GameObject>();
        blueButtonList = new List<GameObject>();

        Content = GameObject.Find("Content");
        red_button.onClick.AddListener(() =>
        {
            num_red += 1;
            OnClickCreate("RedButton","赤ボタン", num_red, redButtonList);
        });
        blue_button.onClick.AddListener(() =>
        {
            num_blue += 1;
            OnClickCreate("BlueButton","青ボタン", num_blue, blueButtonList);
        });
        del_red_button.onClick.AddListener(() =>
        {
            OnClickDeleteOldest(redButtonList);
        });
        del_blue_button.onClick.AddListener(() =>
        {
            OnClickDeleteOldest(blueButtonList);
        });
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void OnClickClone()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    public void OnClickCreate(string prefabName,string buttonName,int buttonNum,List<GameObject>list)
    {
       new_button = (GameObject)Instantiate(Resources.Load(prefabName));
       new_button.name = buttonName + (buttonNum);         
       new_button.GetComponentInChildren<Text>().text = new_button.name;
       new_button.transform.SetParent(Content.transform, false);
       new_button.GetComponent<Button>().onClick.AddListener(OnClickClone);
       list.Add(new_button);
    }

    void OnClickDeleteOldest(List<GameObject> list)
    {
        if(list.Count > 0)
        {
            Destroy(list[0].gameObject);
            list.RemoveAt(0);
        }

    }
}
