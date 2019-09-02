using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintForest : MonoBehaviour
{
    public ConversationController dialogBox = null;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.name == "Cat") && (other.gameObject.GetComponent<Cat>().GetLevel() < 2))
        {
            //FindObjectOfType<UIController>().ActivateUI();
            //FindObjectOfType<ConversationController>()
            dialogBox.OpenConversation();
            //FindObjectOfType<ConversationController>()
            dialogBox.UpdateConversation("Looks like there's some shiny light through the trees, but they're not going to let you pass.");
        }
    }
}
