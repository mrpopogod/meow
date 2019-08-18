using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour
{
    public GameObject conversationPanel = null;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenConversation()
    {
        if (conversationPanel == null) return;
        conversationPanel.SetActive(true);
    }
    public void CloseConversation()
    {
        if (conversationPanel == null) return;
        conversationPanel.SetActive(false);
    }
}
