using System.Windows;
using System.Windows.Controls;
using TinyMages.Characters;
using TinyMages.Effects;
using TinyMages.Games;

namespace TinyMages
{
    /// <summary>
    /// Interaction logic for MageControl.xaml
    /// </summary>
    public partial class MageControl : UserControl
    {
        #region Конструкторы

        public MageControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Свойства зависимости
        
        public Game Game
        {
            get { return (Game)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        public static DependencyProperty GameProperty = DependencyProperty.Register("Game", typeof(Game), typeof(MageControl));

        #endregion
    }
}
