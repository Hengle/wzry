﻿using Assets.Scripts.GameSystem;
using Assets.Scripts.UI;
using System;
using UnityEngine;

internal class NewbieGuideClickPvpHuman : NewbieGuideBaseScript
{
    protected override void Initialize()
    {
    }

    protected override bool IsDelegateClickEvent()
    {
        return true;
    }

    protected override void Update()
    {
        if (base.isInitialize)
        {
            base.Update();
        }
        else
        {
            CUIFormScript form = Singleton<CUIManager>.GetInstance().GetForm(CMatchingSystem.PATH_MATCHING_ENTRY);
            if (form != null)
            {
                Transform transform = form.transform.FindChild("panelGroup1/btnGroup/Button1");
                if (transform != null)
                {
                    GameObject gameObject = transform.gameObject;
                    if (gameObject.activeInHierarchy)
                    {
                        base.AddHighLightGameObject(gameObject, true, form, true);
                        base.Initialize();
                    }
                }
            }
        }
    }
}

