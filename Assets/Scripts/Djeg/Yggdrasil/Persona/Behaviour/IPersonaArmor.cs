using Djeg.Yggdrasil.Persona.Data;

namespace Djeg.Yggdrasil.Persona.Behaviour
{
    /**
     * <summary>
     * Define how a persona armor must behave
     * </summary>
     */
    public interface IPersonaArmor
    {
        # region Properties

        /**
         * <summary>
         * Retrieve the max health
         * </summary>
         */
        int MaxArmor { get; }

        /**
         * <summary>
         * Retrieve the current amount of health
         * </summary>
         */
        int CurrentArmor { get; }

        # endregion

        # region Methods

        /**
         * <summary>
         * Implement the take damage
         * </summary>
         */
        void DamageArmor(PersonaDamage damage);

        /**
         * <summary>
         * Define the ability to heal
         * </summary>
         */
        void RestoreArmor(int amount = 0);

        /**
         * <summary>
         * Upgrade the max amount
         * </summary>
         */
        void UpgradeArmor(int amount = 0);

        # endregion
    }
}
