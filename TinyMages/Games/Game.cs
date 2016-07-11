using System;
using System.Collections.ObjectModel;
using TinyMages.Characters;
using TinyMages.Dealers;
using TinyMages.Effects;
using TinyMages.Util;

namespace TinyMages.Games
{
    public class Game : NotifiedBase
    {
        #region Приватные поля

        private int _turn = 1;

        private Mage _red;
        private Mage _blue;

        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        #endregion

        #region Свойства

        public Mage Red
        {
            get
            {
                return _red;
            }
            set
            {
                _red = value;
                RaisePropertyChanged(nameof(Red));
            }
        }

        public Mage Blue
        {
            get
            {
                return _blue;
            }
            set
            {
                _blue = value;
                RaisePropertyChanged(nameof(Blue));
            }
        }

        public int Turn
        {
            get
            {
                return _turn;
            }
            set
            {
                _turn = value;
                RaisePropertyChanged(nameof(Turn));
            }
        }

        public ObservableCollection<string> Messages
        {
            get
            {
                return _messages;
            }
            set
            {
                _messages = value;
                RaisePropertyChanged(nameof(Messages));
            }
        }

        #endregion

        #region Конструкторы

        public Game()
        {
            Red = DataLoader.Mages[0];
            Blue = DataLoader.Mages[1];
        }

        #endregion

        #region Публичные методы

        public void NextTurn()
        {
            AddMessage($"Ход {Turn}");
            ProcessMages();
            Turn++;
        }

        #endregion

        #region Команды

        private ActionCommand _nextTurnCommand;
        public ActionCommand NextTurnCommand => _nextTurnCommand ?? (_nextTurnCommand = new ActionCommand(NextTurn));

        #endregion

        #region Приватные методы

        private void ProcessMages()
        {
            int countRed = Red.PreparedEffects.Count;
            int countBlue = Blue.PreparedEffects.Count;
            int count = Math.Max(countRed, countBlue);

            for (int i = 0; i <= count; i++)
            {
                if (i < countRed)
                {
                    Deal(Red.PreparedEffects[i], Blue, Red);
                }
                if (i < countBlue)
                {
                    Deal(Blue.PreparedEffects[i], Red, Blue);
                }
                if (CheckWin()) return;
            }

            RemoveEffects(Red);
            RemoveEffects(Blue);
            Red.Mana = Red.MaxMana;
            Blue.Mana = Blue.MaxMana;
        }

        private void Deal(IEffect effect, Mage target, Mage caster)
        {
            if (!effect.IsApplied)
            {
                DealersSelector.GetDealer(effect).Deal(Turn, effect, target, caster);
                AddMessage("{0} создаёт заклинание {1}", caster.Name, effect.Name);
            }
        }

        private void RemoveEffects(Mage mage)
        {
            for (int i = mage.PreparedEffects.Count - 1; i >= 0; i--)
            {
                if (mage.PreparedEffects[i].IsApplied)
                {
                    mage.PreparedEffects.RemoveAt(i);
                }
            }
            for (int i = mage.AppliedEffects.Count - 1; i >= 0; i--)
            {
                if (mage.AppliedEffects[i].RemoveTurn <= Turn+1)
                {
                    mage.AppliedEffects.RemoveAt(i);
                }
            }
        }

        private void AddMessage(string message, params object[] values)
        {
            Messages.Insert(0, string.Format(message, values));
        }

        private bool CheckWin()
        {
            if (Red.Health <= 0 && Blue.Health > 0)
            {
                AddMessage($"Победил {Blue.Name}");
                return true;
            }
            if (Red.Health > 0 && Blue.Health <= 0)
            {
                AddMessage($"Победил {Red.Name}");
                return true;
            }
            if (Red.Health <= 0 && Blue.Health <= 0)
            {
                AddMessage("Ничья");
                return true;
            }
            return false;
        }

        #endregion
    }
}
