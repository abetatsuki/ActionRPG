using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    /// <summary>変更した後のSpite </summary>
    [SerializeField] private Sprite _sprite;
    private Sprite _sprite2;
    private Image _image;

    private void Start()
    {
       _image = GetComponent<Image>();
        _sprite2 = _image.sprite;
    }
    ///<summary>スプライトを変更する</summary>
    public void ChangeSprite(Sprite sprite)
    {
        if (_image.sprite == sprite) return;
        else _image.sprite = sprite;
    }

}
