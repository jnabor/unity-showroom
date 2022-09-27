using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    public List<GameObject> colouredObjects = new List<GameObject>();
    public List<Material> mColourSet = new List<Material>();

    private int currentColourIndex = 0;

    public void SetNextColour()
    {
        if (mColourSet.Count == 0)
            return;

        if (currentColourIndex < mColourSet.Count - 1)
        {
            currentColourIndex++;
        }
        else if (currentColourIndex == mColourSet.Count - 1)
        {
            currentColourIndex = 0;
        }

        SetPartMaterial(mColourSet[currentColourIndex]);
    }

    private void SetPartMaterial(Material lMaterial)
    {
        if (colouredObjects.Count == 0)
            return;


        foreach (GameObject colouredObject in colouredObjects)
        {
            colouredObject.GetComponent<MeshRenderer>().material = lMaterial;
        }
    }

}
