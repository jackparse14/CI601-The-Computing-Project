using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;
    CursorController cursorController;
    
    InventoryUI inventoryUI;
    CameraOrbit cameraOrbit;
    ProcessInput processInput;
    //MOVE TO OTHER SCRIPTS
    bool isAltLeftClickInProgress = false;

    private void Awake()
    {
        cursorController = FindObjectOfType<CursorController>();
        
        cameraOrbit = FindObjectOfType<CameraOrbit>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        
        processInput = FindObjectOfType<ProcessInput>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Mouse.RightClick.started += context => processInput.ProcessRightClick(playerInputActions);
        playerInputActions.Mouse.LeftClick.started += context => processInput.ProcessLeftClick(playerInputActions, isAltLeftClickInProgress);
        /*playerInputActions.Mouse.AltLeftClick.started += context => {
            isAltLeftClickInProgress = true;
            cursorController.StartedLeftClick();
        };
        playerInputActions.Mouse.AltLeftClick.started += context => cameraOrbit.StartCameraRotation(playerInputActions);
        playerInputActions.Mouse.AltLeftClick.performed += context =>
        {
            isAltLeftClickInProgress = false;
            cursorController.EndedLeftClick();
            cameraOrbit.EndCameraRotation();
        };*/
        playerInputActions.Keyboard.I.started += context => inventoryUI.OpenCloseInventory();
    }

    #region - Enable/Disable -
    private void OnEnable()
    {
        playerInputActions.Enable();
    }
    public void OnDisable()
    {
        playerInputActions.Disable();
    }
    #endregion
}
