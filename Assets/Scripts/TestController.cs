using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TestController : MonoBehaviour
{

    public ReturnResult SimpleMethod(IDictionary<string, object> namedParameters = null)
    {
        if (namedParameters == null)
        {
            namedParameters = new Dictionary<string, object>();
            namedParameters.Add("wall", "1");
        }
           

        Debug.Log("Cool, fire via http connect ");
        foreach (KeyValuePair<string, object> kv in namedParameters)
        {
            Debug.Log(kv.Value.ToString());
        }
            
        string wall = namedParameters["wall"].ToString();
        Debug.Log("Cool, fire via http connect " + wall);

        ReturnResult result = new ReturnResult
        {
            code = 1,
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