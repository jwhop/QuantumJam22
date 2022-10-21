using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using UnityEngine.SceneManagement;

public class SimpleSerial : MonoBehaviour
{
    public static SimpleSerial Instance { get; private set; }
    public String portName = "COM6";  // use the port name for your Arduino, such as /dev/tty.usbmodem1411 for Mac or COM3 for PC

    private SerialPort serialPort = null; 
    private int baudRate = 115200;  // match your rate from your serial in Arduino
    private int readTimeOut = 100;

    private string serialInput;

    bool programActive = true;
    Thread thread;
    private bool started;
    private float startedTimer;


    void Start()
    {
        Instance = this;
        try
        {
            serialPort = new SerialPort();
            serialPort.PortName = portName;
            serialPort.BaudRate = baudRate;
            serialPort.ReadTimeout = readTimeOut;
            serialPort.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        thread = new Thread(new ThreadStart(ProcessData));  // serial events are now handled in a separate thread
        thread.Start();
        started = false;
        startedTimer = 2f;
    }

    void ProcessData()
    {
        Debug.Log("Thread: Start");
        while (programActive)
        {
            try
            {
                serialInput = serialPort.ReadLine();
            }
            catch (TimeoutException)
            {

            }
        }
        Debug.Log("Thread: Stop");
    }

    void Update()
    {
        if (serialInput != null)
        {
            
            if(serialInput == "FAIL")
            {
                //trigger end of game
                print("FAILING");
                Dramadrama.Instance.SetLoseState();
            }
            else if (serialInput == "SUCCESS")
            {
                //keep playing game 
                print("SUCCESS");
                Dramadrama.Instance.ResolveDrama();
            }
        }
        
    }

    public void Write(int numButtons)
    {
        print("writing.." + numButtons);
        serialPort.WriteLine(numButtons.ToString());
    }

    

    public void OnDisable()  // attempts to closes serial port when the gameobject script is on goes away
    {
        programActive = false;
        if (serialPort != null && serialPort.IsOpen)
            serialPort.Close();
    }
}