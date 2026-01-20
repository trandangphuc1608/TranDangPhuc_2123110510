using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace TranDangPhuc_2123110510
{
    public enum GameState { Menu, Playing, GameOver }
    public enum Difficulty { Easy, Medium, Hard }

    public partial class Form31 : Form
    {
        private GameState currentState = GameState.Menu;
        private Difficulty currentDifficulty = Difficulty.Easy;
        private Random rand = new Random();
        private string currentPlayer;

        // Menu 4 mục: 0:Easy, 1:Medium, 2:Hard, 3:Leaderboard
        private int menuIndex = 0;

        private int score = 0;
        private int lives = 3;
        private int level = 1;
        private int highScore = 0; // Biến lưu kỷ lục

        private int chickenSpawnRate = 50;
        private int chickenSpeedBase = 3;
        private int scoreToNextLevel = 100;
        private int spawnCounter = 0;

        private PlayerShip player;
        private List<Bullet> bullets = new List<Bullet>();
        private List<Chicken> chickens = new List<Chicken>();

        private bool goLeft, goRight, isShooting;

        public Form31(string username)
        {
            InitializeComponent();

            // Xử lý tên: Cắt bỏ khoảng trắng thừa để tránh lỗi tìm trong SQL
            this.currentPlayer = username != null ? username.Trim() : "Guest";

            this.KeyPreview = true;

            // [SỬA LỖI 1] Ẩn các nhãn điểm số khi mới vào (để không đè lên Menu)
            SetGameUI(false);

            // Tải kỷ lục ngay khi mở game
            LoadHighScore();

            tmGameLoop.Start();
        }

        // Hàm ẩn/hiện giao diện chơi game
        private void SetGameUI(bool isPlaying)
        {
            lblScore.Visible = isPlaying;
            lblLives.Visible = isPlaying;
            lblLevel.Visible = isPlaying;

            // GameOver luôn ẩn khi bắt đầu hoặc vào menu
            if (isPlaying) lblGameOver.Visible = false;
        }

        private void StartGame()
        {
            if (menuIndex == 0) currentDifficulty = Difficulty.Easy;
            else if (menuIndex == 1) currentDifficulty = Difficulty.Medium;
            else if (menuIndex == 2) currentDifficulty = Difficulty.Hard;

            player = new PlayerShip(this.ClientSize.Width / 2 - 25, this.ClientSize.Height - 50);
            bullets.Clear();
            chickens.Clear();
            score = 0;
            lives = 3;
            level = 1;
            spawnCounter = 0;

            // Tải lại điểm lần nữa cho chắc
            LoadHighScore();

            ApplyDifficultySettings();

            currentState = GameState.Playing;

            // [SỬA LỖI 1] Hiện các nhãn điểm số lên
            SetGameUI(true);

            UpdateUI();
        }

        private void ApplyDifficultySettings()
        {
            switch (currentDifficulty)
            {
                case Difficulty.Easy:
                    chickenSpawnRate = 60; chickenSpeedBase = 3; scoreToNextLevel = 100; break;
                case Difficulty.Medium:
                    chickenSpawnRate = 45; chickenSpeedBase = 5; scoreToNextLevel = 150; break;
                case Difficulty.Hard:
                    chickenSpawnRate = 30; chickenSpeedBase = 7; scoreToNextLevel = 200; break;
            }
        }

        private void CheckLevelUp()
        {
            if (score >= level * scoreToNextLevel)
            {
                level++;
                if (chickenSpawnRate > 10) chickenSpawnRate -= 5;
                chickenSpeedBase += 1;
                if (level % 3 == 0) lives++;
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            int currentDisplayHigh = (score > highScore) ? score : highScore;
            lblScore.Text = $"Score: {score}  |  Best: {currentDisplayHigh}";
            lblLives.Text = "Lives: " + lives;
            lblLevel.Text = "Level: " + level;
        }

        private void GameOver()
        {
            currentState = GameState.GameOver;
            lblGameOver.Text = "GAME OVER\nScore: " + score + "\nPress ENTER to Menu";
            lblGameOver.Location = new Point((this.ClientSize.Width - lblGameOver.Width) / 2, 200);
            lblGameOver.Visible = true;
            SaveHighScore();
        }

        private void SaveHighScore()
        {
            if (string.IsNullOrEmpty(currentPlayer) || currentPlayer == "Guest") return;
            try
            {
                DatabaseUtils db = new DatabaseUtils();
                // Check xem user có tồn tại không
                string sqlCheck = $"SELECT HighScore FROM Users WHERE Username = '{currentPlayer}'";
                DataTable dt = db.GetData(sqlCheck);

                if (dt.Rows.Count > 0)
                {
                    int currentHighScore = 0;
                    if (dt.Rows[0]["HighScore"] != DBNull.Value)
                        currentHighScore = Convert.ToInt32(dt.Rows[0]["HighScore"]);

                    if (score > currentHighScore)
                    {
                        string sqlUpdate = $"UPDATE Users SET HighScore = {score} WHERE Username = '{currentPlayer}'";
                        db.ExecuteQuery(sqlUpdate);
                        MessageBox.Show($"Kỷ lục mới của {currentPlayer}: {score}!", "Chúc mừng");
                        highScore = score; // Cập nhật biến local luôn
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi save: " + ex.Message); }
        }

        // [SỬA LỖI 2] Hàm đọc điểm (Thêm báo lỗi chi tiết)
        private void LoadHighScore()
        {
            if (string.IsNullOrEmpty(currentPlayer) || currentPlayer == "Guest") return;

            try
            {
                DatabaseUtils db = new DatabaseUtils();

                // Kiểm tra kết nối trước
                if (!db.Connect()) return;

                string sql = $"SELECT HighScore FROM Users WHERE Username = '{currentPlayer}'";
                DataTable dt = db.GetData(sql);

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["HighScore"] != DBNull.Value)
                    {
                        highScore = Convert.ToInt32(dt.Rows[0]["HighScore"]);
                    }
                    else
                    {
                        highScore = 0;
                    }
                }
                else
                {
                    // Nếu không tìm thấy user này trong bảng Users
                    // (Có thể do login sai hoặc user bị xóa)
                    highScore = 0;
                }

                db.Disconnect();
            }
            catch (Exception ex)
            {
                // Hiện lỗi để biết tại sao không đọc được
                MessageBox.Show("Lỗi đọc điểm từ SQL: " + ex.Message);
                highScore = 0;
            }
        }

        private void tmGameLoop_Tick(object sender, EventArgs e)
        {
            if (currentState != GameState.Playing)
            {
                this.Invalidate();
                return;
            }

            if (goLeft && player.X > 0) player.MoveLeft();
            if (goRight && player.X < this.ClientSize.Width - player.Width) player.MoveRight();

            if (isShooting)
            {
                bullets.Add(new Bullet(player.X + player.Width / 2 - 2, player.Y));
                isShooting = false;
            }

            spawnCounter++;
            if (spawnCounter >= chickenSpawnRate)
            {
                int spawnX = rand.Next(0, this.ClientSize.Width - 40);
                int currentSpeed = chickenSpeedBase + (level / 2);
                chickens.Add(new Chicken(spawnX, -40, currentSpeed));
                spawnCounter = 0;
            }

            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
                if (bullets[i].IsOutOfBounds) bullets.RemoveAt(i);
            }

            for (int i = chickens.Count - 1; i >= 0; i--)
            {
                chickens[i].Update();
                for (int j = bullets.Count - 1; j >= 0; j--)
                {
                    if (bullets[j].Bounds.IntersectsWith(chickens[i].Bounds))
                    {
                        score += 10;
                        chickens.RemoveAt(i);
                        bullets.RemoveAt(j);
                        CheckLevelUp();
                        UpdateUI();
                        goto NextChicken;
                    }
                }

                if (chickens[i].Y > this.ClientSize.Height || chickens[i].Bounds.IntersectsWith(player.Bounds))
                {
                    lives--;
                    chickens.RemoveAt(i);
                    UpdateUI();
                    if (lives <= 0) GameOver();
                }
            NextChicken: continue;
            }
            this.Invalidate();
        }

        private void Form31_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (currentState == GameState.Menu) DrawMenu(g);
            else if (currentState == GameState.Playing || currentState == GameState.GameOver)
            {
                if (player != null) player.Draw(g);
                foreach (var b in bullets) b.Draw(g);
                foreach (var c in chickens) c.Draw(g);
            }
        }

        private void DrawMenu(Graphics g)
        {
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center };
            g.DrawString("CHICKEN HUNTER", new Font("Segoe UI", 30, FontStyle.Bold), Brushes.Orange, this.ClientSize.Width / 2, 60, sf);

            // [SỬA] Vẽ tên người chơi ở góc TRÊN CÙNG BÊN PHẢI để không bị đè
            if (!string.IsNullOrEmpty(currentPlayer))
            {
                string txt = $"Player: {currentPlayer}";
                // Đo chiều dài chữ để căn phải
                SizeF size = g.MeasureString(txt, new Font("Segoe UI", 12, FontStyle.Bold));
                g.DrawString(txt, new Font("Segoe UI", 12, FontStyle.Bold), Brushes.Cyan, this.ClientSize.Width - size.Width - 20, 20);
            }

            Brush b0 = (menuIndex == 0) ? Brushes.Lime : Brushes.Gray;
            Brush b1 = (menuIndex == 1) ? Brushes.Yellow : Brushes.Gray;
            Brush b2 = (menuIndex == 2) ? Brushes.Red : Brushes.Gray;
            Brush b3 = (menuIndex == 3) ? Brushes.Cyan : Brushes.Gray;

            string t0 = (menuIndex == 0 ? "> " : "") + "EASY";
            string t1 = (menuIndex == 1 ? "> " : "") + "MEDIUM";
            string t2 = (menuIndex == 2 ? "> " : "") + "HARD";
            string t3 = (menuIndex == 3 ? "> " : "") + "VIEW LEADERBOARD";

            Font fontMenu = new Font("Segoe UI", 20, FontStyle.Bold);
            g.DrawString(t0, fontMenu, b0, this.ClientSize.Width / 2, 180, sf);
            g.DrawString(t1, fontMenu, b1, this.ClientSize.Width / 2, 240, sf);
            g.DrawString(t2, fontMenu, b2, this.ClientSize.Width / 2, 300, sf);
            g.DrawString(t3, new Font("Segoe UI", 16, FontStyle.Bold), b3, this.ClientSize.Width / 2, 380, sf);

            g.DrawString("Use UP/DOWN to select, ENTER to Confirm", new Font("Segoe UI", 10), Brushes.LightGray, this.ClientSize.Width / 2, 450, sf);
        }

        private void Form31_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentState == GameState.Menu)
            {
                if (e.KeyCode == Keys.Up)
                {
                    menuIndex--;
                    if (menuIndex < 0) menuIndex = 3;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    menuIndex++;
                    if (menuIndex > 3) menuIndex = 0;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (menuIndex == 3)
                    {
                        LeaderboardForm lb = new LeaderboardForm();
                        lb.ShowDialog();
                    }
                    else
                    {
                        StartGame();
                    }
                }
            }
            else if (currentState == GameState.Playing)
            {
                if (e.KeyCode == Keys.Left) goLeft = true;
                if (e.KeyCode == Keys.Right) goRight = true;
                if (e.KeyCode == Keys.Space) isShooting = true;
            }
            else if (currentState == GameState.GameOver)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.Close();
                }
            }
        }

        private void Form31_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Space) isShooting = false;
        }
    }

    // --- CÁC CLASS ĐỐI TƯỢNG (ĐẦY ĐỦ) ---
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public Rectangle Bounds => new Rectangle(X, Y, Width, Height);
        public GameObject(int x, int y, int w, int h, Color color) { X = x; Y = y; Width = w; Height = h; Color = color; }
        public abstract void Draw(Graphics g);
    }

    public class PlayerShip : GameObject
    {
        private int speed = 10;
        public PlayerShip(int x, int y) : base(x, y, 50, 30, Color.Cyan) { }
        public void MoveLeft() => X -= speed;
        public void MoveRight() => X += speed;
        public override void Draw(Graphics g)
        {
            Point[] points = { new Point(X + Width / 2, Y), new Point(X + Width, Y + Height), new Point(X, Y + Height) };
            g.FillPolygon(new SolidBrush(this.Color), points);
        }
    }

    public class Bullet : GameObject
    {
        private int speed = 15;
        public bool IsOutOfBounds => Y + Height < 0;
        public Bullet(int x, int y) : base(x, y, 4, 15, Color.Yellow) { }
        public void Update() => Y -= speed;
        public override void Draw(Graphics g) => g.FillRectangle(new SolidBrush(this.Color), this.Bounds);
    }

    public class Chicken : GameObject
    {
        public int Speed { get; set; }
        public Chicken(int x, int y, int speed) : base(x, y, 40, 40, Color.OrangeRed) { this.Speed = speed; }
        public void Update() => Y += Speed;
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(this.Color), this.Bounds);
            g.FillEllipse(Brushes.White, X + 5, Y + 10, 10, 10);
            g.FillEllipse(Brushes.White, X + 25, Y + 10, 10, 10);
        }
    }
}