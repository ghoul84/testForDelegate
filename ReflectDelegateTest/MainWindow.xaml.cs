using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ReflectDelegateTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var result = MessageBox.Show("Test", "t", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var button = (Button)sender;
                button.PreviewKeyDown -= Button_PreviewKeyDown;

            }


            //MethodInfo method = delegateType.GetMethod("Invoke");
            

        }

        public void Test(object obj)
        {
            // Specifies the class.
            Type t = obj.GetType();
            MessageBox.Show(string.Format("Listing all the members (public and non public) of the {0} type", t));

            // Lists static fields first.
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            //MessageBox.Show("// Static Fields");
            //PrintMembers(fi);
            foreach (var item in fi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in Static Fields");
                }
            }

            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            //MessageBox.Show("// Static Properties");
            //PrintMembers(pi);
            foreach (var item in pi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in GetEvents static");
                }
            }
            

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            //MessageBox.Show("// Static Events");
            //PrintMembers(ei);
            foreach (var item in ei)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    //MessageBox.Show("PreviewKeyDown has found in GetEvents static");
                    item.RemoveMethod.Invoke(obj, null);
                }
            }
            

            // Static methods.
            MethodInfo[] mi = t.GetMethods(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            //MessageBox.Show("// Static Methods");
            //PrintMembers(mi);
            foreach (var item in mi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in GetEvents static");
                }
            }
            

            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            //MessageBox.Show("// Constructors");
            //PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            //MessageBox.Show("// Instance Fields");
            //PrintMembers(fi);
            foreach (var item in fi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in Instance Fields");
                }
            }
            

            // Instance properites.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            //MessageBox.Show("// Instance Properties");
            //PrintMembers(pi);
            foreach (var item in pi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in Instance properites.");
                }
            }
            

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            //MessageBox.Show("// Instance Events");
            //PrintMembers(ei);
            foreach (var item in ei)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    //MessageBox.Show("PreviewKeyDown has found in Instance events.");
                    item.RemoveMethod.Invoke(obj, null);
                }
            }
            

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            //MessageBox.Show("// Instance Methods");
            //PrintMembers(mi);
            foreach (var item in mi)
            {
                if (item.Name == "PreviewKeyDown")
                {
                    MessageBox.Show("PreviewKeyDown has found in GetMethods");
                }
            }
            
            
        }

        private static void GetObjectType(object sender, string partName)
        {
            Type MyType = sender.GetType();
            // Specifies the member for which you want type information.
            MethodInfo Mymethodinfo = MyType.GetMethod(partName);
            var evtInfo = MyType.GetEvent(partName);
            if (Mymethodinfo == null)
            {
                return;
            }

            // Gets and displays the MemberType property.
            MemberTypes Mymembertypes = Mymethodinfo.MemberType;
            if (MemberTypes.Constructor == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type All");
            }
            else if (MemberTypes.Custom == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type Event");
            }
            else if (MemberTypes.Field == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type Field");
            }
            else if (MemberTypes.Method == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type Method");
            }
            else if (MemberTypes.Property == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == Mymembertypes)
            {
                MessageBox.Show("MemberType is of type TypeInfo");
            }
        }

        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                MessageBox.Show($"{m.Name} {m.MemberType}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test(sender);
        }
    }
}
