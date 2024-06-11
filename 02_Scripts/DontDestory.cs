using System.Collections.Generic;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    private static List<string> dontDestoryObject = new List<string>();

    void Awake(){
        if(dontDestoryObject.Contains(gameObject.name))
        {
            Destroy(gameObject);
            return;
        }else{
            dontDestoryObject.Add(gameObject.name);
            DontDestroyOnLoad(gameObject);
        }
    }
}
