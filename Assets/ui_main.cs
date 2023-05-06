using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ui_main : MonoBehaviour
{
    [SerializeField] public GameObject _elements = null;
    [SerializeField] public TextMeshProUGUI _goldText = null;
    [SerializeField] public TextMeshProUGUI _gemsText = null;
    [SerializeField] public TextMeshProUGUI _elixirText = null;
    [SerializeField] private Button _shopButton = null;

    private static ui_main _instance = null; public static ui_main instanse { get { return _instance; } }

    private void Awake()
    {
         _instance = this;
         _elements.setActive(true);
    }

    private void Start()
    {
        _shopButton.onClick.AddListener(ShopButtonClicked);
    }
    private void ShopButtonClicked()
    {
        ui_shop.instanse._elements.setActive(true);
        _elements.setActive(false);
    }
}
