using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMages.Characters;
using TinyMages.Util;

namespace TinyMages.Effects
{
    public abstract class BaseEffect : NotifiedBase, IEffect
    {
        #region Приватные поля

        private double _strength;
        private double _mana;

        #endregion

        #region Свойства и поля

        public Type Type { get; }
        public Nature Nature { get; }
        public DurationType DurationType { get; }

        public string Name { get; }
        public double Mana
        {
            get
            {
                return _mana;
            }
            protected set
            {
                _mana = value;
                RaisePropertyChanged(nameof(Mana));
            }
        }
        public double Strength
        {
            get
            {
                return _strength;
            }
            protected set
            {
                _strength = value;
                RaisePropertyChanged(nameof(Strength));
            }
        }

        public bool IsApplied { get; protected set; }

        #endregion

        protected BaseEffect(Type type, Nature nature, DurationType durationType, string name, double mana, double strength)
        {
            Type = type;
            Nature = nature;
            DurationType = durationType;
            Name = name;
            Mana = mana;
            Strength = strength;
        }

        #region Публичные методы

        public virtual bool CanDeal(ICharacter mage)
        {
            return true;
        }

        public virtual void Dealed()
        {
            Apply();
        }

        public void Apply()
        {
            IsApplied = true;
        }

        public IEffect Clone()
        {
            return (IEffect)MemberwiseClone();
        }

        #endregion
    }
}
