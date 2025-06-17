using ServiceLayer;
using BusinessLayer;
using System.Drawing.Drawing2D;
using DataLayer.Migrations;
using System.CodeDom;
using Timer = System.Windows.Forms.Timer;
using System.Net;
namespace WinFormsUI
{
    public partial class mainMenu : Form
    {
        private int tileSize = 50;
        private int drillingTime = 500;
        Tile[,] groundMatrix;
        List<Timer> activeDrills = new List<Timer>();
        private static Map Map;
        User User { get; set; }
        public mainMenu()
        {
            InitializeComponent();
        }

        private void UpdateGridVisual()
        {
            try
            {

            groundMatrix = mapService.GetGroundMatrix(Map);
            stoneCountLabel.Text = Map.StoneGathered.ToString();
            activeDrills.ForEach(timer => timer.Stop());
            activeDrills.Clear();
            int rows = Map.Height;
            int cols = Map.Width;
            matrixGridView.Rows.Clear();
            matrixGridView.Columns.Clear();
            matrixGridView.RowCount = rows;
            matrixGridView.ColumnCount = cols;
            GetTileSize();
            for (int i = 0; i < cols; i++)
            {
                matrixGridView.Columns[i].Width = tileSize;
            }
            for (int i = 0; i < rows; i++)
            {
                matrixGridView.Rows[i].Height = tileSize;
            }
            matrixGridView.Size = new Size(cols * tileSize + 2, rows * tileSize + 2);
            int height = 0;
            if (rows * tileSize + tileSize + 40 < 500)
            {
                height = 500;
            }
            else
            {
                height = rows * tileSize + tileSize + 40;
            }
            mainMenu.ActiveForm.Size = new Size(cols * tileSize + tileSize + 105, height);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var tile = groundMatrix[row, col];
                    var cell = matrixGridView.Rows[row].Cells[col];
                    cell.Style.BackColor = tile.Color;
                }
            }
            foreach (var structure in Map.Structures)
            {
                for (int i = 0; i < structure.Coordinates.Count; i++)
                {
                    int x = structure.Coordinates[i].X;
                    int y = structure.Coordinates[i].Y;

                    var tile = groundMatrix[y, x];
                    var cell = matrixGridView.Rows[y].Cells[x];
                    cell.Value = structure.Symbols[i];
                    cell.Style.BackColor = structure.Colors[i];
                }
            }

            foreach (var structure in Map.Structures)
            {
                switch (structure.StructureType)
                {
                    case StructureType.GreenHouse:
                        break;
                    case StructureType.Fertiliser:
                        break;
                    case StructureType.Drill:

                        int activeDrillTiles = 0;
                        for (int i = 0; i < structure.Colors.Count; i++)
                        {
                            if (structure.Colors[i] == Color.Gold)
                            {
                                activeDrillTiles++;
                            }
                        }
                        Timer newDrill = new Timer();
                        activeDrills.Add(newDrill);
                        newDrill.Interval = drillingTime;

                        newDrill.Tag = activeDrillTiles;

                        newDrill.Tick += Drill_Mine;
                        newDrill.Start();

                        break;
                    default:
                        break;
                }
            }

