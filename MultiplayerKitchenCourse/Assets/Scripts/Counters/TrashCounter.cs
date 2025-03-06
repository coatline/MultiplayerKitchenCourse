using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TrashCounter : BaseCounter
{


    public static event EventHandler OnAnyObjectTrashed;

    new public static void ResetStaticData()
    {
        OnAnyObjectTrashed = null;
    }



    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            KitchenObject.DestroyKitchenObject(player.GetKitchenObject());
            InteractLogicServerRPC();
        }
    }


    [Rpc(SendTo.Server)]
    void InteractLogicServerRPC()
    {
        InteractLogicClientRPC();
    }

    [Rpc(SendTo.ClientsAndHost)]
    void InteractLogicClientRPC()
    {
        OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
    }
}