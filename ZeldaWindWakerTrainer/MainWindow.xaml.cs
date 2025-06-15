using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ZeldaWindWakerTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _exiting = false;
        private readonly WindWaker _windWaker;

        public MainWindow()
        {
            _windWaker = new WindWaker {DisableWrite = true};

            OffsetDialog offsetDialog = new OffsetDialog(_windWaker.GetCemuAppDataPath());
            if (offsetDialog.ShowDialog() != true) Environment.Exit(0);

            _windWaker.SetBaseAddress(offsetDialog.GetBaseAddress());

            InitializeComponent();

            SetupOnGridMapClicked();
            SetupInventoryClicked();
            SetupSpoilsBagInventoryClicked();
            SetupTreasureMapClicked();
            SetupUnlocksClicked();
            SetupSongsClicked();

            new Thread(UpdateThread).Start();
        }

        private void UpdateThread()
        {
            while (!_exiting)
            {
                var invoke = Dispatcher.BeginInvoke(new Action(() =>
                {
                    LblHealth.Content = _windWaker.GetHealth().ToString();
                    LblMaxHealth.Content = _windWaker.GetMaxHealth();
                    
                    float[] positions = _windWaker.GetPlayerPosition();
                    LblPlayerX.Content = positions[0].ToString();
                    LblPlayerY.Content = positions[1].ToString();
                    LblPlayerZ.Content = positions[2].ToString();

                    int maxStamina = _windWaker.GetMaxStaminaUnlock();
                    CheckboxMaxStamina.IsChecked = maxStamina switch
                    {
                        32 => true,
                        16 => (bool?)null,
                        _ => false
                    };
                    LblStamina.Content = _windWaker.GetStamina();

                    LblBeedlePoints.Content = _windWaker.GetBeedlePoints();

                    ComboMaxRupee.SelectedValue = _windWaker.GetMaxRupee().ToString();
                    LblRupee.Content = _windWaker.GetRupee();

                    CheckBoxPowerBracelets.IsChecked = _windWaker.GetPowerBracelets();

                    bool[] triforces = _windWaker.GetTriforceFragments();
                    CheckboxTriforce1.IsChecked = triforces[0];
                    CheckboxTriforce2.IsChecked = triforces[1];
                    CheckboxTriforce3.IsChecked = triforces[2];
                    CheckboxTriforce4.IsChecked = triforces[3];
                    CheckboxTriforce5.IsChecked = triforces[4];
                    CheckboxTriforce6.IsChecked = triforces[5];
                    CheckboxTriforce7.IsChecked = triforces[6];
                    CheckboxTriforce8.IsChecked = triforces[7];

                    bool[] pearls = _windWaker.GetPearls();
                    CheckboxPearlNayru.IsChecked = pearls[0];
                    CheckboxPearlDin.IsChecked = pearls[1];
                    CheckboxPearlFarore.IsChecked = pearls[2];

                    foreach (var children in GridMap.Children)
                    {
                        Label map = (Label)children;
                        if (Regex.Match(map.Content.ToString(), "^[A-G]\\d$", RegexOptions.IgnoreCase).Success)
                        {
                            map.Background = new SolidColorBrush(_windWaker.GetMapUnlocked(map.Content.ToString()) ? Colors.Beige : Colors.Gray);
                        }
                    }

                    var treasureChildrenPanels = new[] { PanelTreasureMap1.Children, PanelTreasureMap2.Children, PanelTreasureMap3.Children };
                    var mapValues = _windWaker.GetMapFound();
                    foreach (var children in treasureChildrenPanels)
                    {
                        foreach (var child in children)
                        {
                            CheckBox mapCheckbox = (CheckBox)child;
                            int mapPack = int.Parse(mapCheckbox.Tag.ToString().Split('_')[0]);
                            int mapBit = int.Parse(mapCheckbox.Tag.ToString().Split('_')[1]);
                            mapCheckbox.IsChecked = mapValues[mapPack][mapBit - 1];
                        }
                    }

                    bool[] mapTriforceDecrypted = _windWaker.GetMapTriforceDecrypted();
                    CheckboxMapTriforceDecrypted1.IsChecked = mapTriforceDecrypted[0];
                    CheckboxMapTriforceDecrypted2.IsChecked = mapTriforceDecrypted[1];
                    CheckboxMapTriforceDecrypted3.IsChecked = mapTriforceDecrypted[2];

                    CheckBoxUnlockWindWaker.IsChecked = _windWaker.GetWindWakerUnlocked();
                    CheckBoxUnlockHeroAmulet.IsChecked = _windWaker.GetHeroAmuletUnlocked();
                    CheckBoxUnlockPiratesCharm.IsChecked = _windWaker.GetPirateCharmUnlocked();

                    foreach (var child in PanelUnlockedItems.Children)
                    {
                        if ((child as CheckBox)?.Tag == null) continue;
                        CheckBox checkbox = (CheckBox)child;

                        int value = _windWaker.GetUnlockedItem(checkbox.Tag.ToString());
                        if (checkbox.IsThreeState)
                        {
                            checkbox.IsChecked = value switch
                            {
                                3 => true,
                                1 => (bool?)null,
                                _ => false
                            };
                        }
                        else
                        {
                            checkbox.IsChecked = value > 0;
                        }
                    }

                    ComboBoxUnlockBow.SelectedValue = _windWaker.GetUnlockedItem("Bow");
                    ComboMaxBomb.SelectedValue = _windWaker.GetMaxBombQty();
                    ComboMaxArrow.SelectedValue = _windWaker.GetMaxArrowQty();
                    LblBombCount.Content = _windWaker.GetBombQty().ToString();
                    LblArrowCount.Content = _windWaker.GetArrowQty().ToString();
                    ComboSwordType.SelectedValue = _windWaker.GetSwordType();
                    ComboShieldType.SelectedValue = _windWaker.GetShieldType();

                    bool[] songs = _windWaker.GetSongsUnlocked();
                    foreach (var child in PanelSongs.Children)
                    {
                        CheckBox checkBox = (CheckBox)child;
                        checkBox.IsChecked = songs[int.Parse(checkBox.Tag.ToString())];
                    }
                    
                    if (CheckboxInfiniteBreath.IsChecked == true)
                    {
                        _windWaker.UpdateWaterBreath(900);
                    }
                }), DispatcherPriority.SystemIdle);

                invoke.Completed += (sender, e) => { _windWaker.DisableWrite = false; };

                Thread.Sleep(1000);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _exiting = true;
        }

        private void ComboMaxRupee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _windWaker.UpdateMaxRupee(int.Parse(ComboMaxRupee.SelectedValue.ToString()));
        }

        private void BtUpdateRupee_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateRupee(int.Parse(TxtRupee.Text));
        }

        private void BtUpdateStamina_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateStamina(int.Parse(TxtStamina.Text));
        }

        private void CheckboxMaxStamina_Click(object sender, RoutedEventArgs e)
        {
            int value = 0;
            if (CheckboxMaxStamina.IsChecked == false) value = 0;
            else if (CheckboxMaxStamina.IsChecked == null) value = 16;
            else if (CheckboxMaxStamina.IsChecked == true) value = 32;

            _windWaker.UpdateMaxStamina(value);
        }

        private void BtUpdateMaxHealth_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateMaxHealth(int.Parse(TxtMaxHealth.Text));
        }

        private void BtUpdateHealth_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateHealth(int.Parse(TxtHealth.Text));
        }

        private void CheckBoxPowerBracelets_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdatePowerBracelets(CheckBoxPowerBracelets.IsChecked == true);
        }

        private void CheckboxPearls_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdatePearls(new bool[] { CheckboxPearlNayru.IsChecked == true, CheckboxPearlDin.IsChecked == true, CheckboxPearlFarore.IsChecked == true });
        }

        private void CheckboxTriforce_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateTriforceFragments(new bool[] {
                CheckboxTriforce1.IsChecked == true,
                CheckboxTriforce2.IsChecked == true,
                CheckboxTriforce3.IsChecked == true,
                CheckboxTriforce4.IsChecked == true,
                CheckboxTriforce5.IsChecked == true,
                CheckboxTriforce6.IsChecked == true,
                CheckboxTriforce7.IsChecked == true,
                CheckboxTriforce8.IsChecked == true
            });
        }

        private void SetupOnGridMapClicked()
        {
            foreach (var children in GridMap.Children)
            {
                Label map = (Label)children;
                if (Regex.Match(map.Content.ToString(), "^[A-G]\\d$", RegexOptions.IgnoreCase).Success)
                {
                    map.MouseLeftButtonUp += (sender, e) =>
                    {
                        bool unlocked = _windWaker.GetMapUnlocked(map.Content.ToString());
                        _windWaker.UpdateMapUnlocked(map.Content.ToString(), !unlocked);
                        map.Background = new SolidColorBrush(!unlocked ? Colors.Beige : Colors.Gray);
                    };
                }
            }
        }

        private void SetupInventoryClicked()
        {
            foreach (var children in GridInventory.Children)
            {
                Border element = (Border)children;
                element.MouseLeftButtonUp += (sender, e) =>
                {
                    int inventoryId = int.Parse(new Regex(@"\d+").Match(element.Name).Value);
                    Item? currentItem = GameItems.GetItemById(_windWaker.GetInventoryItem(inventoryId));
                    InventoryDialog inventoryDialog = new InventoryDialog(currentItem.HasValue ? currentItem.Value.Name : "") { Owner = this };
                    if (inventoryDialog.ShowDialog() == true)
                    {
                        _windWaker.UpdateInventoryItem(inventoryId, inventoryDialog.GetResult().ItemId);
                    }
                };
            }
        }

        private void SetupSpoilsBagInventoryClicked()
        {
            foreach (var children in SpoilsBagInventory.Children)
            {
                Label element = (Label)children;
                element.MouseLeftButtonUp += (sender, e) =>
                {
                    string index = element.Tag.ToString();
                    int quantity = _windWaker.GetSpoilsBagInventoryItemQty(index);
                    InventoryDialog inventoryDialog = new InventoryDialog(element.Content.ToString(), quantity, true) { Owner = this };
                    if (inventoryDialog.ShowDialog() != true) return;
                    var result = inventoryDialog.GetResult();
                    _windWaker.UpdateSpoilsBagInventoryItem(index, result.ItemId);
                    if (result.ItemQuantity != -1) _windWaker.UpdateSpoilsBagInventoryItemQty(index, result.ItemQuantity);
                };
            }
        }

        private void SetupTreasureMapClicked()
        {
            var childrenPanels = new[] { PanelTreasureMap1.Children, PanelTreasureMap2.Children, PanelTreasureMap3.Children };
            foreach (var children in childrenPanels)
            {
                foreach (var child in children)
                {
                    CheckBox mapCheckbox = (CheckBox)child;
                    mapCheckbox.Click += (sender, e) =>
                    {
                        int mapPack = int.Parse(mapCheckbox.Tag.ToString().Split('_')[0]);
                        int mapBit = int.Parse(mapCheckbox.Tag.ToString().Split('_')[1]);
                        _windWaker.UpdateMapFound(mapPack, mapBit, mapCheckbox.IsChecked == true);
                    };
                }
            }
        }

        private void SetupUnlocksClicked()
        {
            foreach (var child in PanelUnlockedItems.Children)
            {
                CheckBox checkbox = child as CheckBox;
                if (checkbox?.Tag == null) continue;

                if (checkbox.IsThreeState)
                {
                    checkbox.Click += (sender, e) =>
                    {
                        int val;
                        if (checkbox.IsChecked == false) val = 0;
                        else if (checkbox.IsChecked == null) val = 1;
                        else if (checkbox.IsChecked == true) val = 3;
                        else throw new Exception("Invalid checkbox value");

                        _windWaker.UpdateUnlockedItem(checkbox.Tag.ToString(), val);
                    };
                }
                else
                {
                    checkbox.Click += (sender, e) => _windWaker.UpdateUnlockedItem(checkbox.Tag.ToString(), checkbox.IsChecked == true ? 1 : 0);
                }
            }
        }

        private void SetupSongsClicked()
        {
            foreach (var child in PanelSongs.Children)
            {
                CheckBox checkbox = (CheckBox)child;
                checkbox.Click += (sender, e) => _windWaker.UpdateSongUnlocked(int.Parse(checkbox.Tag.ToString()), checkbox.IsChecked == true);
            }
        }

        private void CheckboxMapTriforceDecrypted1_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateTriforceDecrypted(1, CheckboxMapTriforceDecrypted1.IsChecked == true);
        }

        private void CheckboxMapTriforceDecrypted2_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateTriforceDecrypted(2, CheckboxMapTriforceDecrypted2.IsChecked == true);
        }

        private void CheckboxMapTriforceDecrypted3_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateTriforceDecrypted(3, CheckboxMapTriforceDecrypted3.IsChecked == true);
        }

        private void ComboBoxUnlockBow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxUnlockBow.SelectedValue == null) return;

            _windWaker.UpdateUnlockedItem("Bow", int.Parse(ComboBoxUnlockBow.SelectedValue.ToString()));
        }

        private void BtUpdateBombCount_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateBombQty(int.Parse(TxtBombCount.Text));
        }

        private void ComboMaxBomb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboMaxBomb.SelectedValue == null) return;
            _windWaker.UpdateMaxBombQty(int.Parse(ComboMaxBomb.SelectedValue.ToString()));
        }

        private void BtUpdateArrowCount_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateArrowQty(int.Parse(TxtArrowCount.Text));
        }

        private void ComboMaxArrow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboMaxArrow.SelectedValue == null) return;
            _windWaker.UpdateMaxArrowQty(int.Parse(ComboMaxArrow.SelectedValue.ToString()));
        }

        private void BtUpdateBeedlePoints_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateBeedlePoints(int.Parse(TxtBeedlePoints.Text));
        }

        private void ComboSwordType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboSwordType.SelectedValue == null) return;

            _windWaker.UpdateSwordType(int.Parse(ComboSwordType.SelectedValue.ToString()));
        }

        private void ComboShieldType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboShieldType.SelectedValue == null) return;

            _windWaker.UpdateShieldType(int.Parse(ComboShieldType.SelectedValue.ToString()));
        }

        private void CheckBoxUnlockWindWaker_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateWindWakerUnlocked(CheckBoxUnlockWindWaker.IsChecked == true);
        }

        private void CheckBoxUnlockHeroAmulet_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdateHeroAmuletUnlocked(CheckBoxUnlockHeroAmulet.IsChecked == true);
        }

        private void CheckBoxUnlockPiratesCharm_Click(object sender, RoutedEventArgs e)
        {
            _windWaker.UpdatePirateCharmUnlocked(CheckBoxUnlockPiratesCharm.IsChecked == true);
        }
        
        private void BtUpdatePlayerPosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float x = float.Parse(TxtPlayerX.Text);
                float y = float.Parse(TxtPlayerY.Text);
                float z = float.Parse(TxtPlayerZ.Text);

                _windWaker.UpdatePlayerPosition(x, y, z);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid coordinates. Verify number syntax.");
            }
        }
    }
}