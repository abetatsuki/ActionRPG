using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{

    ///<summary>親オブジェクト</summary>
    [SerializeField] private GameObject _panel;
    ///<summary>生成するボタンのプレハブ</summary>
    [SerializeField] private GameObject _buttonPrefab;
    ///<summary>
    ///アイテムの強化を選ぶボタンを生成する
    ///</summary>
    public void GeneretButton(string itemname)
    {
       GameObject buttonobj = Instantiate(_buttonPrefab, _panel.transform); 
        TMP_Text buttonText = buttonobj.GetComponentInChildren<TMP_Text>();
        if(buttonText != null)
        {
            buttonText.text = itemname;
        }
        
        Button button = buttonobj.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnButton(itemname));
        }
 
    }

    private void OnButton(string itemname)
    {
        Debug.Log($"{itemname}を選択しました");
    }
}
