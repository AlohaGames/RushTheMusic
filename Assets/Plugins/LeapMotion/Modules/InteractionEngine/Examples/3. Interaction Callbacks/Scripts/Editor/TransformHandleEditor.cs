/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEditor;

namespace Leap.Unity.Examples
{

    [CustomEditor(typeof(TransformHandle), true)]
    [CanEditMultipleObjects]
    public class TransformHandleEditor : CustomEditorBase<TransformHandle>
    {

        protected override void OnEnable()
        {
            base.OnEnable();

            deferProperty("OnHandleDeactivated");
            deferProperty("OnHandleActivated");
            deferProperty("OnShouldHideHandle");
            deferProperty("OnShouldShowHandle");
        }

    }

}
