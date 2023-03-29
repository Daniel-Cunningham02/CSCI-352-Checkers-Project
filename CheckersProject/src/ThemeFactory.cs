using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckersProject.src
{
    /**internal class ThemeFactory
    {
    }**/
    //int colorValue = 0;

    //We need to make sure we are generating objects with this factory

    public interface ISquare
    {
        Button changeColor();
    }

    public interface SquareFactory
    {
        ISquare GetBlueSquare();
        ISquare GetRedSquare();
        ISquare GetPurpleSquare();
    }

    public class Factory : SquareFactory
    {
        public ISquare GetBlueSquare()
        {
            ISquare Blue = new Blue();
            return Blue;
        }
        public ISquare GetRedSquare()
        {
            ISquare Red = new Red();
            return Red;
        }
        public ISquare GetPurpleSquare()
        {
            ISquare Purple = new Purple();
            return Purple;
        }
    }

    public class Blue : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Blue) };  
            return b;
        }
    }
    public class Red : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Red) };
            return b;
        }
    }

    public class Purple : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Purple) };
            return b;
        }
    }
}
