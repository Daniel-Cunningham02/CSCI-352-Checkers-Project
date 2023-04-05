using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace CheckersProject.src
{
    public interface ISquare
    {
        Button changeColor();
    }

    public interface SquareFactory
    {
        ISquare GetBlueSquare();
        ISquare GetRedSquare();
        ISquare GetPurpleSquare();
        ISquare GetMagentaSquare();
        ISquare GetWhiteSquare();
        ISquare GetIndigoSquare();
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

        public ISquare GetMagentaSquare()
        {
            ISquare Magenta = new Magenta();
            return Magenta;
        }

        public ISquare GetWhiteSquare()
        {
            ISquare White = new White();
            return White;
        }

        public ISquare GetIndigoSquare()
        {
            ISquare Indigo = new Indigo();
            return Indigo;
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

    public class Magenta : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Magenta) };
            return b;
        }
    }
    public class White : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Azure) };
            return b;
        }
    }
    public class Indigo : ISquare
    {
        public Button changeColor()
        {
            Button b = new Button { Background = new SolidColorBrush(Colors.Indigo) };
            return b;
        }
    }
}
