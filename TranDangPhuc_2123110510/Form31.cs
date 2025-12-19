using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TranDangPhuc_2123110510
{
    // Enum trạng thái game
    public enum GameState { Menu, Playing, GameOver }

    // Enum độ khó
    public enum Difficulty { Easy, Medium, Hard }

    public partial class Form31 : Form
    {
        // --- TRẠNG THÁI HỆ THỐNG ---
        private GameState currentState = GameState.Menu;
        private Difficulty currentDifficulty = Difficulty.Easy;
        private Random rand = new Random();

        // [MỚI] Biến theo dõi vị trí menu đang chọn (0, 1, 2)
        private int menuIndex = 0;

        // --- CẤU HÌNH GAME ---
        private int score = 0;
        private int lives = 3;
        private int level = 1;

        // Các biến điều chỉnh độ khó
        private int chickenSpawnRate = 50;
        private int chickenSpeedBase = 3;
        private int scoreToNextLevel = 100;
        private int spawnCounter = 0;

        // --- CÁC ĐỐI TƯỢNG GAME ---
        private PlayerShip player;
        private List<Bullet> bullets = new List<Bullet>();
        private List<Chicken> chickens = new List<Chicken>();

        // --- INPUT ---
        private bool goLeft, goRight, isShooting;

        public Form31()
        {
            InitializeComponent();

            // [QUAN TRỌNG] Phải có dòng này phím mới ăn
            this.KeyPreview = true;

            // Bắt đầu game loop
            tmGameLoop.Start();
        }

        // --- HÀM KHỞI TẠO GAME MỚI ---
        private void StartGame()
        {
            // Set độ khó dựa trên menu đang chọn
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

            ApplyDifficultySettings();

            currentState = GameState.Playing;
            lblGameOver.Visible = false;
            lblLevel.Visible = true;
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
            lblScore.Text = "Score: " + score;
            lblLives.Text = "Lives: " + lives;
            lblLevel.Text = "Level: " + level;
        }

        private void GameOver()
        {
            currentState = GameState.GameOver;
            lblGameOver.Text = "GAME OVER\nScore: " + score + "\nPress ENTER to Menu";
            lblGameOver.Location = new Point((this.ClientSize.Width - lblGameOver.Width) / 2, 200);
            lblGameOver.Visible = true;
        }

        // --- GAME LOOP ---
        private void tmGameLoop_Tick(object sender, EventArgs e)
        {
            if (currentState != GameState.Playing)
            {
                this.Invalidate();
                return;
            }

            // Logic Di chuyển & Bắn
            if (goLeft && player.X > 0) player.MoveLeft();
            if (goRight && player.X < this.ClientSize.Width - player.Width) player.MoveRight();

            if (isShooting)
            {
                bullets.Add(new Bullet(player.X + player.Width / 2 - 2, player.Y));
                isShooting = false;
            }

            // Sinh gà
            spawnCounter++;
            if (spawnCounter >= chickenSpawnRate)
            {
                int spawnX = rand.Next(0, this.ClientSize.Width - 40);
                int currentSpeed = chickenSpeedBase + (level / 2);
                chickens.Add(new Chicken(spawnX, -40, currentSpeed));
                spawnCounter = 0;
            }

            // Xử lý đạn
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
                if (bullets[i].IsOutOfBounds) bullets.RemoveAt(i);
            }

            // Xử lý Gà & Va chạm
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

        // [CẬP NHẬT] Vẽ Menu tô màu dòng đang chọn
        private void DrawMenu(Graphics g)
        {
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center };
            g.DrawString("CHICKEN HUNTER", new Font("Segoe UI", 30, FontStyle.Bold), Brushes.Orange, this.ClientSize.Width / 2, 80, sf);
            g.DrawString("Use UP/DOWN to select, ENTER to Start", new Font("Segoe UI", 12), Brushes.LightGray, this.ClientSize.Width / 2, 140, sf);

            // Kiểm tra menuIndex để tô màu
            Brush b1 = (menuIndex == 0) ? Brushes.Lime : Brushes.Gray;
            Brush b2 = (menuIndex == 1) ? Brushes.Yellow : Brushes.Gray;
            Brush b3 = (menuIndex == 2) ? Brushes.Red : Brushes.Gray;

            // Thêm dấu ">" vào trước dòng đang chọn
            string t1 = (menuIndex == 0 ? "> " : "") + "EASY";
            string t2 = (menuIndex == 1 ? "> " : "") + "MEDIUM";
            string t3 = (menuIndex == 2 ? "> " : "") + "HARD";

            g.DrawString(t1, new Font("Segoe UI", 24, FontStyle.Bold), b1, this.ClientSize.Width / 2, 220, sf);
            g.DrawString(t2, new Font("Segoe UI", 24, FontStyle.Bold), b2, this.ClientSize.Width / 2, 280, sf);
            g.DrawString(t3, new Font("Segoe UI", 24, FontStyle.Bold), b3, this.ClientSize.Width / 2, 340, sf);
        }

        private void Form31_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentState == GameState.Menu)
            {
                // [CẬP NHẬT] Xử lý phím Lên/Xuống
                if (e.KeyCode == Keys.Up)
                {
                    menuIndex--;
                    if (menuIndex < 0) menuIndex = 2; // Vòng xuống dưới cùng
                }
                else if (e.KeyCode == Keys.Down)
                {
                    menuIndex++;
                    if (menuIndex > 2) menuIndex = 0; // Vòng lên trên cùng
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    StartGame();
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
                    currentState = GameState.Menu;
                    lblGameOver.Visible = false;
                    lblLevel.Visible = false;
                    UpdateUI();
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

    // --- CÁC CLASS ĐỐI TƯỢNG (Giữ nguyên) ---
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