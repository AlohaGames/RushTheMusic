/******************************************************************************
 * Copyright (C) Ultraleap, Inc. 2011-2020.                                   *
 *                                                                            *
 * Use subject to the terms of the Apache License 2.0 available at            *
 * http://www.apache.org/licenses/LICENSE-2.0, or another agreement           *
 * between Ultraleap and you, your company or other organization.             *
 ******************************************************************************/

using UnityEditor;

namespace Leap.Unity.Interaction
{

    [CustomEditor(typeof(ContactBoneParent))]
    public class ContactBoneParentEditor : CustomEditorBase<ContactBoneParent>
    {

        protected override void OnEnable()
        {
            base.OnEnable();
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

    }

}
