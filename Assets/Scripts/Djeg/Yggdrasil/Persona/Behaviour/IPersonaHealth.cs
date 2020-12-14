using Djeg.Yggdrasil.Persona.Data;

namespace Djeg.Yggdrasil.Persona.Behaviour
{
    /**
     * <summary>
     * Define how a persona health must behave
     * </summary>
     */
    public interface IPersonaHealth
    {
        # region Properties

        /**
         * <summary>
         * Retrieve the max health
         * </summary>
         */
        int MaxHealth { get; }

        /**
         * <summary>
         * Retrieve the current amount of health
         * </summary>
         */
        int CurrentHealth { get; }

        # endregion

        # region Methods

        /**
         * <summary>
         * Implement the take damage
         * </summary>
         */
        void DamageHealth(PersonaDamage damage);

        /**
         * <summary>
         * Define the ability to heal
         * </summary>
         */
        void RestoreHealth(int amount = 0);

        /**
         * <summary>
         * Upgrade the max amount
         * </summary>
         */
        void UpgradeHealth(int amount = 0);

        # endregion
    }
}
