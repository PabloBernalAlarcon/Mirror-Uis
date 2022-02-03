using Mirror;
using System;
using TMPro;
using UnityEngine;

public class ChatBehavior : NetworkBehaviour
{
    [SerializeField]
    private GameObject chatUI = null;
    [SerializeField]
    private TMP_Text chatText = null;
    [SerializeField]
    private TMP_InputField inputField = null;

    private static event Action<string> OnMessage;

    public override void OnStartAuthority()
    {
        chatUI.SetActive(true);
        OnMessage += HandleNewMessage;
        CmdSendMessage("Joined");
    }

    

    [ClientCallback]
    private void OnDestroy()
    {
        if (!hasAuthority) return;
        OnMessage -= HandleNewMessage;
    }

    private void HandleNewMessage(string msg)
    {
        chatText.text += msg;
    }
    [Client]
    public void Send(string msg)
    {
        if (!Input.GetKeyDown(KeyCode.Return)) return;

        if (string.IsNullOrWhiteSpace(msg)) return;

        CmdSendMessage(inputField.text);

        inputField.text = string.Empty;

    }

    [Command]
    private void CmdSendMessage(string msg)
    {
        RpcHandleMessage($"[{connectionToClient.connectionId}]: {msg}");
    }

    [ClientRpc]
    private void RpcHandleMessage(string msg)
    {
        OnMessage?.Invoke($"\n{msg}");
    }

}
