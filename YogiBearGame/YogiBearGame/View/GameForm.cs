using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YogiBearGame.Model;
using YogiBearGame.Persistence;

namespace YogiBearGame
{
    public partial class GameForm : Form
    {
        #region Fields

        private IYogiBearDataAccess _dataAccess;
        private YogiBearGameModel _model;
        private Button[,] _buttonGrid;
        private Timer _timer;
        private bool _tableGenerated;
        #endregion

        #region Constructors

        /// <summary>
        /// Játékablak példányosítása.
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Form event handlers

        /// <summary>
        /// Játékablak betöltésének eseménykezelője.
        /// </summary>
        private void GameForm_Load(Object sender, EventArgs e)
        {
            // adatelérés példányosítása
            _dataAccess = new YogiBearFileDataAccess();

            // modell létrehozása és az eseménykezelők társítása
            _model = new YogiBearGameModel(_dataAccess);
            _model.GameAdvanced += new EventHandler<YogiBearEventArgs>(Game_GameAdvanced);
            _model.GameOver += new EventHandler<YogiBearEventArgs>(Game_GameOver);

            // időzítő létrehozása
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(Timer_Tick);

            KeyPreview = true; // billentyűesemények kelezése
            KeyDown += new KeyEventHandler(ButtonGrid_KeyDown);

            _menuFileNewGame.Enabled = false;
            _menuSettingsLarge.Enabled = false;
            _menuSettingsMedium.Enabled = false;
            _menuSettingsSmall.Enabled = false;
            _menuTimeStart.Enabled = false;
            _menuTimeStop.Enabled = false;
            _tableGenerated = false;
        }

        #endregion

        #region Game event handlers

        /// <summary>
        /// Játék előrehaladásának eseménykezelője.
        /// </summary>
        private void Game_GameAdvanced(Object sender, YogiBearEventArgs e)
        {
            _toolLabelGameTime.Text = TimeSpan.FromSeconds(e.GameTime).ToString("g");
            SetupTable();
            // játékidő frissítése
        }

