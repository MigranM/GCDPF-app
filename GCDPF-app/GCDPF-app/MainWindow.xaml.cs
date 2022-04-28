using System;
using System.Collections.Generic;
using System.Linq;
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
using GCDPF;

namespace GCDPF_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int window_index = 1;
        Thickness exit_b_margin;

        public MainWindow()
        {
            InitializeComponent();
            exit_b_margin = menu_exit_button.Margin;
            menu_exit_button.Margin = new Thickness(10000, 0, 0, 0);
            main_grid.Margin = new Thickness(-1800, main_grid.Margin.Top, 1800, main_grid.Margin.Bottom);
        }

        //---------main_grid--------------
        private void eaf_menu_button_Click(object sender, RoutedEventArgs e)
        {
            window_index = 1;
            main_grid.Margin = new Thickness(-1800, main_grid.Margin.Top, 1800, main_grid.Margin.Bottom);
        }




        //---------emain_grid--------------
        private void eeaf_menu_button_Click(object sender, RoutedEventArgs e)
        {
            window_index = 2;
            main_grid.Margin = new Thickness(-1800, main_grid.Margin.Top, 1800, main_grid.Margin.Bottom);
        }




        //---------menu_grid--------------
        private void menu_exit_button_Click(object sender, RoutedEventArgs e)
        {
            if (window_index == 1) menu_eaf_button_Click(sender, e);
            if (window_index == 2) menu_eeaf_button_Click(sender, e);
            if (window_index == 3) menu_authors_button_Click(sender, e);
            if (window_index == 4) menu_materials_button_Click(sender, e);
        }

        private void menu_eaf_button_Click(object sender, RoutedEventArgs e)
        {
            main_grid.Margin = new Thickness(0, main_grid.Margin.Top, 0, main_grid.Margin.Bottom);
            menu_exit_button.Margin = exit_b_margin;
        }
        private void menu_eeaf_button_Click(object sender, RoutedEventArgs e)
        {
            main_grid.Margin = new Thickness(-900, main_grid.Margin.Top, 900, main_grid.Margin.Bottom);
            menu_exit_button.Margin = exit_b_margin;
        }
        private void menu_authors_button_Click(object sender, RoutedEventArgs e)
        {
            main_grid.Margin = new Thickness(-2700, main_grid.Margin.Top, 2700, main_grid.Margin.Bottom);
            menu_exit_button.Margin = exit_b_margin;
        }
        private void menu_materials_button_Click(object sender, RoutedEventArgs e)
        {
            main_grid.Margin = new Thickness(-3600, main_grid.Margin.Top, 3600, main_grid.Margin.Bottom);
            menu_exit_button.Margin = exit_b_margin;
        }




        //---------authors_grid--------------
        private void authors_menu_button_Click(object sender, RoutedEventArgs e)
        {
            window_index = 3;
            main_grid.Margin = new Thickness(-1800, main_grid.Margin.Top, 1800, main_grid.Margin.Bottom);
        }




        //---------materials_grid--------------
        private void materias_menu_button_Click(object sender, RoutedEventArgs e)
        {
            window_index = 4;
            main_grid.Margin = new Thickness(-1800, main_grid.Margin.Top, 1800, main_grid.Margin.Bottom);
        }


        private void EAF_b_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("!");
        }
        private void EEAF_b_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("!");
        }

        //---------------------Начало функционала EAF------------------
        //-------------доп переменные----------
        int[] eaf_array_of_a;
        int[] eaf_array_of_b;
        int eaf_field;
        public static bool EAF_a_is_correct = false;
        public static bool EAF_b_is_correct = false;
        public static bool EAF_field_is_correct = false;
        private static Color label_green = Color.FromRgb(58, 247, 159);
        private static Color label_red = Color.FromRgb(247, 58, 74); //234, 63, 63
        private static Color label_grey = Color.FromRgb(171, 173, 179);

        //---------доп методы--------------
        /// <summary>
        /// проверка на простоту
        /// </summary> 
        public static bool is_correct(string a, ref int[] new_vvod)
        {
            try
            {

                new_vvod = a.Split(' ').
                Where(x => !string.IsNullOrWhiteSpace(x)).
                Select(x => int.Parse(x)).ToArray();
                return true;

            }
            catch { Console.WriteLine("неправильный ввод"); return false; }

        }


        public static bool IsCorrectField(string a, ref int f)
        {
            a = a.Trim();
            bool flag = true;
            if (a == "") flag = false;
            for (int i = 0; i < a.Length; i++)
            {
                if (!char.IsDigit(a[i])) flag = false;
            }

            if (flag)
            {
                if (Convert.ToInt32(a) > 46000) return false;
                for (int i = 2; i <= Math.Sqrt(Convert.ToInt32(a)); i++)
                    if (Convert.ToInt32(a) % i == 0)
                        return false;
                f = Convert.ToInt32(a);
                return true;
            }

            return false;
        }


        private void eaf_a_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eaf_a_textbox.Text == "")
            {
                eaf_a_label.Foreground = new SolidColorBrush(label_grey);
                EAF_a_is_correct = false;
            }
            else if (is_correct(eaf_a_textbox.Text, ref eaf_array_of_a))
            {
                eaf_a_label.Foreground = new SolidColorBrush(label_green);
                EAF_a_is_correct = true;
            }
            else
            {
                eaf_a_label.Foreground = new SolidColorBrush(label_red);
                EAF_a_is_correct = false;
            }

        }

        private void eaf_b_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eaf_b_textbox.Text == "")
            {
                eaf_b_label.Foreground = new SolidColorBrush(label_grey);
                EAF_b_is_correct = false;
            }
            else if (is_correct(eaf_b_textbox.Text, ref eaf_array_of_b))
            {
                eaf_b_label.Foreground = new SolidColorBrush(label_green);
                EAF_b_is_correct = true;
            }
            else
            {
                eaf_b_label.Foreground = new SolidColorBrush(label_red);
                EAF_b_is_correct = false;
            }
        }

        private void eaf_field_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eaf_field_textbox.Text == "")
            {
                eaf_field_label.Foreground = new SolidColorBrush(label_grey);
                EAF_field_is_correct = false;
            }
            else if (IsCorrectField(eaf_field_textbox.Text, ref eaf_field))
            {
                eaf_field_label.Foreground = new SolidColorBrush(label_green);
                EAF_field_is_correct = true;
            }
            else
            {
                eaf_field_label.Foreground = new SolidColorBrush(label_red);
                EAF_field_is_correct = false;
            }
        }

        private void eaf_calculate_button_Click(object sender, RoutedEventArgs e)
        {

            if (EAF_a_is_correct && EAF_b_is_correct && EAF_field_is_correct)
            {
                if (new Polynomial(eaf_array_of_a).ToField(eaf_field).IsNull || new Polynomial(eaf_array_of_b).ToField(eaf_field).IsNull)
                {
                    MessageBox.Show("Необходимо задать оба полинома");
                }
                else eaf_result_textbox.Text = Polynomial.GCDF(new Polynomial(eaf_array_of_a), new Polynomial(eaf_array_of_b), eaf_field).ToString();
            }
            else eaf_result_textbox.Text = "";

        }
        //---------------------Конец функционала EAF------------------








        //---------------------Начало функционала EEAF------------------
        //-------------доп переменные----------
        int[] eeaf_array_of_a;
        int[] eeaf_array_of_b;
        int eeaf_field;
        public static bool EEAF_a_is_correct = false;
        public static bool EEAF_b_is_correct = false;
        public static bool EEAF_field_is_correct = false;
        private void eeaf_a_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eeaf_a_textbox.Text == "")
            {
                eeaf_a_label.Foreground = new SolidColorBrush(label_grey);
                EEAF_a_is_correct = false;
            }
            else if (is_correct(eeaf_a_textbox.Text, ref eeaf_array_of_a))
            {
                eeaf_a_label.Foreground = new SolidColorBrush(label_green);
                EEAF_a_is_correct = true;
            }
            else
            {
                eeaf_a_label.Foreground = new SolidColorBrush(label_red);
                EEAF_a_is_correct = false;
            }
        }

        private void eeaf_b_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eeaf_b_textbox.Text == "")
            {
                eeaf_b_label.Foreground = new SolidColorBrush(label_grey);
                EEAF_b_is_correct = false;
            }
            else if (is_correct(eeaf_b_textbox.Text, ref eeaf_array_of_b))
            {
                eeaf_b_label.Foreground = new SolidColorBrush(label_green);
                EEAF_b_is_correct = true;
            }
            else
            {
                eeaf_b_label.Foreground = new SolidColorBrush(label_red);
                EEAF_b_is_correct = false;
            }
        }

        private void eeaf_field_textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (eeaf_field_textbox.Text == "")
            {
                eeaf_field_label.Foreground = new SolidColorBrush(label_grey);
                EEAF_field_is_correct = false;
            }
            else if (IsCorrectField(eeaf_field_textbox.Text, ref eeaf_field))
            {
                eeaf_field_label.Foreground = new SolidColorBrush(label_green);
                EEAF_field_is_correct = true;
            }
            else
            {
                eeaf_field_label.Foreground = new SolidColorBrush(label_red);
                EEAF_field_is_correct = false;
            }
        }

        private void eeaf_calculate_button_Click(object sender, RoutedEventArgs e)
        {
            Polynomial x;
            Polynomial y;
            Polynomial d;

            if (EEAF_a_is_correct && EEAF_b_is_correct && EEAF_field_is_correct)
            {
                if (new Polynomial(eeaf_array_of_a).ToField(eeaf_field).IsNull || new Polynomial(eeaf_array_of_b).ToField(eeaf_field).IsNull)
                {
                    MessageBox.Show("Необходимо задать оба полинома");
                }
                else
                {
                    Polynomial.EEAP(new Polynomial(eeaf_array_of_a), new Polynomial(eeaf_array_of_b), out d, out x, out y, eeaf_field);
                    eeaf_x_textbox.Text = x.ToString();
                    eeaf_y_textbox.Text = y.ToString();
                    eeaf_result_textbox.Text = d.ToString();
                }
            }
            else
            {
                eeaf_x_textbox.Text = "";
                eeaf_y_textbox.Text = "";
                eeaf_result_textbox.Text = "";
            }
        }






    }
}
