using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AdministratorComander
{
    public partial class Form1 : Form
    {
        private int currentY = 0; // Для позиционирования панелей
        private int currentYforevent = 0; // Для позиционирования панелей
        private Image cadr;
        private List<string> namesList = new List<string>();
        
        public Form1()
        {
            this.StartPosition = FormStartPosition.Manual;

            // Задаём координаты окна (например, X=100, Y=100)
            this.Location = new Point(100, 100);

            InitializeComponent();
            
        }

        private void Create_Card(string name, string age, string position, string info, string contacts)
        {
            namesList.Add(name);

            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(namesList.ToArray());
            Panel userPanel = new Panel
            {
                Location = new Point(0, currentY),
                Size = new Size(320, 100), // увеличим высоту для контактов
                BorderStyle = BorderStyle.FixedSingle
            };

            Label nameLabel = new Label
            {
                Text = $"Имя: {name}",
                Location = new Point(10, 5),
                AutoSize = true
            };

            Label ageLabel = new Label
            {
                Text = $"Возраст: {age}",
                Location = new Point(10, 25),
                AutoSize = true
            };

            Label positionLabel = new Label
            {
                Text = $"Должность: {position}",
                Location = new Point(150, 5),
                AutoSize = true
            };
            Label contactsLabel = new Label
            {
                Text = $"Контакты: {contacts}",
                
                Location = new Point(150, 25),
                Size = new Size(150, 40),
                AutoEllipsis = true
            };

            Label infoLabel = new Label
            {

                Text = $"Справка: {info}",
                Location = new Point(10, 60),
                Size = new Size(300, 30),
                AutoEllipsis = true
            };

            userPanel.Controls.Add(nameLabel);
            userPanel.Controls.Add(ageLabel);
            userPanel.Controls.Add(positionLabel);
            userPanel.Controls.Add(infoLabel);
            userPanel.Controls.Add(contactsLabel);

            outputpn.Controls.Add(userPanel);

            currentY += userPanel.Height + 5;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            if (merinfotb.TextLength != 0 && mernametb.TextLength != 0 && datatb.TextLength != 0)
            {


                Panel eventx = new Panel()
                {
                    BackColor = Color.FromArgb(171, 242, 206),
                    Size = new Size(600, 400),
                    Location = new Point(93, currentYforevent),
                    BorderStyle = BorderStyle.FixedSingle
                };
                PictureBox pictureBox = new PictureBox()
                {
                    Size = new Size(600, 300),
                    Location = new Point(0, 0),
                    BackColor = Color.WhiteSmoke,
                    Image = cadr,

                };
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                cadr = null;
                Label namee = new Label()
                {
                    Text = $"Название: {mernametb.Text}",
                    Location = new Point(10, 320),
                    AutoSize = true
                }; 
                Label otvet = new Label()
                {
                    Text = $"Ответственное лицо: {comboBox1.SelectedItem}",
                    Location = new Point(160, 320),
                    AutoSize = true
                };
                Label Date = new Label()
                {
                    Text = $"Дата: {datatb.Text}",
                    Location = new Point(500, 320),
                    AutoSize = true
                };
                Label infor = new Label()
                {
                    Text = merinfotb.Text,
                    Location = new Point(10, 350),
                    AutoSize = true
                };
                Button deleter = new Button()
                {
                    Location = new Point(570, 315),
                    Size = new Size(20, 20),
                    BackColor = Color.FromArgb(225, 106, 106),
                    Text = "X"

                };
                deleter.Click += (s, d) =>
                {
                    eventpanel.Controls.Remove(eventx);
                    eventx.Dispose();
                    currentYforevent = currentYforevent- 405;
                    // Тут надо пересчитать всю позицию элементов - но автор об этом не думал :)
                };
                eventx.Controls.Add(pictureBox);
                eventx.Controls.Add(namee);
                eventx.Controls.Add(otvet);
                eventx.Controls.Add(Date);
                eventx.Controls.Add(infor);
                eventx.Controls.Add(deleter);
                eventpanel.Controls.Add(eventx);
                currentYforevent += 405;
                datatb.Text = "";
                mernametb.Text = "";
                merinfotb.Text = "";
                pb.Image = null;
                statuslb.Text = "Выполнено";
            }
            else
            {
                statuslb.Text = "Не все данные указаны";
            }
          }

        
        private void fotobt_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Файлы изображений|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Title = "Выберите изображение";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pb.Image = Image.FromFile(openFileDialog.FileName);
                        cadr = Image.FromFile(openFileDialog.FileName);
                        pb.SizeMode = PictureBoxSizeMode.Zoom; // чтобы изображение масштабировалось
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                    }
                }
            }
        }
        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void acceptbt_Click_1(object sender, EventArgs e)
        {
            if (nametb.TextLength != 0 && agetb.TextLength != 0 && worktb.TextLength != 0 && infotb.TextLength != 0 && contactstb.TextLength != 0)
            {

                Create_Card(nametb.Text, agetb.Text, worktb.Text, infotb.Text, contactstb.Text);
                agreelb.Text = "Добавлено";
                nametb.Text = "";
                agetb.Text = "";
                worktb.Text = "";
                infotb.Text = "";
                contactstb.Text = "";
            }
            else
            {
                agreelb.Text = "Указаны не все данные";
            }
        }

        private void infolblb_Click(object sender, EventArgs e)
        {

        }

        private void merinfotb_TextChanged(object sender, EventArgs e)
        {

        }

        private void escbt_Click(object sender, EventArgs e)
        {
            Form3 fg = new Form3();
            fg.Show();
            this.Hide();
        }
    }
}
