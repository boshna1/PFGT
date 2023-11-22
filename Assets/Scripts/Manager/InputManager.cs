using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public static class InputManager
{
    private static GameControls _gameControls;
    
    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();
        _gameControls.Permanent.Enable();
        

        _gameControls.InGame.Movement.performed += w => 
        {
            myPlayer.SetMovementDirection(w.ReadValue<Vector3>());
        };

        _gameControls.InGame.Jump.performed += w =>
        {
            myPlayer.SetJump();  
        };

        _gameControls.InGame.ShootHold.performed += co =>
        {     

            while (DisplayText.instance.GetBullet() > 0 && myPlayer.GetDisableShoot() == false)
            {
                    myPlayer.Shoot();
                    myPlayer.Recoil();
                    DisplayText.instance.RemoveBullet();
            }
        };

        _gameControls.InGame.Look.performed += ctx =>
        {
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _gameControls.InGame.Reload.performed += w =>
        {
            if (DisplayText.instance.GetBullet() < 28)
            { 
            DisplayText.instance.Reload();
            }
        };
        _gameControls.InGame.SwitchWeaponSniper.performed += w =>
        {
            myPlayer.SwitchSniper();
        };
        _gameControls.InGame.SwitchWeaponShotgun.performed += w =>
        {
            myPlayer.SwitchShotgun();
        };
        _gameControls.InGame.SwitchWeaponAR.performed += w =>
        {
            myPlayer.SwitchAR();
        };
        _gameControls.InGame.SwitchWeaponBurst.performed += w =>
        {
            myPlayer.SwitchBurst();
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
