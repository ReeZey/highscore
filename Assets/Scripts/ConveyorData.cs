using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Rizing.Abstract {
    public class ConveyorData : MonoBehaviour, ITick {
        public Vector3Int direction;
        public Vector3Int position;

        public Item heldItem;

        private SpriteRenderer spriteRenderer;
        
        private void Start() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public ITick check(Tilemap tilemap) {
            if (heldItem == null) return null;
        
            var nextTile = tilemap.GetTile(position + direction);

            if (!(nextTile is ConveyorTile)) return null;
            
            var tick = tilemap.GetInstantiatedObject(position + direction).GetComponent<ConveyorData>();
            if (tick.heldItem != null) return null;
            return tick;
        }

        public void tick(ITick tile) {
            if (!(tile is ConveyorData conveyorData)) return;
            
            conveyorData.SetHeldItem(heldItem);
            SetHeldItem(null);
        }

        public void SetHeldItem(Item item) {
            heldItem = item;
            spriteRenderer.sprite = item != null ? item.sprite : null;
        }
    }
}