using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    public int hiveTotal;

    public int nectarCount;

    public static Singleton Instance
    {
        // Here we use the ?? operator, to return 'instance' if 'instance' does not equal null
        // otherwise we assign instance to a new component and return that
        get { return instance ?? (instance = new GameObject("Singleton").AddComponent<Singleton>()); }
    }



}


