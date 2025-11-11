using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _sprite2;
    private Image _image;

    private void Start()
    {
       _image = GetComponent<Image>();
        _sprite2 = _image.sprite;
    }

    public void ChangeSprite()
    {
        if (_image.sprite == _sprite)
        {
            _image.sprite = _sprite2;
        }
        else
        {
            _image.sprite = _sprite;
        }
    }

}
