using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : SurMonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance => _instance;

    [SerializeField] protected bool _Press_Left = false;
    public bool Press_Left => _Press_Left;

    [SerializeField] protected bool _Press_Right = false;
    public bool Press_Right => _Press_Right;

    [SerializeField] protected bool _Press_Jump = false;
    public bool Press_Jump => _Press_Jump;

    [SerializeField] protected bool _Press_Attack_Throw = false;
    public bool Press_Attack_Throw => this._Press_Attack_Throw;

    [SerializeField] protected bool _Press_Attack_Dashing = false;
    public bool Press_Attack_Dashing => _Press_Attack_Dashing;

    [SerializeField] protected bool _Press_Hidden_Mode = false;
    public bool Press_Hidden_Mode => _Press_Hidden_Mode;

    [SerializeField] protected bool isRiviving;
    public bool IsRiviving => isRiviving;

    public static Action PressJumpButton_Event;
    public static Action PressDashingButton_Event;
    public static Action PressHiddenButton_Event;
    public static Action PressAttackThrowButton_Event;

    protected override void Awake()
    {
        base.Awake();

        if (_instance != null) Debug.LogError("Only InputManager was allowed existed");

        _instance = this;
    }

    protected override void Start()
    {
        base.Start();
        // Application.targetFrameRate = 30;

        // Sử dụng frame rate tối đa mà thiết bị có thể hỗ trợ
        Application.targetFrameRate = -1;

    }
    protected virtual void Update()
    {
        //// Kiểm tra phím mũi tên lên
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Mũi tên lên được nhấn");
            this.PointerJumpDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Debug.Log("Mũi tên lên được nhấn");
            this.PointerJumpUp();
        }

        // Kiểm tra phím mũi tên trái
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Debug.Log("Mũi tên trái được nhấn");
            this.PointerLeftDown();
        }
        // Kiểm tra phím mũi tên trái
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //Debug.Log("Mũi tên trái được nhấn");
            this.PointerLeftUp();
        }

        // Kiểm tra phím mũi tên phải
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerRightDown();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerRightUp();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerAttackThrowDown();
            PlayerCtrl.Instance.PlayerAttack.PerformAttackThrowShuriken();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("Mũi tên phải được nhấn");
            this.PointerAttackDashingDown();
        }

        this.UpdateConfigEndGame();
    }

    protected virtual void UpdateConfigEndGame()
    {
        if (GateEntranceAutoRun.Instance.WasCom_Mission) this.PointerRightUp();
    }

    //Left
    public virtual void PointerLeftDown()
    {
        this._Press_Left = true;
        this._Press_Right = false;
    }
    public virtual void PointerLeftUp()
    {
        this._Press_Left = false;
    }

    //Right
    public virtual void PointerRightDown()
    {
        this._Press_Left = false;
        this._Press_Right = true;
    }
    public virtual void PointerRightUp()
    {
        this._Press_Right = false;
    }

    //Jump
    public virtual void PointerJumpDown()
    {
        if (this._Press_Hidden_Mode) return;

        this._Press_Jump = true;
        PressJumpButton_Event?.Invoke();
    }
    public virtual void PointerJumpUp()
    {
        this._Press_Jump = false;
    }

    //Attack Throw
    public virtual void PointerAttackThrowDown()
    {
        if (this._Press_Hidden_Mode) return;

        this._Press_Attack_Throw = true;
        PressAttackThrowButton_Event?.Invoke();
    }

    public virtual void PointerAttackThrowPresAndUp()
    {
        this._Press_Attack_Throw = false;
        // Debug.Log("UnPress Attack throw");
    }

    //Attack Dashing
    public virtual void PointerAttackDashingDown()
    {
        if (this._Press_Hidden_Mode) return;

        this._Press_Attack_Dashing = true;
        PressDashingButton_Event?.Invoke();
        //   Debug.Log("Press Attack throw");
    }

    public virtual void PointerAttackDashingPresAndUp()
    {
        this._Press_Attack_Dashing = false;
    }

    //Hidden
    public virtual void PointerHidenModeSkillDown()
    {
        //only for sound use event
        PressHiddenButton_Event?.Invoke();

        if (this._Press_Hidden_Mode)
        {
            this.PointerHidenModeSkillPresAndUp();
            ButtonHidenSkillActiveByTime.Instance.ResetTimer();
            return;
        }
        this._Press_Hidden_Mode = true;

    }

    public virtual void PointerHidenModeSkillPresAndUp()
    {
        this._Press_Hidden_Mode = false;
    }

    //Riviving
    public virtual void PlayerRiviveAgain()
    {
        this.isRiviving = true;
        //   Debug.Log("Press Attack throw");
    }

    public virtual void PlayerRiviveAgainCompleted()
    {
        this.isRiviving = false;
    }

    //Dead
    public virtual void SetFalseAllBoolWhenPlayerDead()
    {
        this.PointerAttackDashingPresAndUp();
        this.PointerAttackThrowPresAndUp();
        this.PointerHidenModeSkillPresAndUp();
        this.PointerJumpUp();

        this.PointerLeftUp();
        this.PointerRightUp();
    }

}
