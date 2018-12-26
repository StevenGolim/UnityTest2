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

    // Use this for initialization
    void Start()  {
        num_red = 0;
        num_blue = 0;
        Content = GameObject.Find("Content");
        red_button.onClick.AddListener(() =>
        {
            num_red += 1;
            OnClickCreate("RedButton","赤ボタン", num_red);
        });
        blue_button.onClick.AddListener(() =>
        {
            num_blue += 1;
            OnClickCreate("BlueButton","青ボタン", num_blue);
        });
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickClone()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }

    public void OnClickCreate(string prefabName,string buttonName,int buttonNum)
    {
       new_button = (GameObject)Instantiate(Resources.Load(prefabName));
       new_button.name = buttonName + (buttonNum);         
       new_button.GetComponentInChildren<Text>().text = new_button.name;
       new_button.transform.SetParent(Content.transform, false);
       new_button.GetComponent<Button>().onClick.AddListener(OnClickClone);
    }
}
