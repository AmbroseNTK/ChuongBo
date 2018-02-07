using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Conversation
{
    private CharacterName character;
    private String conversationText;
    private ConversationType conversationType;
    private Conversation[] nextConversation;


    public Conversation()
    {
        ConversationText = "";
        ConversationType = ConversationType.Single;
        nextConversation = new Conversation[0];
    }

    public Conversation(CharacterName character, string conversationText, ConversationType conversationType)
    {
        this.Character = character;
        this.ConversationText = conversationText;
        this.ConversationType = conversationType;
        nextConversation = new Conversation[0];
    }

    public CharacterName Character
    {
        get
        {
            return character;
        }

        set
        {
            character = value;
        }
    }

    public string ConversationText
    {
        get
        {
            return conversationText;
        }

        set
        {
            conversationText = value;
        }
    }

    public ConversationType ConversationType
    {
        get
        {
            return conversationType;
        }

        set
        {
            conversationType = value;
        }
    }

    /// <summary>
    /// How to show your conversation
    /// </summary>
    public abstract void Show();
}
