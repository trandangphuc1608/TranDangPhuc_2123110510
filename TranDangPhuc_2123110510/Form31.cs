using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D; // Vẽ hình đẹp (Khử răng cưa)
using System.Windows.Forms;
using System.IO;                // Xử lý file
using System.Text;              // Xử lý chuỗi cho âm thanh
using System.Runtime.InteropServices; // Gọi thư viện Windows
using System.Threading.Tasks;   // [QUAN TRỌNG] Xử lý đa luồng để không Lag

namespace TranDangPhuc_2123110510
{
    // Enum trạng thái và độ khó
    public enum GameState { Menu, Playing, GameOver }
    public enum Difficulty { Easy, Medium, Hard }

    public partial class Form31 : Form
    {
        // --- 1. IMPORT THƯ VIỆN ÂM THANH WINDOWS (WINMM.DLL) ---
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        // --- 2. KHAI BÁO BIẾN TRẠNG THÁI ---
        private GameState currentState = GameState.Menu;
        private Difficulty currentDifficulty = Difficulty.Easy;
        private Random rand = new Random();
        private int menuIndex = 0; // 0: Easy, 1: Medium, 2: Hard

        // --- 3. CẤU HÌNH GAME ---
        private int score = 0;
        private int lives = 3;
        private int level = 1;

        // Thông số độ khó (sẽ thay đổi khi chọn menu)
        private int chickenSpawnRate = 50;
        private int chickenSpeedBase = 3;
        private int scoreToNextLevel = 100;
        private int spawnCounter = 0;

        // --- 4. DANH SÁCH ĐỐI TƯỢNG ---
        private PlayerShip player;
        private List<Bullet> bullets = new List<Bullet>();
        private List<Chicken> chickens = new List<Chicken>();

        // --- 5. INPUT ---
        private bool goLeft, goRight, isShooting;

        // --- 6. QUẢN LÝ FILE ÂM THANH ---
        private Dictionary<string, string> soundFiles = new Dictionary<string, string>();

        public Form31()
        {
            InitializeComponent();

            // [QUAN TRỌNG] Cho phép Form nhận phím trước các control khác
            this.KeyPreview = true;

            // Đăng ký đường dẫn file âm thanh (File phải nằm trong bin/Debug)
            // Dùng GetFullPath để tránh lỗi không tìm thấy file
            soundFiles.Add("shoot", Path.GetFullPath("shoot.wav"));
            soundFiles.Add("boom", Path.GetFullPath("boom.wav"));
            soundFiles.Add("gameover", Path.GetFullPath("gameover.wav"));

            // Bắt đầu vòng lặp game
            tmGameLoop.Start();
        }

        // --- HÀM PHÁT ÂM THANH KHÔNG LAG (ĐA LUỒNG) ---
        private void PlaySound(string soundName)
        {
            // Chạy trong luồng riêng (Task) để không làm đơ giao diện khi bắn nhanh
            Task.Run(() =>
            {
                try
                {
                    if (soundFiles.ContainsKey(soundName))
                    {
                        string path = soundFiles[soundName];
                        if (File.Exists(path))
                        {
                            // Tạo tên định danh ngẫu nhiên để các âm thanh chồng lên nhau được
                            string alias = "snd_" + Guid.NewGuid().ToString().Replace("-", "");

                            // Mở file và phát ngay lập tức
                            mciSendString($"open \"{path}\" type waveaudio alias {alias}", null, 0, IntPtr.Zero);
                            mciSendString($"play {alias}", null, 0, IntPtr.Zero);
                        }
                    }
                }
                catch { } // Bỏ qua nếu lỗi
            });
        }