            int currentMapCount = GetCurrentMapCount();
            matrixGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetCurrentMapCount()
        {
            int index = 1;
            foreach (var map in User.Maps)
            {
                if (map.Id == Map.Id)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private void menuLoad(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            mapService = new MapService();
            userService = new UserService();
            matrixGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            matrixGridView.DefaultCellStyle.SelectionForeColor = Color.Black;
            matrixGridView.ClearSelection(); 
            matrixGridView.ReadOnly = true; 
            matrixGridView.AllowUserToResizeRows = false;
            matrixGridView.AllowUserToResizeColumns = false;
            matrixGridView.RowHeadersVisible = false;
            matrixGridView.ColumnHeadersVisible = false;
            matrixGridView.ScrollBars = ScrollBars.None;
            matrixGridView.ClearSelection();
            matrixGridView.MultiSelect = false;
            actionSelectComboBox.Items.Add("Drill");
            GUIControl(false);
        }
        private void GetTileSize()
        {
            int rows = matrixGridView.Rows.Count;
            int cols = matrixGridView.Columns.Count;

            int x = 1750 / cols;
            int y = 1000 / rows;

            tileSize = Math.Min(x, y);
            if (tileSize > 50) tileSize = 50;
        }

        MapService mapService;
        UserService userService;

        private void matrixGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            xLabel.Text = (matrixGridView.SelectedCells[0].ColumnIndex).ToString();
            yLabel.Text = (matrixGridView.SelectedCells[0].RowIndex).ToString();

            int x = matrixGridView.SelectedCells[0].ColumnIndex;
            int y = matrixGridView.SelectedCells[0].RowIndex;
            groundMatrix = mapService.GetGroundMatrix(Map);
            Tile selectedTile = groundMatrix[y, x];
            string output = "";
            label4.BackColor = selectedTile.Color;

            switch (selectedTile.Type)
            {
                case TileType.MarsSurface:
                    output += "Mars Surface";
                    break;
                case TileType.Soil:
                    output += "Soil";
                    break;
                case TileType.Stone:
                    output += "Stone";
                    break;
                case TileType.Water:
                    output += "Water";
                    break;
                case TileType.UndergroundWater:
                    output += "Underground Water";
                    break;
                case TileType.Ice:
                    output += "Ice";
                    break;
                default:
                    break;
            }
            foreach (var structure in Map.Structures)
            {
                foreach (var coordinate in structure.Coordinates)
                {
                    if (coordinate.X == x && coordinate.Y == y)
                    {
                        output += Environment.NewLine;
                        output += structure.StructureType.ToString();
                        break;
                    }
                }
            }
            label4.Text = output;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GUIControl(bool logged)
        {
            if (logged)
            {
                loginButton.Visible = true;
                mapsButton.Visible = true;
                xLabel.Visible = true;
                yLabel.Visible = true;
                label4.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                actionSelectComboBox.Visible = true;
                placeButton.Visible = true;
                removeButton.Visible = true;
                laserButton.Visible = true;
                stoneCountLabel.Visible = true;
            }
            else
            {
                loginButton.Visible = true;
                mapsButton.Visible = false;
                xLabel.Visible = false;
                yLabel.Visible = false;
                label4.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                actionSelectComboBox.Visible = false;
                placeButton.Visible = false;  
                removeButton.Visible = false;
                laserButton.Visible = false;
                stoneCountLabel.Visible = false;
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
            using (UserLogin userLogin = new UserLogin())
            {
                if (userLogin.ShowDialog() == DialogResult.OK)
                {
                    User = userLogin.User;
                    GUIControl(true);
                    MessageBox.Show($"Welcome {User.Username}");
                    
                }
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void placeButton_Click(object sender, EventArgs e)
        {
            try
            {
            var selectedAction = actionSelectComboBox.SelectedItem.ToString();
            switch (selectedAction)
            {
                case "Drill":
                    PlaceDrill();
                    break;
                default:
                    break;
            }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Select a tile to place the structure!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlaceDrill()
        {
            
            int x = matrixGridView.SelectedCells[0].ColumnIndex;
            int y = matrixGridView.SelectedCells[0].RowIndex;
            groundMatrix = mapService.GetGroundMatrix(Map);
            Structure drill = mapService.PlaceDrill(groundMatrix, Map, x, y);

            for (int i = 0; i < drill.Coordinates.Count; i++)
            {
                int x1 = drill.Coordinates[i].X;
                int y1 = drill.Coordinates[i].Y;

                var tile = groundMatrix[y1, x1];
                var cell = matrixGridView.Rows[y1].Cells[x1];
                cell.Value = drill.Symbols[i];
                cell.Style.BackColor = drill.Colors[i];
            }
            int activeDrillTiles = 0;
            for (int i = 0; i < drill.Colors.Count; i++)
            {
                if (drill.Colors[i] == Color.Gold)
                {
                    activeDrillTiles++;
                }
            }
            Timer newDrill = new Timer();
            newDrill.Interval = drillingTime;
            activeDrills.Add(newDrill);
            newDrill.Tag = activeDrillTiles;

            newDrill.Tick += Drill_Mine;
            newDrill.Start();

        }
        private void Drill_Mine(object sender, EventArgs e)
        {
                Timer currentDrill = sender as Timer;
                int stonesToAdd = (int)(currentDrill.Tag ?? 1);
                mapService.AddStone(Map, stonesToAdd);
                stoneCountLabel.Text = (int.Parse(stoneCountLabel.Text) + stonesToAdd).ToString();
            
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                int x = matrixGridView.SelectedCells[0].ColumnIndex;
                int y = matrixGridView.SelectedCells[0].RowIndex;
                groundMatrix = mapService.GetGroundMatrix(Map);
                (Structure, int) drillInfo = mapService.RemoveDrill(Map, x, y);
                Structure drill = drillInfo.Item1;
                int drillIndex = drillInfo.Item2;
                activeDrills[drillIndex].Stop();
                activeDrills.RemoveAt(drillIndex);
                for (int i = 0; i < drill.Coordinates.Count; i++)
                {
                    int x1 = drill.Coordinates[i].X;
                    int y1 = drill.Coordinates[i].Y;

                    var tile = groundMatrix[y1, x1];
                    var cell = matrixGridView.Rows[y1].Cells[x1];
                    cell.Value = null;
                    cell.Style.BackColor = tile.Color;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Select a tile to remove the structure!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void mapsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (matrixGridView.Rows != null)
                {
                    matrixGridView.Rows.Clear();
                    matrixGridView.Columns.Clear();
                }

                using (LoadMap loadMap = new LoadMap(User))
                {
                    if (loadMap.ShowDialog() == DialogResult.OK)
                    {
                        Map = loadMap.Map;
                        UpdateGridVisual();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void laserButton_Click(object sender, EventArgs e)
        {
            try
            {
                groundMatrix = mapService.GetGroundMatrix(Map);
                int x = matrixGridView.SelectedCells[0].ColumnIndex;
                int y = matrixGridView.SelectedCells[0].RowIndex;

                int laserStrength = 1;
                (List<Coordinate>, Map) values = mapService.UseLaser(Map, groundMatrix, x, y, laserStrength);
                List<Coordinate> coordinates = values.Item1;
                Map = values.Item2;
                foreach (var coordinate in coordinates)
                {
                    var tile = mapService.GetGroundMatrix(Map)[coordinate.Y, coordinate.X];
                    var cell = matrixGridView.Rows[coordinate.Y].Cells[coordinate.X];
                    cell.Style.BackColor = tile.Color;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Select a tile to use the Laser!");
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
