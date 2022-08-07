using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steam : MonoBehaviour
{
    //Доступ к переменным другого скрипта через этот объект
    public Furnace Furnace_script;

    public float Money_float;
    [SerializeField] private Text Money_txt;

    [SerializeField] private Slider WaterSlider;

    [SerializeField] public float profit_pump;

    void Update()
    {
        if (Furnace_script.temperature_float >= 140f) {
            Money_float += WaterSlider.value * profit_pump * Time.deltaTime;
        }
        Debug.Log(Money_float);
        Money_txt.text = "$ = " + ((int)Money_float).ToString() + " T = " + ((int)Furnace_script.kolvo_fuel).ToString();
;    }
}
