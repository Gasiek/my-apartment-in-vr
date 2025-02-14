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
    [SerializeField] private GameObject counterExtension;
    [SerializeField] private GameObject hokersBeforeExtension;
    [SerializeField] private GameObject hokersAfterExtension;
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
        _inputActions.XRIRightLocomotion.Enable();
        _inputActions.XRIRightLocomotion.PrimaryAction.performed += SwitchMode;
        _inputActions.XRIRightLocomotion.SecondaryAction.performed += ToggleCounterExtension;
    }
    
    private void OnDisable()
    {
        _inputActions.XRIRightLocomotion.Disable();
        _inputActions.XRIRightLocomotion.PrimaryAction.performed -= SwitchMode;
        _inputActions.XRIRightLocomotion.SecondaryAction.performed -= ToggleCounterExtension;
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
    private void ToggleCounterExtension(InputAction.CallbackContext obj)
    {
        Debug.Log(!counterExtension.activeSelf);
        hokersBeforeExtension.SetActive(counterExtension.activeSelf);
        hokersAfterExtension.SetActive(!counterExtension.activeSelf);
        counterExtension.SetActive(!counterExtension.activeSelf);
    }
}