        /// <summary>
        /// Játék végének eseménykezelője.
        /// </summary>
        private void Game_GameOver(Object sender, YogiBearEventArgs e)
        {
            _timer.Stop();
            SetupTable();

            if (e.IsWon) // győzelemtől függő üzenet megjelenítése
            {
                MessageBox.Show("Congratulation, you win!" + Environment.NewLine +
                                "Game time: " + TimeSpan.FromSeconds(e.GameTime).ToString("g"),
                                "Yogi Bear Game",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("A ranger saw you." +
                                "Sorry, you lose!",
                                "Yogi Bear Game",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Asterisk);
            }
        }

        #endregion

        #region Grid event handlers

        /// <summary>
        /// Gombrács eseménykezelője.
        /// </summary>

        private void ButtonGrid_KeyDown(Object sender, KeyEventArgs e)
        {
            if (_model.GameIsOn)
            {
                switch (e.KeyCode) // megkapjuk a billentyűt
                {
                    case Keys.A:
                        _model.Step(0, -1);
                        e.SuppressKeyPress = true; // az eseményt nem adjuk tovább a vezérlőnek
                        break;
                    case Keys.S:
                        _model.Step(1, 0);
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.D:
                        _model.Step(0, 1);
                        e.SuppressKeyPress = true;
                        break;
                    case Keys.W:
                        _model.Step(-1, 0);
                        e.SuppressKeyPress = true;
                        break;
                }

                //mezők frissítése
                SetupTable();
            }
        }

        #endregion

        #region Menu event handlers

        /// <summary>
        /// Új játék eseménykezelője.
        /// </summary>
        private void MenuFileNewGame_Click(Object sender, EventArgs e)
        {
            if (_tableGenerated) RemoveTable();
            // játéktábla és menük inicializálása

            _model.NewGame();
            switch (_model.GameTable)
            {
                case GameTable.Small: GenerateTable(80); this.Size = new Size(500, 580); break;
                case GameTable.Medium: GenerateTable(70); this.Size = new Size(866, 945); break;
                case GameTable.Large: GenerateTable(50); this.Size = new Size(928, 1002); break;
            }
            _tableGenerated = true;

            SetupTable();
            SetupMenus();

            _timer.Start();
            _menuTimeStop.Enabled = true;
        }

        /// <summary>
        /// Kilépés eseménykezelője.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuFileExit_Click(Object sender, EventArgs e)
        {
            Boolean restartTimer = _timer.Enabled;
            _timer.Stop();

            // megkérdezzük, hogy biztos ki szeretne-e lépni
            if (MessageBox.Show("Are you sure to leave the game?", "Yogi Bear Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // ha igennel válaszol
                Close();
            }
            else
            {
                if (restartTimer)
                    _timer.Start();
            }
        }

        private async void MenuLoadGameTables(Object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) // ha kiválasztottunk egy fájlt
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        await _model.LoadGameAsync(file);
                    }
                    catch (YogiBearDataException)
                    {
                        MessageBox.Show("Game loading failed!" + Environment.NewLine + "The access path or the file format is wrong.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                _menuFileNewGame.Enabled = true;
                _menuSettingsLarge.Enabled = true;
                _menuSettingsMedium.Enabled = true;
                _menuSettingsSmall.Enabled = true;
                _menuSettingsSmall.Checked = true;

                _model.GameTable = GameTable.Small;
            }
        }

        private void MenuGameSmall_Click(Object sender, EventArgs e)
        {
            _model.GameTable = GameTable.Small;
            _menuSettingsSmall.Checked = true;
            _menuSettingsMedium.Checked = false;
            _menuSettingsLarge.Checked = false;
        }

        private void MenuGameMedium_Click(Object sender, EventArgs e)
        {
            _model.GameTable = GameTable.Medium;
            _menuSettingsSmall.Checked = false;
            _menuSettingsMedium.Checked = true;
            _menuSettingsLarge.Checked = false;
        }

        private void MenuGameLarge_Click(Object sender, EventArgs e)
        {
            _model.GameTable = GameTable.Large;
            _menuSettingsSmall.Checked = false;
            _menuSettingsMedium.Checked = false;
            _menuSettingsLarge.Checked = true;
        }

        private void MenuStart_Click(Object sender, EventArgs e)
        {
            _menuTimeStop.Enabled = true;
            _menuTimeStart.Enabled = false;
            _model.GameIsOn = true;

            _timer.Start();
        }

        private void MenuStop_Click(Object sender, EventArgs e)
        {
            _menuTimeStop.Enabled = false;
            _menuTimeStart.Enabled = true;
            _model.GameIsOn = false;

            _timer.Stop();
        }
        #endregion

        #region Timer event handlers

        /// <summary>
        /// Időzítő eseménykeztelője.
        /// </summary>
        private void Timer_Tick(Object sender, EventArgs e)
        {
            _model.AdvanceTime(); // játék léptetése
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Új tábla létrehozása.
        /// </summary>
        private void GenerateTable(int size)
        {
            _buttonGrid = new Button[_model.Table.Size, _model.Table.Size];
            for (Int32 i = 0; i < _model.Table.Size; i++)
                for (Int32 j = 0; j < _model.Table.Size; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Location = new Point(5 + size * j, 35 + size * i); // elhelyezkedés
                    _buttonGrid[i, j].Size = new Size(size, size); // méret
                    _buttonGrid[i, j].Enabled = false; // kikapcsolt állapot
                    _buttonGrid[i, j].TabIndex = 100 + i * _model.Table.Size + j; // a gomb számát a TabIndex-ben tároljuk
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat; // lapított stípus
                    _buttonGrid[i, j].BackColor = Color.FromArgb(169,255,83);
                    _buttonGrid[i, j].KeyDown += new KeyEventHandler(ButtonGrid_KeyDown);
                    _buttonGrid[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    // közös eseménykezelő hozzárendelése minden gombhoz

                    Controls.Add(_buttonGrid[i, j]);
                    // felvesszük az ablakra a gombot
                }
        }

        /// <summary>
        /// Tábla beállítása.
        /// </summary>
        private void SetupTable()
        {
            for (Int32 i = 0; i < _buttonGrid.GetLength(0); i++)
            {
                for (Int32 j = 0; j < _buttonGrid.GetLength(1); j++)
                {
                    switch (_model.Table.GetValue(i,j))
                    {
                        
                        case 0: _buttonGrid[i, j].BackColor = Color.FromArgb(169, 255, 83); break;
                        case 1: _buttonGrid[i, j].BackColor = Color.Black; break;
                        case 2: _buttonGrid[i, j].BackColor = Color.Blue; break;
                        case 3: _buttonGrid[i, j].BackColor = Color.Yellow; break;
                        case 4: _buttonGrid[i, j].BackColor = Color.Red; break;
                        
                        /*
                        case 0: _buttonGrid[i, j].Image = null; break;
                        case 1: _buttonGrid[i, j].Image = Image.FromFile(@"C:\Users\jecsa\OneDrive - Eotvos Lorand Tudomanyegyetem\Asztal\Fruzsi Fájlok\Egyetem\5félév\EVA\Beadando_1\YogiBearGame\YogiBearGame\View\yogi_bear.png"); break;
                        case 2: _buttonGrid[i, j].Image = Image.FromFile(@"C:\Users\jecsa\OneDrive - Eotvos Lorand Tudomanyegyetem\Asztal\Fruzsi Fájlok\Egyetem\5félév\EVA\Beadando_1\YogiBearGame\YogiBearGame\View\park_ranger.jpg"); break;
                        case 3: _buttonGrid[i, j].Image = Image.FromFile(@"C:\Users\jecsa\OneDrive - Eotvos Lorand Tudomanyegyetem\Asztal\Fruzsi Fájlok\Egyetem\5félév\EVA\Beadando_1\YogiBearGame\YogiBearGame\View\tree.png"); break;
                        case 4: _buttonGrid[i, j].Image = Image.FromFile(@"C:\Users\jecsa\OneDrive - Eotvos Lorand Tudomanyegyetem\Asztal\Fruzsi Fájlok\Egyetem\5félév\EVA\Beadando_1\YogiBearGame\YogiBearGame\View\picnic_basket.jpg"); break;
                        */
                    }
                }
            }
            _toolLabelPicnicBasketCounter.Text = _model.Table.PickedBasketsCount.ToString();
            _toolLabelGameTime.Text = TimeSpan.FromSeconds(_model.GameTime).ToString("g");
        }

        private void RemoveTable()
        {
            for (int i = 0; i < _model.Table.Size; i++)
                for (int j = 0; j < _model.Table.Size; j++)
                    Controls.Remove(_buttonGrid[i, j]);
            _buttonGrid = null;
        }

        /// <summary>
        /// Menük beállítása.
        /// </summary>
        private void SetupMenus()
        {
            _menuSettingsSmall.Checked = (_model.GameTable == GameTable.Small);
            _menuSettingsMedium.Checked = (_model.GameTable == GameTable.Medium);
            _menuSettingsLarge.Checked = (_model.GameTable == GameTable.Large);
        }

        #endregion
    }
}
