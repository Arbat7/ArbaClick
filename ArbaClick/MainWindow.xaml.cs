using ArbaClick.Properties;
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

namespace ArbaClick
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Добро пожаловть в игру \"ArbaClick\"", "ArbaClick", MessageBoxButton.OK, MessageBoxImage.Information);

            //BafsButtons.Children.Add
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateMoneyTable();
            TimerAutoClick();
        }

        private void Minimaze_Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximaze_Button_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
        }

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SnusButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Money = Settings.Default.Money + (Settings.Default.Increase * Settings.Default.Factor);
            UpdateMoneyTable();
            this.Focus();
        }
        private void CheckAchivments()
        {
            if (!Settings.Default.Fifty && Settings.Default.Money >= 500)
            {
                Settings.Default.Fifty = true; MessageBox.Show("ОЙ-ЁО-ЁЙ, КОГДА ВКИНУЛСЯ!\nБонус: +150₽", "ArbaClick", MessageBoxButton.OK, MessageBoxImage.Information);
                Settings.Default.Money += 150;
                UpdateMoneyTable();
            }
            if (!Settings.Default.Arbat7 && Settings.Default.Money >= 734)
            {
                Settings.Default.Arbat7 = true; MessageBox.Show("734 на балансе, Руслан одобряет!", "ArbaClick", MessageBoxButton.OK, MessageBoxImage.Information);            
                UpdateMoneyTable();
            }
            if (!Settings.Default.Fifty2 && Settings.Default.Money >= 2000)
            {
                Settings.Default.Fifty2 = true; MessageBox.Show("ОЙ-ЁО-ЁЙ, КОГДА ВКИНУЛ ВТОРЯК! М-М-М\nБонус: +450₽", "ArbaClick", MessageBoxButton.OK, MessageBoxImage.Information);
                Settings.Default.Money += 450;
                UpdateMoneyTable();
            }

        }

        private void UpdateMoneyTable()
        {
            MoneyTextBox.Text = $"{Settings.Default.Factor}x     {Settings.Default.AutoClick}/сек     {Settings.Default.Increase}/clk     {Settings.Default.Money} ₽";
            UpdatePriceTable();
            CheckAchivments();
            Settings.Default.Save();
        }
        private void UpdatePriceTable()
        {
            FactorBut.Content = $"{Settings.Default.FactorLvl} Lvl | Множитель | {Settings.Default.FactorPrice}₽ | +0.5";


            TarakanBut.Content = $"{Settings.Default.TarakanLvl} Lvl | Тараканчик | {Settings.Default.TarakanPrice}₽ | +1";
            RedBut.Content = $"{Settings.Default.RedLvl} Lvl | Красный | {Settings.Default.RedPrice}₽ | +3";
            KalyanBut.Content = $"{Settings.Default.KalyanLvl} Lvl | Кальянный | {Settings.Default.KalyanPrice}₽ | +10";
            HookahBut.Content = $"{Settings.Default.HookahLvl} Lvl | Hookah | {Settings.Default.HookahPrice}₽ | +50";
            ShcoolsBut.Content = $"{Settings.Default.ShcoolsLvl} Lvl | Школьники | {Settings.Default.ShcoolsPrice}₽ | +0.5";
            UnicBut.Content = $"{Settings.Default.UnicLvl} Lvl | Студенты | {Settings.Default.UnicPrice}₽ | +2";
            ArmyBut.Content = $"{Settings.Default.ArmyLvl} Lvl | Срочники | {Settings.Default.ArmyPrice}₽ | 7";
            YandexDBut.Content = $"{Settings.Default.YandexDLvl} Lvl | Доставщики | {Settings.Default.YandexDPrice}₽ | 35";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        { Reset(true); }

        private void Reset(bool Full)
        {
            if (Full)
            {
                Settings.Default.Money = 0;
                Settings.Default.Factor = 1;
                Settings.Default.FactorPrice = 5000;
                Settings.Default.FactorLvl = 0;
                Settings.Default.Fifty = false;
                Settings.Default.Fifty2 = false;
                Settings.Default.Arbat7 = false;
            }

            Settings.Default.Increase = 1;
            Settings.Default.AutoClick = 0;
            Settings.Default.TarakanPrice = 20;
            Settings.Default.TarakanLvl = 0;
            Settings.Default.ShcoolsPrice = 50;
            Settings.Default.ShcoolsLvl = 0;
            Settings.Default.UnicPrice = 700;
            Settings.Default.UnicLvl = 0;
            Settings.Default.ArmyLvl = 0;
            Settings.Default.ArmyPrice = 3500;
            Settings.Default.YandexDLvl = 0;
            Settings.Default.YandexDPrice = 15000;
            Settings.Default.RedLvl = 0;
            Settings.Default.RedPrice = 400;
            Settings.Default.KalyanLvl = 0;
            Settings.Default.KalyanPrice = 2500;
            Settings.Default.HookahLvl = 0;
            Settings.Default.HookahPrice = 10000;
            UpdateMoneyTable();
        }

        private void TarakanBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.TarakanPrice)
            {
                Settings.Default.Money -= Settings.Default.TarakanPrice;
                Settings.Default.TarakanPrice *= 2;
                Settings.Default.TarakanLvl++;
                Settings.Default.Increase += 1;
                UpdateMoneyTable();
            }
        }

        private void ShcoolsBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.ShcoolsPrice)
            {
                Settings.Default.Money -= Settings.Default.ShcoolsPrice;
                Settings.Default.ShcoolsPrice *= 2.5;
                Settings.Default.ShcoolsLvl ++;
                Settings.Default.AutoClick += 0.5;
                UpdateMoneyTable();
            }
        }

        private async void TimerAutoClick()
        {
            while (true)
            {
                Settings.Default.Money += Settings.Default.AutoClick;
                UpdateMoneyTable();
                await Task.Delay(990);
            }
        }

        private void FactorBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.FactorPrice)
            {
                Settings.Default.FactorPrice *= 7.5;
                Settings.Default.FactorLvl++;
                Settings.Default.Factor += 0.5;
                Reset(false);
            }
        }

        private void UnicBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.UnicPrice)
            {
                Settings.Default.Money -= Settings.Default.UnicPrice;
                Settings.Default.UnicPrice *= 2.5;
                Settings.Default.UnicLvl++;
                Settings.Default.AutoClick += 2;
                UpdateMoneyTable();
            }
        }

        private void ArmyBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.ArmyPrice)
            {
                Settings.Default.Money -= Settings.Default.ArmyPrice;
                Settings.Default.ArmyPrice *= 2.5;
                Settings.Default.ArmyLvl++;
                Settings.Default.AutoClick += 7;
                UpdateMoneyTable();
            }
        }

        private void YandexDBut_Click(object sender, RoutedEventArgs e)
        {
            {
                Settings.Default.Money -= Settings.Default.YandexDPrice;
                Settings.Default.YandexDPrice *= 2.5;
                Settings.Default.YandexDLvl++;
                Settings.Default.AutoClick += 35;
                UpdateMoneyTable();
            }
        }

        private void RedBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.RedPrice)
            {
                Settings.Default.Money -= Settings.Default.RedPrice;
                Settings.Default.RedPrice *= 2;
                Settings.Default.RedLvl++;
                Settings.Default.Increase += 3;
                UpdateMoneyTable();
            }
        }

        private void KalyanBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.KalyanPrice)
            {
                Settings.Default.Money -= Settings.Default.KalyanPrice;
                Settings.Default.KalyanPrice *= 2;
                Settings.Default.KalyanLvl++;
                Settings.Default.Increase += 10;
                UpdateMoneyTable();
            }
        }

        private void HookahBut_Click(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.Money >= Settings.Default.HookahPrice)
            {
                Settings.Default.Money -= Settings.Default.HookahPrice;
                Settings.Default.HookahPrice *= 2;
                Settings.Default.HookahLvl++;
                Settings.Default.Increase += 50;
                UpdateMoneyTable();
            }
        }
    }
}
