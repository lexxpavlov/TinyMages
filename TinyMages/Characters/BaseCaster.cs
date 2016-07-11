using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TinyMages.Effects;

namespace TinyMages.Characters
{
    public class BaseCaster : BaseCharacter, ICaster
    {
        #region Приватные поля

        private double _mana;
        private double _maxMana;
        
        #endregion

        #region Свойства и поля

        public double Mana
        {
            get
            {
                return _mana;
            }
            set
            {
                _mana = value;
                RaisePropertyChanged(nameof(Mana));
            }
        }

        public double MaxMana
        {
            get
            {
                return _maxMana;
            }
            set
            {
                _maxMana = value;
                RaisePropertyChanged(nameof(MaxMana));
            }
        }

        public IList<IEffect> SpellBook { get; } = new ObservableCollection<IEffect>();

        #endregion

        #region Конструкторы

        protected BaseCaster()
        {
        }

        protected BaseCaster(string name, ActionType actionType, double health, double maxHealth, double mana, double maxMana, double strength = 0, double defense = 0,
            IList<IEffect> spellBook = null, ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
            : base(name, actionType, health, maxHealth, strength, defense, effects, appliedEffects)
        {
            Mana = mana;
            MaxMana = maxMana;

            if (spellBook != null)
            {
                foreach (var effect in spellBook)
                {
                    SpellBook.Add(effect);
                }
            }
        }

        protected BaseCaster(string name, ActionType actionType, double health, double mana, double strength = 0, double defense = 0,
            IList<IEffect> spellBook = null, ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
            : this(name, actionType, health, health, mana, mana, strength, defense, spellBook, effects, appliedEffects)
        {
        }

        #endregion

        #region Публичные методы

        public override void AddEffect(IEffect effect)
        {
            if (effect.CanDeal(this))
            {
                PreparedEffects.Add(effect.Clone());
                Mana -= effect.Mana;
            }
        }

        #endregion
    }
}
