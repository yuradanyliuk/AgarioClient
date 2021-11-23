﻿using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet packet)
    {
        string msg = packet.ReadString();
        int myId = packet.ReadInt();

        Debug.Log($"Message from server: {msg}");
        Client.Instance.MyId = myId;
        ClientSend.WelcomeReceived();

        Client.Instance.Udp.Connect(((IPEndPoint)Client.Instance.Tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet packet)
    {
        int id = packet.ReadInt();
        string username = packet.ReadString();
        Vector2 position = packet.ReadVector2();

        GameManager.Instance.SpawnPlayer(id, username, position, Quaternion.identity);
    }
}