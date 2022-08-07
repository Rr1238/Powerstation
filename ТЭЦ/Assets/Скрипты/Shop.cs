using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject SHOP;

    //Доступ к переменным другого скрипта через этот объект
    public Furnace Furnace_script;
    public Steam Steam_script;

    public void Buy() 
    {
        if(Steam_script.Money_float >= 50)
        {
            Steam_script.Money_float -= 50;
            Furnace_script.kolvo_fuel += 100;
        }
    }


    public void OpenShop()
    {
        SHOP.SetActive(true);

    }
    public void CloseShop() 
    {
        SHOP.SetActive(false);
    }
}
