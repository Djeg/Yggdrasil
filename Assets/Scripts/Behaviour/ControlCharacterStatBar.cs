using System;
using System.Reflection;
using UnityEngine;
using Core;
using Data;

namespace Behaviour
{
    /**
     * <summary>
     * Control the lifebar
     * </summary>
     */
    public class ControlCharacterStatBar : MonoDataBehaviour
    {
        # region Properties

        /**
         * <summary>
         * A reference of the GameObject containing the character stat data.
         * </summary>
         */
        [SerializeField]
        private GameObject _subject = null;

        /**
         * <summary>
         * The field to retrieve on order to get the max value
         * </summary>
         */
        [SerializeField]
        private string _maxValueFieldName = "maxHealth";

        /**
         * <summary>
         * The field to retrieve in order to get the current value
         * </summary>
         */
        [SerializeField]
        private string _currentValueFieldName = "health";

        /**
         * <summary>
         * A reference to the CharacterStat data
         * </summary>
         */
        private CharacterStatData _stats = null;

        /**
         * <summary>
         * A reference to the rect transform.
         * </summary>
         */
        private RectTransform _transform = null;

        # endregion

        # region PropertyAccessors
        # endregion

        # region PublicMethods
        # endregion

        # region PrivateMethods

        /**
         * <inheritdoc/>
         */
        protected override void Init(MonoDataContainer container)
        {
            if (null == _subject)
                throw new Exception("You must attach a subject to the lifebar behaviour");

            _stats = _subject.GetComponent<MonoDataContainer>().GetData<CharacterStatData>();

            if (null == _subject)
                throw new Exception($"{_subject.name} does not have a character stat data");

            _transform = GetComponent<RectTransform>();

            UpdateAnchor();
        }

        /**
         * <inheritdoc/>
         */
        private void Update()
        {
            UpdateAnchor();
        }

        /**
         * <summary>
         * Update the life bar anchor
         * </summary>
         */
        private void UpdateAnchor()
        {
            float percentage = CurrentValue() / MaxValue();

            _transform.anchorMax = new Vector2(
                percentage,
                _transform.anchorMax.y
            );
        }

        /**
         * <summary>
         * Retrieve the max value
         * </summary>
         */
        private float MaxValue()
        {
            FieldInfo info = _stats
                .GetType()
                .GetField(_maxValueFieldName)
            ;

            int v = (int)Convert.ChangeType((int)info.GetValue(_stats), info.FieldType);

            return (float)v;
        }

        /**
         * <summary>
         * Retrieve the current value
         * </summary>
         */
        private float CurrentValue()
        {
            FieldInfo info = _stats
                .GetType()
                .GetField(_currentValueFieldName)
            ;

            int v = (int)Convert.ChangeType((int)info.GetValue(_stats), info.FieldType);

            return (float)v;
        }

        # endregion
    }
}
