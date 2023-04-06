using Rizing.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class Placement : MonoBehaviour {
    [SerializeField] private GameObject selection;
    [SerializeField] private Tilemap build_tilemap;
    [SerializeField] private TileBase current_build_block;
    [SerializeField] private Item current_item;
    
    private Camera cam;
    private Vector3Int selection_pos;
    private InputManager inputManager;
    
    private void Start() {
        cam = Camera.main;
        inputManager = InputManager.Instance;
    }

    private void Update() {
        var world_point = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        selection_pos = Vector3Int.FloorToInt(world_point);
        selection_pos.z = 0;
        
        selection.transform.position = Vector3.Lerp(selection.transform.position, selection_pos + new Vector3(0.5f, 0.5f), 0.1f);

        if (inputManager.GetKey("LeftClick").triggered) {
            build_tilemap.SetTile(selection_pos, current_build_block);
        }
        
        if (inputManager.GetKey("RightClick").triggered) {
            var tile = build_tilemap.GetTile(selection_pos);

            if (!(tile is ConveyorTile)) return;

            var obj = build_tilemap.GetInstantiatedObject(selection_pos).GetComponent<ConveyorData>();
            obj.SetHeldItem(current_item);
        }
    }
}
