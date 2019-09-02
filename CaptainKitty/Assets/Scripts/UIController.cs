using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public bool uiShown = true;
    public Cat theCat;
    public ConversationController dialogBox = null;
    public GameObject quitBox = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public ConversationController GetDialogBox()
    {
        return dialogBox;
    }

    public void OpenQuit()
    {
        quitBox.SetActive(true);
    }

    public void ActivateUI()
    {
        Debug.Log("Show UI" + this.transform.childCount);
        uiShown = true;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            string objectName = this.transform.GetChild(i).gameObject.name;
            if (objectName == "Sprint")
            {
                if (theCat.GetLevel() > 0)
                {
                    this.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else if (objectName == "Fire")
            {
                if (theCat.GetLevel() > 1)
                {
                    this.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            else if (objectName == "Wind")
            {
                if (theCat.GetLevel() > 2)
                {
                    this.transform.GetChild(i).gameObject.SetActive(true);
                }
            } else if (objectName == "Conversation Panel")
            {
                //do nothing
            } else if (objectName == "Quit")
            {
                //do nothing
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (theCat == null)
        {
            theCat = FindObjectOfType<Cat>();
        }
        if (Input.GetKeyDown("tab") && (uiShown == false))
        {
            ActivateUI();
            /*foreach (GameObject uiObject in uiChildren)
            {
                Debug.Log("A new child.." + uiObject.ToString());
                uiObject.SetActive(true);
            }*/
            //this.gameObject.SetActive(true);
        } else if ((Input.GetKeyUp("tab")) && (uiShown == true))
        {
            Debug.Log("Hide UI"+ this.transform.childCount);
            uiShown = false;
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            //this.gameObject.SetActive(false);
        }
    }
}
