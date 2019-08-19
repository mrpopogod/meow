using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    public GameObject conversationPanel = null; //This is actually just 'this.gameObject'
    public Text myText = null;
    private int conversationIndex = 0;
    private string[] textDatabase =
    {
        "",
        "Welcome to the game!",
        "You're a cat. You'd like to evolve.",
        "Interact with controls:\n\nMovement = WASD, Arrows, or Joystick\nJump = SPACE\nSprint = Hold SHIFT\nFire=F",
        "Okay, now go explore. You'll change states and evolve your powers until you can save the world."
    };

    // Start is called before the first frame update
    void Start()
    {
        //Assing this personal setup
        //this.
        //myText = //this.GetComponentInChildren(Text, false);// GetComponent("Text");
        //myText = (this.GetComponents<Text>())[0];
    }
    
    public void OpenConversation()
    {
        conversationIndex = 0;
        if (conversationPanel == null) return;
        conversationPanel.SetActive(true);
    }
    public void CloseConversation()
    {
        conversationIndex = 0;
        if (conversationPanel == null) return;
        conversationPanel.SetActive(false);
    }

    public void UpdateConversation(string customText)
    {
        myText.text = customText;
        return; //customText;
    }

    public void NextConversation()
    {
        string newText = "";
        conversationIndex++;
        if ((conversationIndex < textDatabase.Length) && (textDatabase[conversationIndex] != null))
        {
            newText = textDatabase[conversationIndex];
            myText.text = newText;
        } else
        {
            CloseConversation();
        }

    }

    public void SetConversation(int index)
    {
        string newText = "";
        conversationIndex = index;
        if ((conversationIndex < textDatabase.Length) && (textDatabase[conversationIndex] != null))
        {
            newText = textDatabase[conversationIndex];
            myText.text = newText;
        }

    }

    public void PreviousConversation()
    {
        string newText = "";
        conversationIndex--;
        if ((conversationIndex >= 0) && (textDatabase[conversationIndex] != null))
        {
            newText = textDatabase[conversationIndex];

            myText.text = newText;
        } else
        {
            CloseConversation();
        }

    }

}
