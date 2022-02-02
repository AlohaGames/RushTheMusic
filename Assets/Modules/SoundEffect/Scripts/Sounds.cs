using UnityEngine;

namespace Aloha
{
    [CreateAssetMenu(fileName = "Sounds", menuName = "Sounds", order = 1)]
    public class Sounds : ScriptableObject
    {
        [Header("ENEMY")]
        public AudioClip lancer_idle;
        public AudioClip lancer_hurt;
        public AudioClip lancer_attack;
        public AudioClip assassin_idle;
        public AudioClip assassin_hurt;
        public AudioClip assassin_attack;
        public AudioClip wyrmling_idle;
        public AudioClip wyrmling_hurt;
        public AudioClip wyrmling_attack;
        public AudioClip bat_idle;
        public AudioClip bat_hurt;
        public AudioClip bat_attack;
        public AudioClip canon_idle;
        public AudioClip canon_hurt;
        public AudioClip canon_attack;
        public AudioClip dark_wizard_idle;
        public AudioClip dark_wizard_hurt;
        public AudioClip dark_wizard_ice_laser;
        public AudioClip dark_wizard_fire_laser;
        public AudioClip wall_hurt;
        public AudioClip chest_open;

        [Header("BOSS")]
        public AudioClip experion_idle;
        public AudioClip experion_hurt;
        public AudioClip experion_ice_laser;
        public AudioClip experion_fire_laser;

        [Header("HERO")]
        public AudioClip hero_drink;
        public AudioClip hero_take_damage;
        public AudioClip hero_level_up;
        public AudioClip wizard_attack;
        public AudioClip wizard_block;
        public AudioClip wizard_no_mana;
        public AudioClip warrior_attack;
        public AudioClip warrior_block;
        public AudioClip warrior_rage;

        [Header("ITEMS")]
        public AudioClip health_potion_effect;
        public AudioClip xp_potion_effect;
        public AudioClip mana_potion_effect;
        public AudioClip rage_potion_effect;

        [Header("GAMES")]
        public AudioClip victory;
        public AudioClip loose;

        [Header("MENU")]
        public AudioClip click;
        public AudioClip back;
    }
}
