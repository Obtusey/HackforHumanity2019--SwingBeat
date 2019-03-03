using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerOne : MonoBehaviour
{
    public GameObject cubePrefab;

    Dictionary<int, GameObject> cubes = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> pcubes = new Dictionary<int, GameObject>();
    Dictionary<int, SpectrumData> spectrumDataList = new Dictionary<int, SpectrumData>();

    int[][] spectrumRanges;

    void Start()
    {
        // Array that defines which audio hz ranges we want to use
        spectrumRanges = new int[31][]
        {
            new int[2] {40, 60},
            new int[2] {61, 80},
            new int[2] {81, 100},
            new int[2] {101, 120},
            new int[2] {121, 140},
            new int[2] {141, 160},
            new int[2] {161, 180},
            new int[2] {181, 200},
            new int[2] {201, 220},
            new int[2] {221, 240},
            new int[2] {241, 260},
            new int[2] {261, 280},
            new int[2] {281, 300},
            new int[2] {301, 350},
            new int[2] {351, 400},
            new int[2] {401, 450},
            new int[2] {451, 500},
            new int[2] {501, 550},
            new int[2] {551, 600},
            new int[2] {601, 650},
            new int[2] {651, 700},
            new int[2] {701, 800},
            new int[2] {801, 900},
            new int[2] {901, 1000},
            new int[2] {1001, 1200},
            new int[2] {1201, 1400},
            new int[2] {1401, 1600},
            new int[2] {1601, 1800},
            new int[2] {1801, 2000},
            new int[2] {2001, 2250},
            new int[2] {2251, 2500}
        };
        // For loop to create data objects for each range
        for (int i = 0; i < spectrumRanges.Length; i++)
        {
            var group = new SpectrumData
            {
                index = i
            };
            spectrumDataList.Add(i, group);
        }
        // Function called to initialize the spectrum data list
        UpdateSpectrumDataList();
        var count = 1;

        // Foreach to create the cubes for each data range
        foreach (var item in spectrumDataList)
        {

            // Creates a circle of rectangles
            var group = item.Value;
            var rotate = 360f / spectrumDataList.Count * count;

            var cube1 = Instantiate(cubePrefab);
            cube1.transform.SetParent(transform);
            cube1.name = group.index.ToString();
            cube1.transform.position = new Vector3(-22, 0, -65);
            cube1.transform.Rotate(new Vector3(0, rotate, 0));
            cube1.transform.Translate(new Vector3(12f, 0, 0), Space.Self);
            cube1.SetActive(true);

            var cube2 = Instantiate(cubePrefab);
            cube2.transform.SetParent(transform);
            cube2.name = group.index.ToString();
            cube2.transform.position = new Vector3(-22, 0, -65);
            cube2.transform.Rotate(new Vector3(0, rotate, 0));
            cube2.transform.Translate(new Vector3(10f, 0, 0), Space.Self);
            cube2.SetActive(true);

            var cube3 = Instantiate(cubePrefab);
            cube3.transform.SetParent(transform);
            cube3.name = group.index.ToString();
            cube3.transform.position = new Vector3(-22, 0, -65);
            cube3.transform.Rotate(new Vector3(0, rotate, 0));
            cube3.transform.Translate(new Vector3(7f, 0, 0), Space.Self);
            cube3.SetActive(true);

            var cube4 = Instantiate(cubePrefab);
            cube4.transform.SetParent(transform);
            cube4.name = group.index.ToString();
            cube4.transform.position = new Vector3(-22, 0, -65);
            cube4.transform.Rotate(new Vector3(0, rotate, 0));
            cube4.transform.Translate(new Vector3(4f, 0, 0), Space.Self);
            cube4.SetActive(true);

            // Set cube color
            var color = Color.HSVToRGB(1f / spectrumDataList.Count * count, 1, 1);

            var mat1 = cube1.GetComponent<MeshRenderer>().material;
            mat1.color = color;

            var mat2 = cube2.GetComponent<MeshRenderer>().material;
            mat2.color = color;

            var mat3 = cube3.GetComponent<MeshRenderer>().material;
            mat3.color = color;

            var mat4 = cube4.GetComponent<MeshRenderer>().material;
            mat4.color = color;

            cubes.Add(group.index, cube1);

            // Create a bouncing cube on top of rectangles

            var pos1 = cube1.transform.position;
            pos1.y = 10f;
            var physicsCube1 = Instantiate(cubePrefab);
            physicsCube1.name = group.index + " Tiny1";
            physicsCube1.transform.SetParent(transform);
            physicsCube1.transform.position = pos1;
            physicsCube1.transform.rotation = cube1.transform.rotation;
            physicsCube1.transform.localScale = Vector3.one * 0.5f;
            physicsCube1.SetActive(true);

            var pos2 = cube1.transform.position;
            pos2.y = 20f;
            var physicsCube2 = Instantiate(cubePrefab);
            physicsCube2.name = group.index + " Tiny2";
            physicsCube2.transform.SetParent(transform);
            physicsCube2.transform.position = pos2;
            physicsCube2.transform.rotation = cube2.transform.rotation;
            physicsCube2.transform.localScale = Vector3.one * 0.5f;
            physicsCube2.SetActive(true);

            var pos3 = cube1.transform.position;
            pos3.y = 30f;
            var physicsCube3 = Instantiate(cubePrefab);
            physicsCube3.name = group.index + " Tiny3";
            physicsCube3.transform.SetParent(transform);
            physicsCube3.transform.position = pos3;
            physicsCube3.transform.rotation = cube2.transform.rotation;
            physicsCube3.transform.localScale = Vector3.one * 0.5f;
            physicsCube3.SetActive(true);

            var pos4 = cube1.transform.position;
            pos4.y = 30f;
            var physicsCube4 = Instantiate(cubePrefab);
            physicsCube4.name = group.index + " Tiny4";
            physicsCube4.transform.SetParent(transform);
            physicsCube4.transform.position = pos4;
            physicsCube4.transform.rotation = cube2.transform.rotation;
            physicsCube4.transform.localScale = Vector3.one * 0.5f;
            physicsCube4.SetActive(true);

            var pos5 = cube1.transform.position;
            pos5.y = 30f;
            var physicsCube5 = Instantiate(cubePrefab);
            physicsCube5.name = group.index + " Tiny5";
            physicsCube5.transform.SetParent(transform);
            physicsCube5.transform.position = pos5;
            physicsCube5.transform.rotation = cube2.transform.rotation;
            physicsCube5.transform.localScale = Vector3.one * 0.7f;
            physicsCube5.SetActive(true);

            // Set rigidbody, freeze x and z positions so it doesn't move off audio visualizer, set to always awake
            var rig1 = physicsCube1.AddComponent<Rigidbody>();
            rig1.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig1.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rig1.sleepThreshold = 0;

            var rig2 = physicsCube2.AddComponent<Rigidbody>();
            rig2.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig2.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rig2.sleepThreshold = 0;

            var rig3 = physicsCube3.AddComponent<Rigidbody>();
            rig3.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig3.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rig3.sleepThreshold = 0;

            var rig4 = physicsCube4.AddComponent<Rigidbody>();
            rig4.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig4.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rig4.sleepThreshold = 0;

            var rig5 = physicsCube5.AddComponent<Rigidbody>();
            rig5.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig5.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rig5.sleepThreshold = 0;

            // Set cube color
            mat1 = physicsCube1.GetComponent<MeshRenderer>().material;
            mat1.color = color;

            mat2 = physicsCube2.GetComponent<MeshRenderer>().material;
            mat2.color = color;

            //pcubes.Add(group.index, physicsCube1);
            count++;
            
        }
    }


    void Update()
    {
        UpdateSpectrumDataList();
        SpectrumData prevGroup = spectrumDataList[spectrumRanges.Length - 1];
        // Foreach to update every cube based on the spectrum data for a specific range
        foreach (var item in spectrumDataList)
        {
            var group = item.Value;
            var norm = group.dataNormalized;
            var cube = cubes[group.index];        
            var scale = Vector3.one;
            scale.y = norm * 80f;
            // just lerp to smooth things out a bit
            scale = Vector3.Lerp(cube.transform.localScale, scale, 0.4f);
            cube.transform.localScale = scale;
            prevGroup = group;
        }
    }


    public void UpdateSpectrumDataList()
    {
        // var to store how many hz each spectrum data sample how much hz does each spectrum data sample represent
        var hzPerSample = (AudioSettings.outputSampleRate / 8192f);

        // vars to store min/max data range to be able to normalize it later
        var min = Mathf.Infinity;
        var max = -Mathf.Infinity;
        var spectrumData = new float[8192];

        // Acquire spectrum data from the audio listener with the highest quality possible
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        for (int i = 0; i < spectrumRanges.Length - 1; i++)
        {
            var range = spectrumRanges[i];
            var group = spectrumDataList[i];
            group.data = 0;

            // Store the minimum and maximum data index that is valid in this range chunk
            var minIndex = Mathf.FloorToInt(range[0] / hzPerSample);
            var maxIndex = Mathf.CeilToInt(range[1] / hzPerSample);

            // Store data in the range group
            for (var si = minIndex; si <= maxIndex; si++)
            {
                group.AddData(spectrumData[si]);
            }

            // Store min/max data for normalization process
            if (min > group.data)
            {
                min = group.data;
            }
            if (max < group.data)
            {
                max = group.data;
            }
        }
        // Normalize data between 0 and 1
        foreach (var item in spectrumDataList)
        {
            item.Value.dataNormalized = Mathf.Clamp((item.Value.data - min) / (max - min), 0.01f, 2f);
        }
    }
}
