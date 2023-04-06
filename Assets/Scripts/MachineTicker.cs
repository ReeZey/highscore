using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Rizing.Abstract {
    public class MachineTicker : MonoBehaviour {
        private Tilemap tilemap;
        
        private float ticker;
        private float ticks_per_action = 1f;

        private Dictionary<ITick, ITick> tickers = new Dictionary<ITick, ITick>();

        private void Start() {
            tilemap = GetComponent<Tilemap>();
        }

        private void Update() {
            ticker += Time.deltaTime;

            if (!(ticker > ticks_per_action)) return;
            ticker = 0;
            
            foreach (ITick child in GetComponentsInChildren<ITick>()) {
                var tick = child.check(tilemap);
                if(tick == null) continue;
                
                tickers.Add(child, tick);
            }

            foreach (var kvp in tickers) {
                kvp.Key.tick(kvp.Value);
            }
            
            tickers.Clear();
        }
    }
}