using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TestController : MonoBehaviour
{
    public List<GameObject> colouredObjects = new List<GameObject>();
    public List<Material> mColourSet = new List<Material>();

    public void SetMaterialColour(int index)
    {
        if (mColourSet.Count < index)
            return;

        SetPartMaterial(mColourSet[index]);
    }

    private void SetPartMaterial(Material lMaterial)
    {
        foreach (GameObject colouredObject in colouredObjects)
        {
            colouredObject.GetComponent<MeshRenderer>().material = lMaterial;
        }
    }

    public ReturnResult RenderScene(string wall = "1")
    {

        Debug.Log("Cool, fire via http connect " + wall);


        int wallIndex = int.Parse(wall);

        ExecuteOnMainThread.RunOnMainThread.Enqueue(() => {
            SetMaterialColour(wallIndex);
        });

        

        ReturnResult result = new ReturnResult
        {
            code = wallIndex,
            msg = "testing wall " + wall
        };

        return result;
    }

    public string[] SimpleStringMethod()
    {
        return new string[]{
            "result","result2"
        };
    }
    public int[] SimpleIntMethod()
    {
        return new int[]{
            1,2
        };
    }

    public ReturnResult CustomObjectReturnMethod()
    {
        ReturnResult result = new ReturnResult
        {
            code = 1,
            msg = "testing"
        };
        return result;
    }
    public ReturnResult CustomObjectReturnMethodWithQuery(int code, string msg)
    {
        ReturnResult result = new ReturnResult
        {
            code = code,
            msg = msg
        };
        return result;
    }

    //Mark as Serializable to make Unity's JsonUtility works.
    [System.Serializable]
    public class ReturnResult
    {
        public string msg;
        public int code;
    }

}