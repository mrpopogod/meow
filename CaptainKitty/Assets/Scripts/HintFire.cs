using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFire : MonoBehaviour
{
    public ConversationController dialogBox = null;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Cat") && (other.gameObject.GetComponent<Cat>().GetLevel() < 1))
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
            dialogBox.UpdateConversation("Woah, that fire looks hot. Better find something wet before you singe your paws!");
        }
    }
}
