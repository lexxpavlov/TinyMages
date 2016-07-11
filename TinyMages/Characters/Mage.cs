using System.Collections.Generic;
using TinyMages.Effects;
using TinyMages.Util;

namespace TinyMages.Characters
{
    public class Mage : BaseCaster
    {
        #region Команды

        private DelegateCommand<IEffect> _addEffectCommand;
        public DelegateCommand<IEffect> AddEffectCommand => _addEffectCommand ?? (_addEffectCommand = new DelegateCommand<IEffect>(AddEffect, e => e?.Mana <= Mana));

        #endregion

        #region Конструкторы

        public Mage()
            : this("Mage", 100, 10, 10, 0, 0)
        {
        }

        public Mage(string name, double health, double maxHealth, double mana, double maxMana, double strength = 0, double defense = 0,
            IList<IEffect> spellBook = null, ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
            : base(name, ActionType.All, health, maxHealth, mana, maxMana, strength, defense, spellBook, effects, appliedEffects)
        {
        }

        public Mage(string name, double health, double mana, double strength = 0, double defense = 0,
            IList<IEffect> spellBook = null, ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
            : this(name, health, health, mana, mana, strength, defense, spellBook, effects, appliedEffects)
        {
        }

        public Mage(string name, double health, double mana, double strength = 0, double defense = 0,
            IList<IEffect> spellBook = null, ICollection<AppliedEffect> appliedEffects = null)
            : this(name, health, health, mana, mana, strength, defense, spellBook, null, appliedEffects)
        {
        }

        #endregion
    }
}
