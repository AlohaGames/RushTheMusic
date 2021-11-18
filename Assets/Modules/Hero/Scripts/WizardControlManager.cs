using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class WizardControlManager : ControlManager
    {
        [SerializeField]
        private UnityEvent prepareAttack;
        [SerializeField]
        private UnityEvent releaseAttack;
        [SerializeField]
        private UnityEvent prepareDefense;
        [SerializeField]
        private UnityEvent releaseDefense;

        private void Awake()
        {
            if (prepareAttack == null)
                prepareAttack = new UnityEvent();
            if (releaseAttack == null)
                releaseAttack = new UnityEvent();
            if (prepareDefense == null)
                prepareDefense = new UnityEvent();
            if (releaseDefense == null)
                releaseDefense = new UnityEvent();
        }

        protected override void PrepareAttack()
        {
            if (prepareAttack != null)
            {
                prepareAttack.Invoke();
            }
        }

        protected override void ReleaseAttack()
        {
            if (releaseAttack != null)
            {
                releaseAttack.Invoke();
            }
        }

        protected override void PrepareDefense()
        {
            if (prepareDefense != null)
            {
                prepareDefense.Invoke();
            }
        }

        protected override void ReleaseDefense()
        {
            if (releaseDefense != null)
            {
                releaseDefense.Invoke();
            }
        }
    }
}