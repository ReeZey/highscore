using UnityEngine;


namespace Rizing.Abstract {
    [CreateAssetMenu]
    public class Item : ScriptableObject {
        public int id;
        public Sprite sprite;
        
        public Item() {
            id = 0;
        }
        
        public Item(int id) {
            this.id = id;
        }
    }
}