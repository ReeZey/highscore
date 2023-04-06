using Rizing.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : SingletonMono<InputManager>
{
    [SerializeField] private PlayerInput playerInput;
    public InputAction GetKey(string key) => playerInput.actions[key];
}
