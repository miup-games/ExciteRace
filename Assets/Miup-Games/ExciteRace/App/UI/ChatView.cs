using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChatView : MonoBehaviour
{
    [SerializeField] Text _messageValue;
    [SerializeField] Animation _showAnimation;
	
    // Update is called once per frame
    public void UpdateView(string message)
    {
        _messageValue.text = message;
        _showAnimation.Play();
    }
}
