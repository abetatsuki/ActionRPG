using TMPro;
using UnityEngine;

public class HeadMarkController : MonoBehaviour
{
    [SerializeField] private TMP_Text headMark; // 💬や！などのテキスト

    private void Start()
    {
        headMark.gameObject.SetActive(false); // 初期は非表示
    }

    public void ShowMark()
    {
        headMark.gameObject.SetActive(true);
    }

    public void HideMark()
    {
        headMark.gameObject.SetActive(false);
    }

}
