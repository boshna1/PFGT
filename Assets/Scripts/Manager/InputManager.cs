using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class InputManager
{
    private static GameControls _gameControls;
    public static void Init(Player myPlayer,Object Sphere, float x, float y, float z,Quaternion CowR,Transform Cow)
    {
        _gameControls = new GameControls();
        _gameControls.Permanent.Enable();

        _gameControls.InGame.Movement.performed += w => 
        {
            myPlayer.SetMovementDirection(w.ReadValue<Vector3>());
        };

        _gameControls.InGame.Jump.performed += w =>
        {
            myPlayer.SetJump(w.ReadValue<Vector3>());  
        };

        _gameControls.InGame.Shoot.performed += w =>
        {
            Object.Instantiate(Sphere,new Vector3(Cow.position.x,Cow.position.y + 1,Cow.position.z + 2),CowR,Cow);
        };
    }
    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();
        _gameControls.UI.Disable();
    }
    public static void SetUIControls()
    {
        _gameControls.InGame.Disable();
        _gameControls.UI.Enable();
    }
}
