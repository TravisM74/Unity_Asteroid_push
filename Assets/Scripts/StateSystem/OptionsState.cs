using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class OptionsState : GameStateBase {
    public override Type StateType {
        get { return Type.Options; }
    }

    public override string SceneName {
        get {
            return "Options";
        }
    }


    public OptionsState() : base(isAdditive: true) {

        AddTargetState(Type.Level);
        AddTargetState(Type.Menu);
    }
}
