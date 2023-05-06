using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ui_shop : MonoBehaviour
{

    [SerializeField] public GameObject _elements = null;

        
    private static ui_shop _instance = null; public static ui_shop instanse { get { return _instance; } }

    private void Awake()
    {
         _instance = this;
         _elements.setActive(false);
    }
}
