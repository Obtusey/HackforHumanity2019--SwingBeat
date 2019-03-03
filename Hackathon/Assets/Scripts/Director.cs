using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using JacobGames.SuperInvoke;

public class Director : MonoBehaviour {
    public Renderer m_Renderer;
    public float songDuration;
    public float songTempo;
    public float timeSignature;

    public int beat = 0;

    public float beatStart;
    public float beatDuration;
    public float beatConfidence;

    public void beatDirector()
    {

        double[] findBeatOne = new double[20000];
        double[] findDuration = new double[20000];
        double[] findConfidence = new double[20000];
        int arrayCounter = 1;
        int beatCounter = 0;
        int durationCounter = 0;
        int confidenceCounter = 0;
        string path = "D:\\Development\\Hackathon\\Hackathon\\Assets\\SongText\\Partition.txt";
        string[] lines = System.IO.File.ReadAllLines(path);
        foreach (string line in lines)
        {

            int arrayCondition = arrayCounter % 3;

            if (arrayCondition == 1)
            {
                findBeatOne[beatCounter] = Convert.ToDouble(line);
                beatCounter++;
            }
            if (arrayCondition == 2)
            {
                findDuration[durationCounter] = Convert.ToDouble(line);
                durationCounter++;
            }

            if (arrayCondition == 0)
            {
                findConfidence[confidenceCounter] = Convert.ToDouble(line);
                confidenceCounter++;
            }
            
            arrayCounter++;

        }

        SuperInvoke.RunRepeat(4.8111f, 2.37f/2, 200, SimpleCount);




        // m_Renderer.material.color = Color.red;
        // m_Renderer.material.color = Color.white;
    }

    private void SimpleCount()
    {
        Debug.Log("Beat!");
        if (m_Renderer.material.color == Color.red)
        {
            m_Renderer.material.color = Color.green;
        }
        else
        {
            m_Renderer.material.color = Color.red;
        }

    }


    public void Start()
    {

    }

    private void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.material.color = Color.green;
        beatDirector();
        StartCoroutine(StartBeat());
    }

    public void Update() {

    }

    IEnumerator StartBeat()
    {
            yield return new WaitForSeconds(1f);
    }
}