        // --- KHỞI TẠO MÀN CHƠI ---
        private void StartGame()
        {
            // 1. Áp dụng độ khó từ Menu
            if (menuIndex == 0) currentDifficulty = Difficulty.Easy;
            else if (menuIndex == 1) currentDifficulty = Difficulty.Medium;
            else if (menuIndex == 2) currentDifficulty = Difficulty.Hard;

            // 2. Reset thông số
            player = new PlayerShip(this.ClientSize.Width / 2 - 25, this.ClientSize.Height - 60);
            bullets.Clear();
            chickens.Clear();
            score = 0;
            lives = 3;
            level = 1;
            spawnCounter = 0;

            ApplyDifficultySettings();

            // 3. Chuyển trạng thái
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
                // Tăng độ khó: Gà ra nhanh hơn, bay nhanh hơn
                if (chickenSpawnRate > 10) chickenSpawnRate -= 5;
                chickenSpeedBase += 1;

                // Thưởng mạng mỗi 3 level
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
            PlaySound("gameover");
            currentState = GameState.GameOver;
            lblGameOver.Text = "GAME OVER\nScore: " + score + "\nPress ENTER to Menu";
            lblGameOver.Location = new Point((this.ClientSize.Width - lblGameOver.Width) / 2, 200);
            lblGameOver.Visible = true;
        }

        // --- VÒNG LẶP CHÍNH (GAME LOOP) ---
        private void tmGameLoop_Tick(object sender, EventArgs e)
        {
            // Nếu không phải đang chơi thì chỉ vẽ lại màn hình (Menu/GameOver)
            if (currentState != GameState.Playing)
            {
                this.Invalidate();
                return;
            }

            // 1. DI CHUYỂN TÀU
            if (goLeft && player.X > 0) player.MoveLeft();
            if (goRight && player.X < this.ClientSize.Width - player.Width) player.MoveRight();

            // 2. BẮN ĐẠN
            if (isShooting)
            {
                bullets.Add(new Bullet(player.X + player.Width / 2 - 3, player.Y));
                PlaySound("shoot"); // Phát âm thanh (không lag)
                isShooting = false;
            }

            // 3. SINH QUÁI VẬT (GÀ/UFO)
            spawnCounter++;
            if (spawnCounter >= chickenSpawnRate)
            {
                int spawnX = rand.Next(0, this.ClientSize.Width - 40);
                int currentSpeed = chickenSpeedBase + (level / 2);
                chickens.Add(new Chicken(spawnX, -40, currentSpeed));
                spawnCounter = 0;
            }

            // 4. CẬP NHẬT VỊ TRÍ ĐẠN
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                bullets[i].Update();
                if (bullets[i].IsOutOfBounds) bullets.RemoveAt(i);
            }

            // 5. CẬP NHẬT VỊ TRÍ GÀ & XỬ LÝ VA CHẠM
            for (int i = chickens.Count - 1; i >= 0; i--)
            {
                chickens[i].Update();

                // Kiểm tra va chạm: Đạn trúng Gà
                for (int j = bullets.Count - 1; j >= 0; j--)
                {
                    if (bullets[j].Bounds.IntersectsWith(chickens[i].Bounds))
                    {
                        PlaySound("boom"); // Tiếng nổ
                        score += 10;
                        chickens.RemoveAt(i);
                        bullets.RemoveAt(j);
                        CheckLevelUp();
                        UpdateUI();
                        goto NextChicken; // Nhảy sang con gà tiếp theo
                    }
                }

                // Kiểm tra va chạm: Gà chạm Tàu hoặc Đáy màn hình
                if (chickens[i].Y > this.ClientSize.Height || chickens[i].Bounds.IntersectsWith(player.Bounds))
                {
                    lives--;
                    chickens.RemoveAt(i);
                    UpdateUI();
                    if (lives <= 0) GameOver();
                }

            NextChicken: continue;
            }

            // Vẽ lại màn hình
            this.Invalidate();
        }

        // --- SỰ KIỆN VẼ (RENDER) ---
        private void Form31_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Khử răng cưa

