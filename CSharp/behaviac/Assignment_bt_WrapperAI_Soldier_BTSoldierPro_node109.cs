﻿namespace behaviac
{
    using Assets.Scripts.GameLogic;
    using System;

    internal class Assignment_bt_WrapperAI_Soldier_BTSoldierPro_node109 : Assignment
    {
        protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
        {
            EBTStatus status = EBTStatus.BT_SUCCESS;
            uint myObjID = ((ObjAgent) pAgent).GetMyObjID();
            pAgent.SetVariable<uint>("p_selfID", myObjID, 0x47e01b5e);
            return status;
        }
    }
}

