using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds some Spectrum Data
public class SpectrumData
{
    public int index;
    public float data;
    public float dataNormalized;

    // Add data to the list and count up

    public void AddData(float data)
    {
        this.data += data;
    }
}
