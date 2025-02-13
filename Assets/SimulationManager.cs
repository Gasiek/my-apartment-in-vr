using System;
using UnityEngine;
using UnityEngine.InputSystem;

public enum SimulationMode
{
    Walls,
    Furniture
}

public class SimulationManager : MonoBehaviour
{
    [SerializeField] private GameObject furniture;
    private XRIDefaultInputActions _inputActions;
    private SimulationMode _currentMode;

    private void Awake()
    {
        _inputActions = new XRIDefaultInputActions();
        _currentMode = SimulationMode.Furniture;
        furniture.SetActive(true);
    }

    private void OnEnable()
    {
        _inputActions.XRIRight.Enable();
        _inputActions.XRIRight.PrimaryAction.performed += SwitchMode;
    }

    private void OnDisable()
    {
        _inputActions.XRIRight.Disable();
        _inputActions.XRIRight.PrimaryAction.performed -= SwitchMode;
    }

    private void SwitchMode(InputAction.CallbackContext obj)
    {
        if (_currentMode == SimulationMode.Walls)
        {
            _currentMode = SimulationMode.Furniture;
            furniture.SetActive(true);
        }
        else
        {
            _currentMode = SimulationMode.Walls;
            furniture.SetActive(false);
        }
    }
}