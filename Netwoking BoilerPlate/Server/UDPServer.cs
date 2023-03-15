using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UDPServer : MonoBehaviour
{
    private static UDPServer _instance;
    public static UDPServer instance { get { return _instance; } }

   
    //  public Text Debugtext;
    public string request;
    public string response;
    IPEndPoint clientEndpoint;
    UdpClient listener;

   public NetworkLogicHandler networkLogicHandler;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {

        // Create a new UdpClient object to listen for incoming messages
        try
        {
            listener = new UdpClient(12345);
            clientEndpoint = new IPEndPoint(IPAddress.Any, 12345);
            Debug.Log("Server Started");
            //  IPEndPoint iPEndPoint= new IPEndPoint(IPAddress.Any, 0);    

            // Start a new thread to listen for incoming messages
            Thread listenThread = new Thread(() =>
            {
                while (true)
                {
                    // Receive a message from a client
                   
                    byte[] message = listener.Receive(ref clientEndpoint);
                    request = Encoding.ASCII.GetString(message);

                    // Process the request here...

                    NetworkLogicHandler.instance.ProcessingData(request);
                    // Send a response back to the client

                    networkLogicHandler.EPAddress = clientEndpoint;
                    Debug.Log("hehe" + request + " "+ clientEndpoint);


                }
            });
            // Debugtext.text = "Received request from " + clientEndpoint + ": " + request;
            listenThread.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }


        Debug.Log("Press any key to stop the server...");

    }
    public string GetResponce()
    {
        return request;
    }
    public void sendMsg(string responce, string Reqest, string ExpectedRequest, IPEndPoint clientEndpointAddress)
    {
        Debug.Log(clientEndpoint.Address.ToString() + " EPPPPPPP");

        if (Reqest == ExpectedRequest)
        {
             byte[] responseBytes = Encoding.ASCII.GetBytes(response);
           response = responce;
            listener.Send(responseBytes, responseBytes.Length, clientEndpointAddress);
        }
        // Send a response back to the client
      
    }
    public void sendToClient(string Send, IPEndPoint clientEndpointAddress)
    {
        Debug.Log(clientEndpoint + " CLIENTENDPOINT");
        byte[] responseBytes = Encoding.ASCII.GetBytes(Send);

        try
        {
       
           Debug.Log(clientEndpoint.Address.ToString() + " Client IP is Already present");
           listener.Send(responseBytes, responseBytes.Length, clientEndpointAddress);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

    }

   
}