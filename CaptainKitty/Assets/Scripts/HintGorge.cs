using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintGorge : MonoBehaviour
{
    public ConversationController dialogBox = null;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        
        if ((other.gameObject.name == "Cat") && (other.gameObject.GetComponent<Cat>().GetLevel() < 3))
        {
            if (dialogBox == null)
            {
                dialogBox = FindObjectOfType<ConversationController>();
                OnTriggerEnter(other);
                return;
            }
            //FindObjectOfType<UIController>().ActivateUI();
            //FindObjectOfType<ConversationController>()
            dialogBox.OpenConversation();
            //FindObjectOfType<ConversationController>()
            dialogBox.UpdateConversation("Everything here looks really heavy. A cat probably can't move it without a force as strong as a hurricane.");
        }
    }
}
