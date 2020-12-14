using Djeg.Yggdrasil.Persona.Data;

namespace Djeg.Yggdrasil.Persona.Behaviour
{
    /**
     * <summary>
     * Add the ability of a persona to inflict damage
     * </summary>
     */
    public interface IPersonaDamage
    {
        # region Properties

        /**
         * <summary>
         * Retrieve the max damage amount
         * </summary>
         */
        int MaxDamage { get; set; }

        /**
         * <summary>
         * The mininum damage
         * </summary>
         */
        int MinDamage { get; set; }

        /**
         * <summary>
         * The critical range
         * </summary>
         */
        int CriticalRange { get; set; }

        /**
         * <summary>
         * The critical modifier
         * </summary>
         */
        int CriticalModifier { get; set; }

        # endregion

        # region Methods

        /**
         * <summary>
         * Create a damage
         * </summary>
         */
        PersonaDamage RollDamage();

        # endregion
    }
}
