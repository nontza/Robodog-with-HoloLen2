using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System;
using System.Runtime.InteropServices;
using Robodog;
using System.IO.Compression;
using System.Security.Cryptography;


public unsafe class UDPClient : MonoBehaviour
{
    private UdpClient udpClient;

    HighCMD cmd = new HighCMD{};
    
    // Robodog
    //IPEndPoint targetEndPoint = new IPEndPoint(IPAddress.Parse("192.168.12.1"), 8082);

    // My computer
    IPEndPoint targetEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);


    // Start is called before the first frame update
    void Start()
    {
        try{
            udpClient = new UdpClient();
            udpClient.Connect(targetEndPoint);
        }
        catch(Exception e)
        {
            Debug.LogError($"Error occurred while connecting to {targetEndPoint}: {e.Message}");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void Forward()
    {
        Debug.Log("go forward");

        cmd.mode = 2;
        cmd.gaitType = 1;
        cmd.velocity[0] = 0.2f; // -1  ~ +1
        cmd.yawSpeed = 0;
        cmd.footRaiseHeight = 0.1f;

        // แปลง struct เป็น byte array
        byte[] cmdBytes = StructToBytes(cmd);

        // ส่งข้อมูลผ่าน UDP
        udpClient.Send(cmdBytes, cmdBytes.Length);

        string hexString = BitConverter.ToString(cmdBytes);
        if (cmdBytes != null)
        { Debug.Log(hexString); }
    }

    public void Left()
    {
        Debug.Log("turn left");

        cmd.mode = 2;
        cmd.gaitType = 1;
        cmd.velocity[0] = 0.2f; // -1  ~ +1
        cmd.yawSpeed = 1;
        cmd.footRaiseHeight = 0.1f;

        // แปลง struct เป็น byte array
        byte[] cmdBytes = StructToBytes(cmd);

        // ส่งข้อมูลผ่าน UDP
        udpClient.Send(cmdBytes, cmdBytes.Length);
    }

    public void Right()
    {
        Debug.Log("turn right");

        cmd.mode = 2;
        cmd.gaitType = 1;
        cmd.velocity[0] = 0.2f; // -1  ~ +1
        cmd.yawSpeed = -1;
        cmd.footRaiseHeight = 0.1f;

        // แปลง struct เป็น byte array
        byte[] cmdBytes = StructToBytes(cmd);

        // ส่งข้อมูลผ่าน UDP
        udpClient.Send(cmdBytes, cmdBytes.Length);
    }

    public void Stand()
    {
        Debug.Log("stand");

        cmd.mode = 1;
        cmd.bodyHeight = 0.0f;

        // แปลง struct เป็น byte array
        byte[] cmdBytes = StructToBytes(cmd);

        // ส่งข้อมูลผ่าน UDP
        udpClient.Send(cmdBytes, cmdBytes.Length);
    }

    public void Sit()
    {
        Debug.Log("sit");

        cmd.mode = 1;
        cmd.bodyHeight = -0.5f;

        // แปลง struct เป็น byte array
        byte[] cmdBytes = StructToBytes(cmd);

        // ส่งข้อมูลผ่าน UDP
        udpClient.Send(cmdBytes, cmdBytes.Length);
    }

    public static byte[] StructToBytes(object obj)
    {
        int size = Marshal.SizeOf(obj);
        byte[] arr = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(obj, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);
        return arr;
    }

    void OnApplicationQuit()
    {
        // Clean up the UDP client
        udpClient.Close();
    }
}
