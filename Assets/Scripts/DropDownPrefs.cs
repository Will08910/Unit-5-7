using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSaver : MonoBehaviour
{
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;

    private const string Dropdown1Key = "Dropdown1Value";
    private const string Dropdown2Key = "Dropdown2Value";


    private void Start()
    {

        if (PlayerPrefs.HasKey(Dropdown1Key))
        {
            dropdown1.value = PlayerPrefs.GetInt(Dropdown1Key);
        }

        if (PlayerPrefs.HasKey(Dropdown2Key))
        {
            dropdown2.value = PlayerPrefs.GetInt(Dropdown2Key);
        }


        dropdown1.onValueChanged.AddListener(delegate { SaveDropdownValue(Dropdown1Key, dropdown1.value); });
        dropdown2.onValueChanged.AddListener(delegate { SaveDropdownValue(Dropdown2Key, dropdown2.value); });
    }

    private void SaveDropdownValue(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
        PlayerPrefs.Save();
    }
}
