using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HeaviSoft.FrameworkBase.Component
{
    /// <summary>
    /// 自定义PasswordBox
    /// </summary>
    public class CustomPasswordBox : CustomTextBox
    {
        /// <summary>
        ///   Private member holding mask visibile timer
        /// </summary>
        private readonly DispatcherTimer _maskTimer;

        /// <summary>
        /// 设置默认样式
        /// </summary>
        static CustomPasswordBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomPasswordBox), new FrameworkPropertyMetadata(typeof(CustomPasswordBox)));
        }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public CustomPasswordBox()
        {
            PreviewTextInput += OnPreviewTextInput;
            PreviewKeyDown += OnPreviewKeyDown;
            CommandManager.AddPreviewExecutedHandler(this, PreviewExecutedHandler);
            _maskTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 1) };
            _maskTimer.Tick += (sender, args) => MaskAllDisplayText();

        }

        /// <summary>
        /// 依赖属性PasswordProperty
        /// </summary>
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register(
                "Password", typeof(SecureString), typeof(CustomPasswordBox), new UIPropertyMetadata(new SecureString()));

        /// <summary>
        /// Password
        /// </summary>
        public SecureString Password
        {
            get
            {
                return (SecureString)GetValue(PasswordProperty);
            }
            set
            {
                SetValue(PasswordProperty, value);
            }
        }



        /// <summary>
        /// 禁止COPY、CUT、PASTE操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="executedRoutedEventArgs"></param>
        private static void PreviewExecutedHandler(object sender, ExecutedRoutedEventArgs executedRoutedEventArgs)
        {
            if (executedRoutedEventArgs.Command == ApplicationCommands.Copy ||
                executedRoutedEventArgs.Command == ApplicationCommands.Cut ||
                executedRoutedEventArgs.Command == ApplicationCommands.Paste)
            {
                executedRoutedEventArgs.Handled = true;
            }
        }

        /// <summary>
        /// 文本输入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="textCompositionEventArgs"></param>
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            AddToSecureString(e.Text);
            e.Handled = true;
        }

        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="keyEventArgs"></param>
        private void OnPreviewKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Key pressedKey = keyEventArgs.Key == Key.System ? keyEventArgs.SystemKey : keyEventArgs.Key;
            switch (pressedKey)
            {
                case Key.Space:
                    AddToSecureString(" ");
                    keyEventArgs.Handled = true;
                    break;
                case Key.Back:
                case Key.Delete:
                    if (SelectionLength > 0)
                    {
                        RemoveFromSecureString(SelectionStart, SelectionLength);
                    }
                    else if (pressedKey == Key.Delete && CaretIndex < Text.Length)
                    {
                        RemoveFromSecureString(CaretIndex, 1);
                    }
                    else if (pressedKey == Key.Back && CaretIndex > 0)
                    {
                        int caretIndex = CaretIndex;
                        if (CaretIndex > 0 && CaretIndex < Text.Length)
                            caretIndex = caretIndex - 1;
                        RemoveFromSecureString(CaretIndex - 1, 1);
                        CaretIndex = caretIndex;
                    }

                    keyEventArgs.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// 转换文本为安全文本
        /// </summary>
        /// <param name="text"></param>
        void AddToSecureString(string text)
        {
            if (SelectionLength > 0)
            {
                RemoveFromSecureString(SelectionStart, SelectionLength);
            }

            foreach (char c in text)
            {
                int caretIndex = CaretIndex;
                Password.InsertAt(caretIndex, c);
                MaskAllDisplayText();
                if (caretIndex == Text.Length)
                {
                    _maskTimer.Stop();
                    _maskTimer.Start();
                    Text = Text.Insert(caretIndex++, c.ToString());
                }
                else
                {
                    Text = Text.Insert(caretIndex++, "*");
                }
                CaretIndex = caretIndex;
            }
        }

        /// <summary>
        /// 从安全文本中移除
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="trimLength"></param>
        private void RemoveFromSecureString(int startIndex, int trimLength)
        {
            int caretIndex = CaretIndex;
            for (int i = 0; i < trimLength; ++i)
            {
                Password.RemoveAt(startIndex);
            }

            Text = Text.Remove(startIndex, trimLength);
            CaretIndex = caretIndex;
        }

        /// <summary>
        /// 将所有文本标记为*
        /// </summary>
        private void MaskAllDisplayText()
        {
            _maskTimer.Stop();
            int caretIndex = CaretIndex;
            Text = new string('*', Text.Length);
            CaretIndex = caretIndex;
        }
    }
}
