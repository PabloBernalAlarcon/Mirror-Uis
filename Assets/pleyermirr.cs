using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class pleyermirr : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector2 movement = new Vector2();


    // Update is called once per frame
    [Client]
    void Update()
    {
        //Does this object belong to me?
        if (!hasAuthority) return;

        //Did I press pace?
        if (!Input.GetKeyDown(KeyCode.Space)) return;

        //Please tell the server I wish to move.
        CmdMove();
   }
    [Command]
    private void CmdMove()
    {
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove() => transform.Translate(movement);


}
