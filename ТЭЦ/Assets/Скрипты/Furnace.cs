using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Furnace : MonoBehaviour
{
    public Text Temperature_p; //Вывод данных

    public float temperature_float; //Программна работа с температурой(округление преобразованием)
    private int temperature_int;

    public int Max_fuel_temperature; 
    public int Normal_temperature;
    public int Water_temperature;


    //Кол-во топлива
    public int kolvo_fuel = 100;
    private int max_xp_fuel = 2000;
    [SerializeField]private float xp_fuel;
    //Управляющие слайдеры
    [SerializeField] private Slider Slnagreva;
    [SerializeField] private Slider WaterSlider;

    [SerializeField] private Text ToolTip_txt;//Текст зажигания
    [SerializeField] private GameObject ToolTip;
    private bool IsStartIgnition = false;
    private bool IsStart;
    private float TimerTxt;
    [SerializeField] private int TimeTxt;
    private void Start()
    {
        temperature_float = Normal_temperature;
    }
    private void Update()
    {
        //Изменение температуры: 1) + От печи 2) - От воды
        if (temperature_float < Max_fuel_temperature && IsStart == true) { // Запущена ли печь, и меньше ли её температура, чем температура горения топлива
            temperature_float += (Max_fuel_temperature - temperature_float) * Slnagreva.value * Time.deltaTime;
        }

        if (temperature_float > Water_temperature) {
            temperature_float -= (temperature_float - Water_temperature) * WaterSlider.value * Time.deltaTime;
        }




        if (IsStart) 
        {
            xp_fuel -= Slnagreva.value * Time.deltaTime * 100000;
        }
        if (xp_fuel <= 0 && kolvo_fuel > 0) 
        {
            kolvo_fuel -= 1;
            xp_fuel = max_xp_fuel;
        }
        if (kolvo_fuel <= 0) {
            Slnagreva.value = 0;
        
        }





        //Преобразование температуры, вывод на Canvas Txt
        temperature_int = (int)temperature_float;
        string temperature_str = temperature_int.ToString();
        Temperature_p.text = temperature_str;




        //Зажигание
        if(Slnagreva.value > 0 && IsStartIgnition == false){
            ToolTip_txt.text = "Зажигание...";
            ToolTip.SetActive(true);
            TimerTxt = Time.realtimeSinceStartup;
            IsStartIgnition = true;
        }




        //Два случая выключения выходящего окна
        if (TimerTxt <= Time.realtimeSinceStartup - TimeTxt && Slnagreva.value > 0 && IsStart == false)
        {
            ToolTip.SetActive(false);
            IsStart = true;
            Debug.Log("Печь программно запущена");
        }
        else if (TimerTxt <= Time.realtimeSinceStartup - TimeTxt && ToolTip.activeSelf == true) {
            ToolTip.SetActive(false);
            Debug.Log("Печь программно остановлена");
        }



        //Остановка печи, текст, обнуление bool
        if (Slnagreva.value == 0 && IsStartIgnition == true)
        {
             ToolTip_txt.text = "Печь остановлена";
             ToolTip.SetActive(true);
             TimerTxt = Time.realtimeSinceStartup;
             IsStartIgnition = false;
             IsStart = false;
        }
    }
}
