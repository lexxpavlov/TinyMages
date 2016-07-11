using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TinyMages.Effects;
using TinyMages.Util;

namespace TinyMages.Characters
{
    public abstract class BaseCharacter : NotifiedBase, ICharacter
    {
        #region Приватные поля

        private double _health;
        private double _maxHealth;
        private double _strength;
        private double _defense;

        private readonly Dictionary<Nature, double> _natureStrength = new Dictionary<Nature, double>();
        private readonly Dictionary<Nature, double> _natureDefense= new Dictionary<Nature, double>();

        private List<IEffect> _allEffects;

        #endregion

        #region Свойства и поля

        public string Name { get; }
        public ActionType ActionType { get; }

        public double Health
        {
            get
            {
                return _health;
            }
            set
            {
                _health = value;
                RaisePropertyChanged(nameof(Health));
            }
        }

        public double MaxHealth
        {
            get
            {
                return _maxHealth;
            }
            set
            {
                _maxHealth = value;
                RaisePropertyChanged(nameof(MaxHealth));
            }
        }
        
        public double Strength
        {
            get
            {
                return _strength + GetParameter(nameof(Strength));
            }
            set
            {
                _strength = value;
                RaisePropertyChanged(nameof(Strength));
            }
        }

        public double Defense
        {
            get
            {
                return _defense + GetParameter(nameof(Defense));
            }
            set
            {
                _defense = value;
                RaisePropertyChanged(nameof(Defense));
            }
        }

        public IList<IEffect> PreparedEffects { get; } = new ObservableCollection<IEffect>();
        public IList<AppliedEffect> AppliedEffects { get; } = new ObservableCollection<AppliedEffect>();

        public List<IEffect> AllEffects
        {
            get
            {
                if (_allEffects == null)
                {
                    var effects = DataLoader.Effects.ToList();
                    effects.Sort((a, b) => a.Name.CompareTo(b.Name));
                    _allEffects = effects;
                }
                return _allEffects;
            }
        }

        #endregion

        #region Конструкторы

        protected BaseCharacter()
        {
            Name = "Mage";
            ActionType = ActionType.All;
            PreparedEffects.Add(new Attack(Nature.Light, "Молния", 50, 10));
        }

        protected BaseCharacter(string name, ActionType actionType, double health, double maxHealth, double strength = 0, double defense = 0,
            ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
        {
            Name = name;
            ActionType = actionType;

            Health = health;
            MaxHealth = maxHealth;

            SetAllNatureStrength(strength);
            SetAllNatureDefense(defense);

            if (effects != null)
            {
                foreach (var effect in effects)
                {
                    PreparedEffects.Add(effect.Clone());
                }
            }
            if (appliedEffects != null)
            {
                foreach (var appliedEffect in appliedEffects)
                {
                    AppliedEffects.Add(appliedEffect);
                }
            }
        }

        protected BaseCharacter(string name, ActionType actionType, double health, double strength = 0, double defense = 0,
            ICollection<IEffect> effects = null, ICollection<AppliedEffect> appliedEffects = null)
            : this(name, actionType, health, health, strength, defense, effects, appliedEffects)
        {
        }

        #endregion

        #region Публичные методы

        public virtual void AddEffect(IEffect effect)
        {
            if (effect.CanDeal(this))
            {
                PreparedEffects.Add(effect.Clone());
            }
        }

        public double GetNatureStrength(Nature nature)
        {
            return _natureStrength.ContainsKey(nature) ? _natureStrength[nature] : 0;
        }

        public double GetNatureDefense(Nature nature)
        {
            return _natureDefense.ContainsKey(nature) ? _natureDefense[nature] : 0;
        }

        public void SetNatureStrength(Nature nature, double value, bool update = false)
        {
            _natureStrength[nature] = GetNatureStrength(nature) + value;
        }

        public void SetNatureDefense(Nature nature, double value, bool update = false)
        {
            _natureDefense[nature] = GetNatureDefense(nature) + value;
        }

        #endregion

        #region Приватные методы

        protected void SetAllNatureStrength(double value, bool update = false)
        {
            if (value == 0) return;
            foreach (var natureId in System.Enum.GetValues(typeof(Nature)))
            {
                SetNatureStrength((Nature)natureId, value, update);
            }
        }

        protected void SetAllNatureDefense(double value, bool update = false)
        {
            if (value == 0) return;
            foreach (var natureId in System.Enum.GetValues(typeof(Nature)))
            {
                SetNatureDefense((Nature)natureId, value, update);
            }
        }

        protected double GetParameter(string name)
        {
            switch (name)
            {
                case "Strength":
                    return GetParameterValue(Type.Attack);
                case "Defense":
                    return GetParameterValue(Type.Defense);
            }
            return 0;
        }

        protected double GetParameterValue(Type type)
        {
            return AppliedEffects.Where(e => e.Effect.Type == type).Sum(e => e.Effect.Strength);
        }

        #endregion
    }
}
