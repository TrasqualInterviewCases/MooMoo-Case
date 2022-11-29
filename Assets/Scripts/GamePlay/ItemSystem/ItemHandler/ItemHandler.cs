using UnityEngine;

namespace Main.GamePlay.ItemSystem
{
    public abstract class ItemHandler<T> : MonoBehaviour where T : ItemBase
    {
        public abstract void PickUpItem(T item);
        public abstract void DropItem();
    }
}