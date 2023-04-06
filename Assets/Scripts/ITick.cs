using UnityEngine.Tilemaps;

namespace Rizing.Abstract {
    public interface ITick {
        public ITick check(Tilemap tilemap);
        public void tick(ITick tick);
    }
}