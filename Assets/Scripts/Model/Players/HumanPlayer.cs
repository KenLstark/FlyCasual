﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players
{

    public partial class HumanPlayer : GenericPlayer
    {

        public HumanPlayer() : base()
        {
            Type = PlayerType.Human;
            Name = "Human";
        }

        public override void PerformAction()
        {
            (Phases.CurrentSubPhase as SubPhases.ActionDecisonSubPhase).ShowActionDecisionPanel();
            UI.ShowSkipButton();
        }

        public override void PerformFreeAction()
        {
            (Phases.CurrentSubPhase as SubPhases.FreeActionDecisonSubPhase).ShowActionDecisionPanel();
            UI.ShowSkipButton();
        }

        public override void PerformAttack()
        {
            UI.ShowSkipButton();
        }

        public override void UseOwnDiceModifications()
        {
            Combat.ShowOwnDiceResultMenu();
        }

        public override void UseOppositeDiceModifications()
        {
            Combat.ShowOppositeDiceResultMenu();
        }

        public override void TakeDecision()
        {
            GameObject.Find("UI").transform.Find("DecisionsPanel").gameObject.SetActive(true);
        }

        public override void AfterShipMovementPrediction()
        {
            Selection.ThisShip.AssignedManeuver.LaunchShipMovement();
        }

        public override void ConfirmDiceCheck()
        {
            (Phases.CurrentSubPhase as SubPhases.DiceRollCheckSubPhase).ShowConfirmButton();
        }

        public override void ToggleCombatDiceResults(bool isActive)
        {
            (Phases.CurrentSubPhase as SubPhases.DiceRollCombatSubPhase).ToggleConfirmButton(isActive);
        }

    }

}