            if (currentState == GameState.Menu) DrawMenu(g);
            else if (currentState == GameState.Playing || currentState == GameState.GameOver)
            {
                if (player != null) player.Draw(g);
                foreach (var b in bullets) b.Draw(g);
                foreach (var c in chickens) c.Draw(g);
            }
        }

        // Vẽ Menu chọn độ khó
        private void DrawMenu(Graphics g)
        {
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center };
            g.DrawString("SPACE WAR", new Font("Segoe UI", 30, FontStyle.Bold), Brushes.Cyan, this.ClientSize.Width / 2, 80, sf);
            g.DrawString("Use UP/DOWN to select, ENTER to Start", new Font("Segoe UI", 12), Brushes.LightGray, this.ClientSize.Width / 2, 140, sf);

            Brush b1 = (menuIndex == 0) ? Brushes.Lime : Brushes.Gray;
            Brush b2 = (menuIndex == 1) ? Brushes.Yellow : Brushes.Gray;
            Brush b3 = (menuIndex == 2) ? Brushes.Red : Brushes.Gray;

            string t1 = (menuIndex == 0 ? "> " : "") + "EASY";
            string t2 = (menuIndex == 1 ? "> " : "") + "MEDIUM";
            string t3 = (menuIndex == 2 ? "> " : "") + "HARD";

            g.DrawString(t1, new Font("Segoe UI", 24, FontStyle.Bold), b1, this.ClientSize.Width / 2, 220, sf);
            g.DrawString(t2, new Font("Segoe UI", 24, FontStyle.Bold), b2, this.ClientSize.Width / 2, 280, sf);
            g.DrawString(t3, new Font("Segoe UI", 24, FontStyle.Bold), b3, this.ClientSize.Width / 2, 340, sf);
        }

        // --- XỬ LÝ PHÍM BẤM ---
        private void Form31_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentState == GameState.Menu)
            {
                if (e.KeyCode == Keys.Up) { menuIndex--; if (menuIndex < 0) menuIndex = 2; }
                else if (e.KeyCode == Keys.Down) { menuIndex++; if (menuIndex > 2) menuIndex = 0; }
                else if (e.KeyCode == Keys.Enter) StartGame();
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

    // ==========================================
    // CÁC CLASS ĐỐI TƯỢNG (ĐÃ CẬP NHẬT HÌNH DÁNG)
    // ==========================================

    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public Rectangle Bounds => new Rectangle(X, Y, Width, Height);

        public GameObject(int x, int y, int w, int h, Color color)
        {
            X = x; Y = y; Width = w; Height = h; Color = color;
        }
        public abstract void Draw(Graphics g);
    }

    // TÀU CHIẾN (Hình mũi tên có cánh)
    public class PlayerShip : GameObject
    {
        private int speed = 10;
        public PlayerShip(int x, int y) : base(x, y, 50, 40, Color.DeepSkyBlue) { }
        public void MoveLeft() => X -= speed;
        public void MoveRight() => X += speed;

        public override void Draw(Graphics g)
        {
            Point[] points = {
                new Point(X + Width / 2, Y),               // Mũi
                new Point(X + Width, Y + Height),          // Cánh phải
                new Point(X + Width / 2, Y + Height - 10), // Đuôi lõm
                new Point(X, Y + Height)                   // Cánh trái
            };
            g.FillPolygon(new SolidBrush(this.Color), points);
            // Buồng lái
            g.FillEllipse(Brushes.White, X + Width / 2 - 4, Y + 15, 8, 15);
        }
    }

    // ĐẠN (Hình viên thuốc/Plasma)
    public class Bullet : GameObject
    {
        private int speed = 15;
        public bool IsOutOfBounds => Y + Height < 0;
        public Bullet(int x, int y) : base(x, y, 6, 18, Color.Yellow) { }
        public void Update() => Y -= speed;

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Yellow, this.Bounds);
        }
    }

    // GÀ/UFO (Hình đĩa bay có nắp kính)
    public class Chicken : GameObject
    {
        public int Speed { get; set; }
        public Chicken(int x, int y, int speed) : base(x, y, 45, 30, Color.OrangeRed)
        {
            this.Speed = speed;
        }
        public void Update() => Y += Speed;

        public override void Draw(Graphics g)
        {
            // Nắp kính (Dome)
            g.FillEllipse(Brushes.Cyan, X + 10, Y - 5, 25, 20);
            // Thân đĩa
            g.FillEllipse(new SolidBrush(this.Color), X, Y + 5, Width, 20);
            // Đèn tín hiệu
            g.FillEllipse(Brushes.Yellow, X + 5, Y + 12, 6, 6);
            g.FillEllipse(Brushes.Yellow, X + 20, Y + 12, 6, 6);
            g.FillEllipse(Brushes.Yellow, X + 35, Y + 12, 6, 6);
        }
    }
}