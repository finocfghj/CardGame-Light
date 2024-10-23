using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UIElements;

public class GameObjectCreator : MonoBehaviour
{
    public static GameObjectCreator instance;
    //public static GameObject 

    private void Awake()
    {
        instance = this;
    }

    public GameObject CreateObject(GameObject objectToCreate,Transform father)
    {
        var newObject = Instantiate(objectToCreate, father.position, Quaternion.identity);
        newObject.transform.SetParent(father, false);
        return newObject;
    }
    
    public GameObject CreateObject(GameObject objectToCreate)
    {
        var newObject = Instantiate(objectToCreate);
        return newObject;
    }


}
