using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Silksong.FsmUtil;
using UnityEngine;

namespace Silksong.Rando.Locations
{
    public class HeartPieceLocation : ItemLocation
    {
        private PlayMakerFSM fsm;
        public HeartPieceLocation(PlayMakerFSM fsm)
        {
            this.fsm = fsm;
        }

        public override string GetItem()
        {
            return "Heart Piece";
        }

        public override void SetItem(string item)
        {
            Object.Destroy(fsm.gameObject.GetComponent<PersistentBoolItem>());

            var state = fsm.GetState("UI");
            state.RemoveAction(1);
            state.RemoveAction(0);
            
            state.AddAction(fsm.GetState("End").GetAction<RemoveHeroInputBlocker>(0));
            state.AddAction(fsm.GetState("End").GetAction<FsmStateAction>(1));
            state.AddAction(new SendEventToRegister()
            {
                eventName = "HEART PIECE COLLECTED"
            });
            state.AddLambdaMethod((fin) =>
            {
                AwardCollectable();
                PlayerData.instance.isInvincible = false;
                PlayerData.instance.disablePause = false;
                HeroController.instance.StartAnimationControl();
                HeroController.instance.RegainControl();
                HeroController.instance.AffectedByGravity(true);
                HeroController.instance.rb2d.gravityScale = HeroController.instance.DEFAULT_GRAVITY;
                HeroController.instance.currentGravity = HeroController.instance.DEFAULT_GRAVITY;
                HeroController.instance.prevGravityScale = 0.0f;
                fin();
            });
            
            fsm.RemoveState("Save Collected");
            
            state.RemoveTransitions();
            state.AddTransition("FINISHED", "End");

        }

        public override GameObject GetObj()
        {
            return fsm.gameObject;
        }

    }
}