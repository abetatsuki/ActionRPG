using UnityEngine;

public interface IPickupable
{
    string GetItemName();          // UIやログ用
    Sprite GetIcon();              // インベントリUI用
}
