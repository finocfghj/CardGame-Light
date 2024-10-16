using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UIElements;

public class GameObjectCreator : MonoBehaviour
{
    public static GameObjectCreator instance;

    private void Start()
    {
        instance = this;
    }

    public GameObject CreateObject(GameObject objectToCreate,Transform father)
    {
        var newObject = Instantiate(objectToCreate, father.position, Quaternion.identity);
        newObject.transform.SetParent(father, false);
        return newObject;
    }
}
