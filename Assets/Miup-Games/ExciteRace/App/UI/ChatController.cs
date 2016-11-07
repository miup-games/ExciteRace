using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatController : MonoBehaviour
{
    
    [SerializeField] ChatView _chatView;

    List<string> prefixes = new List<string>()
    {
        "Watch out",
        "Carefull",
        "Look ahead",
        "Slow down",
        "Danger",
        "Uuups"
    };

    List<string> namings = new List<string>()
    {
        "chief",
        "boss",
        "buddy",
        "friend",
        "fellow",
    };

    List<string> postfixes = new List<string>()
    {
        "ahead!",
        "next!"
    };


    public void CreateMessage(string obstacleName)
    {
        string message = this.GenerateMessageText(obstacleName);
        _chatView.UpdateView(message);
    }

    private string GenerateMessageText(string obstacleName)
    {
        string prefix = prefixes[Random.Range(0, prefixes.Count)];
        string name = namings[Random.Range(0, namings.Count)];
        string postfix = postfixes[Random.Range(0, postfixes.Count)];

        string message = prefix + " " + name + ", " + obstacleName + " " + postfix;

        return message;
    }
}
