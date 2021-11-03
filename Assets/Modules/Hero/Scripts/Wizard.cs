using UnityEngine;
using Leap;


namespace Aloha
{
    public class Wizard : Hero<WarriorStats>
    {
        public Fireball fireballPrefab;
        public Fireball currentFireball;
        private int currentMana;
        public void Init(WizardStats stats)
        {
            base.Init(stats);
            this.currentMana = stats.maxMana;
        }

        public void SpawnFireball()
        {
            GameObject rightHand = GameObject.Find("WizardRightHand(Clone)");
            GameObject shoulder = rightHand.transform.Find("Shoulder").gameObject;
            GameObject elbow = shoulder.transform.Find("Elbow").gameObject;
            GameObject wrist = elbow.transform.Find("Wrist").gameObject;
            GameObject bones25 = wrist.transform.Find("Bones25").gameObject;

            Vector3 fireballPos = bones25.transform.localPosition;
            fireballPos.y += 0.1f;
            fireballPos.z -= 0.1f;
            Fireball fireball = Instantiate(fireballPrefab, Vector3.zero, Quaternion.identity);
            fireball.transform.parent = bones25.transform;
            fireball.transform.localPosition = fireballPos;
            fireball.wizard = this;
            this.currentFireball = fireball;
        }

        public void SendFireball()
        {
            this.currentFireball.GoForward();
        }
    }
}